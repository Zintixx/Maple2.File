using Maple2.File.IO;

namespace Maple2.File.Parser.Flat;

/// <summary>
/// Resolves model names to their corresponding NIF asset names.
/// Sequence: modelName -> find flat with the same name -> get llid from it -> llid to uuid -> uuid to nif asset name
/// </summary>
public class ModelToNifResolver {
    private readonly FlatTypeIndex flatIndex;
    private readonly Convert.AssetIndex assetIndex;

    /// <summary>
    /// Initializes a new instance of the ModelToNifResolver class.
    /// </summary>
    /// <param name="exportedReader">M2dReader for the exported .m2d containing flat files</param>
    /// <param name="assetMetadataReader">M2dReader for the asset-web-metadata.m2d file</param>
    /// <param name="flatRoot">Root path for flat files (default: "flat")</param>
    public ModelToNifResolver(M2dReader exportedReader, M2dReader assetMetadataReader, string flatRoot = "flat") {
        flatIndex = new FlatTypeIndex(exportedReader, flatRoot);
        assetIndex = new Convert.AssetIndex(assetMetadataReader);
    }

    /// <summary>
    /// Resolves a model name to its NIF asset name.
    /// </summary>
    /// <param name="modelName">The name of the model to resolve</param>
    /// <returns>The NIF asset name, or null if not found or not a NIF asset</returns>
    public string? GetNifAssetName(string modelName) {
        // Step 1: Find flat type with the same name
        FlatType? flatType = flatIndex.GetType(modelName);
        if (flatType == null) {
            Console.WriteLine($"Model not found: {modelName}");
            return null;
        }

        // Step 2: Get llid from the flat type
        // NIF assets are typically stored in properties like "NifAsset" or "AttachedNifAsset"
        string? llid = GetNifAssetLlid(flatType);
        if (llid == null) {
            Console.WriteLine($"No NIF asset found for model: {modelName}");
            return null;
        }

        // Step 3 & 4: Convert llid to uuid and get asset name
        (string name, string path, string tags) = assetIndex.GetFields(llid);

        if (string.IsNullOrEmpty(name)) {
            Console.WriteLine($"Failed to resolve asset metadata for llid: {llid}");
            return null;
        }

        // Verify it's actually a NIF asset by checking tags or path
        if (!IsNifAsset(path, tags)) {
            Console.WriteLine($"Asset is not a NIF file: {name} (path: {path}, tags: {tags})");
            return null;
        }

        return name;
    }

    /// <summary>
    /// Gets detailed information about the NIF asset for a model.
    /// </summary>
    /// <param name="modelName">The name of the model to resolve</param>
    /// <returns>A tuple containing (name, path, tags) of the NIF asset, or null values if not found</returns>
    public (string? Name, string? Path, string? Tags) GetNifAssetInfo(string modelName) {
        // Step 1: Find flat type with the same name
        FlatType? flatType = flatIndex.GetType(modelName);
        if (flatType == null) {
            Console.WriteLine($"Model not found: {modelName}");
            return (null, null, null);
        }

        // Step 2: Get llid from the flat type
        string? llid = GetNifAssetLlid(flatType);
        if (llid == null) {
            Console.WriteLine($"No NIF asset found for model: {modelName}");
            return (null, null, null);
        }

        // Step 3 & 4: Convert llid to uuid and get asset info
        (string name, string path, string tags) = assetIndex.GetFields(llid);

        if (string.IsNullOrEmpty(name)) {
            Console.WriteLine($"Failed to resolve asset metadata for llid: {llid}");
            return (null, null, null);
        }

        return (name, path, tags);
    }

    /// <summary>
    /// Extracts the NIF asset LLID from a flat type.
    /// Searches for properties like "NifAsset", "AttachedNifAsset", or similar.
    /// </summary>
    private string? GetNifAssetLlid(FlatType flatType) {
        // Common property names for NIF assets
        string[] nifPropertyNames = { "NifAsset", "AttachedNifAsset", "Mesh", "MeshAsset" };

        foreach (string propertyName in nifPropertyNames) {
            FlatProperty? property = flatType.GetProperty(propertyName);
            if (property == null) {
                continue;
            }

            // Check if the property type is AssetID or related
            if (property.Type == "AssetID" || property.Type.Contains("Asset")) {
                string? llid = property.Value?.ToString();
                if (!string.IsNullOrEmpty(llid)) {
                    return llid;
                }
            }

            // For AssocAttachedNifAsset, get the first value
            if (property.Type == "AssocAttachedNifAsset" && property.Value is Dictionary<string, string> dict) {
                string? firstValue = dict.Values.FirstOrDefault();
                if (!string.IsNullOrEmpty(firstValue)) {
                    return firstValue;
                }
            }
        }

        // If no NIF property found, try to get all properties with AssetID type
        foreach (FlatProperty property in flatType.GetAllProperties()) {
            if (property.Type == "AssetID") {
                string? llid = property.Value?.ToString();
                if (!string.IsNullOrEmpty(llid)) {
                    // Check if this is likely a NIF asset
                    (string name, string path, string tags) = assetIndex.GetFields(llid);
                    if (IsNifAsset(path, tags)) {
                        return llid;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Checks if an asset is a NIF file based on its path and tags.
    /// </summary>
    private bool IsNifAsset(string path, string tags) {
        if (string.IsNullOrEmpty(path)) {
            return false;
        }

        // Check file extension
        if (path.EndsWith(".nif", StringComparison.OrdinalIgnoreCase)) {
            return true;
        }

        // Check tags for gamebryo-scenegraph (NIF format indicator)
        if (!string.IsNullOrEmpty(tags) && tags.Contains("gamebryo-scenegraph")) {
            return true;
        }

        return false;
    }
}
