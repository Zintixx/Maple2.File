using System.Diagnostics;
using System.Text.RegularExpressions;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;

namespace Maple2.File.Parser.Flat.Convert;

public class AssetIndex {
    private const uint MAGIC = 0x00495341;
    private const int VERSION = 1;

    private static Regex extractRegex = new("^<(urn:uuid:[0-9a-f-]+)> <.+> \"(.+)\".$");

    private readonly Dictionary<string, List<string>> llidLookup;
    private readonly Dictionary<string, Dictionary<string, string>> ntLookup;
    private static readonly string[] NtTagFiles = new string[] {
        "application",
        "cn",
        "dds",
        "emergent-flat-model",
        "emergent-world",
        "fx-shader-compiled",
        "gamebryo-animation",
        "gamebryo-scenegraph",
        "gamebryo-sequence-file",
        "image",
        "jp",
        "kr",
        "lua-behavior",
        "model",
        "png",
        "precache",
        "script",
        "shader",
        "x-shockwave-flash",
        "x-world",
    };
    private static readonly string[] NtFiles = new string[] {
        "llid",
        "name",
        "relpath",
    };

    public AssetIndex(M2dReader reader) {
        ntLookup = new Dictionary<string, Dictionary<string, string>>();
        llidLookup = new Dictionary<string, List<string>>();

        foreach (PackFileEntry entry in reader.Files.Where(entry => entry.Name.EndsWith(".nt"))) {
            string key = Path.GetFileNameWithoutExtension(entry.Name);
            if (!NtFiles.Contains(key) && !NtTagFiles.Contains(key)) {
                continue;
            }

            Dictionary<string, string> value = ParseNtFile(reader.GetString(entry));
            if (key == "llid") {
                foreach ((string k, string v) in value) {
                    if (!llidLookup.ContainsKey(v)) {
                        llidLookup.Add(v, new List<string>());
                    }

                    llidLookup[v].Add(k);
                }
            }

            ntLookup.Add(key!, value);
        }
    }

    private AssetIndex(Dictionary<string, List<string>> llidLookup, Dictionary<string, Dictionary<string, string>> ntLookup) {
        this.llidLookup = llidLookup;
        this.ntLookup = ntLookup;
    }

    public void Serialize(BinaryWriter writer) {
        writer.Write(MAGIC);
        writer.Write(VERSION);

        writer.Write(llidLookup.Count);
        foreach (var kvp in llidLookup) {
            writer.Write(kvp.Key ?? string.Empty);
            writer.Write(kvp.Value.Count);
            foreach (string llid in kvp.Value) {
                writer.Write(llid ?? string.Empty);
            }
        }

        writer.Write(ntLookup.Count);
        foreach (var kvp in ntLookup) {
            writer.Write(kvp.Key ?? string.Empty);
            writer.Write(kvp.Value.Count);
            foreach (var innerKvp in kvp.Value) {
                writer.Write(innerKvp.Key ?? string.Empty);
                writer.Write(innerKvp.Value ?? string.Empty);
            }
        }
    }

    public static AssetIndex Deserialize(BinaryReader reader) {
        uint magic = reader.ReadUInt32();
        if (magic != MAGIC) {
            throw new InvalidDataException($"Invalid AssetIndex magic: expected {MAGIC:X}, got {magic:X}");
        }

        int version = reader.ReadInt32();
        if (version != VERSION) {
            throw new InvalidDataException($"Unsupported AssetIndex version: {version}");
        }

        int llidCount = reader.ReadInt32();
        var llidLookup = new Dictionary<string, List<string>>(llidCount);
        for (int i = 0; i < llidCount; i++) {
            string key = reader.ReadString();
            int valueCount = reader.ReadInt32();
            var values = new List<string>(valueCount);
            for (int j = 0; j < valueCount; j++) {
                values.Add(reader.ReadString());
            }
            llidLookup[key] = values;
        }

        int ntCount = reader.ReadInt32();
        var ntLookup = new Dictionary<string, Dictionary<string, string>>(ntCount);
        for (int i = 0; i < ntCount; i++) {
            string key = reader.ReadString();
            int innerCount = reader.ReadInt32();
            var innerDict = new Dictionary<string, string>(innerCount);
            for (int j = 0; j < innerCount; j++) {
                innerDict[reader.ReadString()] = reader.ReadString();
            }
            ntLookup[key] = innerDict;
        }

        return new AssetIndex(llidLookup, ntLookup);
    }

    public (string Name, string Path, string Tags) GetFields(string llid) {
        llid = llid.Replace("urn:llid:", "");
        if (!llidLookup.TryGetValue(llid, out List<string> uuids)) {
            Console.WriteLine($"Failed to lookup metadata for: {llid}");
            return ("", "", "");
        }

        Debug.Assert(uuids.Count == 1, $"Failed to resolve llid:{llid} to uuid");
        string uuid = uuids.SingleOrDefault();

        var tags = new List<string>();
        foreach (string tagName in NtTagFiles) {
            if (ntLookup[tagName].ContainsKey(uuid)) {
                tags.Add(tagName);
            }
        }

        string name = ntLookup["name"][uuid];
        tags.Add(name);
        string path = ntLookup["relpath"][uuid];

        return (name, path, string.Join(':', tags));
    }

    // Lazily-built reverse of ntLookup["name"] (uuid -> name), so ResolveLlid can go name -> uuid -> llid.
    private Dictionary<string, string> nameToUuid;

    /// <summary>The reverse of <see cref="GetFields"/>: resolve an asset NAME (e.g. a NIF's
    /// <c>40400053_ugc_..._run_a</c>) back to its <c>urn:llid:...</c> string, or "" when the name is not in
    /// the metadata. The map editor uses this to write a placed entity's <c>NifAsset</c> in the urn:llid
    /// form the retail client requires, rather than the bare name (which only this project's loader accepts).
    /// Case-insensitive; builds the name→uuid index once on first use and reuses it.
    /// Only <c>gamebryo-scenegraph</c> (NIF) assets are considered: names are NOT unique across kinds — a
    /// cube NIF, its texture and its flat usually share one (<c>ca_deform_brick_A01</c> is both a .nif and a
    /// .dds), and 4,416 of the GMS2 client's 29,751 NIF names collide with another asset that way.</summary>
    public string ResolveLlid(string name) {
        if (string.IsNullOrEmpty(name)) {
            return "";
        }

        if (nameToUuid == null) {
            nameToUuid = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (ntLookup.TryGetValue("name", out Dictionary<string, string> nameMap)
                && ntLookup.TryGetValue("gamebryo-scenegraph", out Dictionary<string, string> scenegraph)) {
                foreach ((string uuid, string assetName) in nameMap) {
                    if (scenegraph.ContainsKey(uuid)) {
                        nameToUuid[assetName] = uuid;
                    }
                }
            }
        }

        if (!nameToUuid.TryGetValue(name, out string foundUuid)
            || !ntLookup.TryGetValue("llid", out Dictionary<string, string> llidMap)
            || !llidMap.TryGetValue(foundUuid, out string llid)) {
            return "";
        }

        return "urn:llid:" + llid;
    }

    private const string PredicateBase = "http://emergent.net/aweb/1.0/";

    /// <summary>
    /// The llid of an asset, derived from its logpath exactly as the retail asset tooling does:
    /// FNV-1a 32-bit over the UTF-8 logpath, printed as <c>xxxxxxxx-0000-0000-0000-000000000000</c>.
    /// Verified against every one of the 83,322 llid records in the GMS2 client's asset-web-metadata.
    /// </summary>
    public static string ComputeLlid(string logpath) {
        uint hash = 0x811c9dc5;
        foreach (byte b in System.Text.Encoding.UTF8.GetBytes(logpath)) {
            hash ^= b;
            hash = unchecked(hash * 0x01000193);
        }
        return $"{hash:x8}-0000-0000-0000-000000000000";
    }

    /// <summary>A custom (non-retail) asset registered with <see cref="Register"/>, with every metadata field
    /// a stock record carries, so it can be written out as native <c>.nt</c> lines for the retail client.</summary>
    public sealed class CustomAsset {
        /// <summary>Includes the <c>urn:uuid:</c> prefix, as the <c>.nt</c> subjects do.</summary>
        public string Uuid { get; set; } = "";
        /// <summary>Bare llid (no <c>urn:llid:</c> prefix).</summary>
        public string Llid { get; set; } = "";
        public string Name { get; set; } = "";
        public string RelPath { get; set; } = "";
        public string LogPath { get; set; } = "";
        public string Canonical { get; set; } = "";
        public IReadOnlyList<string> Tags { get; set; } = Array.Empty<string>();

        public string UrnLlid => "urn:llid:" + Llid;

        /// <summary>One line per <c>.nt</c> file the record appears in, in the stock line format.</summary>
        public IEnumerable<(string File, string Line)> ToNtLines() {
            yield return ("llid.nt", NtLine(Uuid, "llid", Llid));
            yield return ("name.nt", NtLine(Uuid, "name", Name));
            yield return ("relpath.nt", NtLine(Uuid, "relpath", RelPath));
            yield return ("logpath.nt", NtLine(Uuid, "logpath", LogPath));
            yield return ("canonical.nt", NtLine(Uuid, "canonical", Canonical));
            foreach (string tag in Tags) {
                yield return (tag + ".nt", NtLine(Uuid, "tag", tag));
            }
        }
    }

    /// <summary>A stock-format N-Triples line: <c>&lt;urn:uuid:…&gt; &lt;http://emergent.net/aweb/1.0/{predicate}&gt; "{value}".</c></summary>
    public static string NtLine(string uuid, string predicate, string value) {
        return $"<{uuid}> <{PredicateBase}{predicate}> \"{value}\".";
    }

    /// <summary>
    /// Adds a custom asset to this index so <see cref="GetFields"/> and <see cref="ResolveLlid"/> resolve it
    /// like a stock asset. Every field is derived from <paramref name="relpath"/> the way stock records are:
    /// name = file name without extension, logpath = lowercased relpath, canonical = its directory,
    /// llid = <see cref="ComputeLlid"/>(logpath). The uuid is deterministic (name-based, from the logpath),
    /// so registering the same path again is idempotent.
    /// Throws if the path's llid is already taken by a different asset — i.e. the path collides with a
    /// retail asset — rather than silently shadowing it.
    /// </summary>
    public CustomAsset Register(string relpath, params string[] tags) {
        if (string.IsNullOrEmpty(relpath) || relpath[0] != '/' || relpath.Contains('\\')) {
            throw new ArgumentException($"relpath must be an absolute forward-slash path like /Model/Map/..., got '{relpath}'", nameof(relpath));
        }
        int slash = relpath.LastIndexOf('/');
        string fileName = relpath.Substring(slash + 1);
        int dot = fileName.LastIndexOf('.');
        if (dot <= 0) {
            throw new ArgumentException($"relpath must end in a file name with an extension, got '{relpath}'", nameof(relpath));
        }
        foreach (string tag in tags) {
            if (!NtTagFiles.Contains(tag)) {
                throw new ArgumentException($"unknown asset tag '{tag}'", nameof(tags));
            }
        }

        string logpath = relpath.ToLowerInvariant();
        var asset = new CustomAsset {
            Uuid = "urn:uuid:" + NameBasedUuid(logpath),
            Llid = ComputeLlid(logpath),
            Name = fileName.Substring(0, dot),
            RelPath = relpath,
            LogPath = logpath,
            Canonical = slash == 0 ? "/" : relpath.Substring(0, slash),
            Tags = tags.ToArray(),
        };

        if (llidLookup.TryGetValue(asset.Llid, out List<string> existing)) {
            if (existing.Count == 1 && existing[0] == asset.Uuid) {
                return asset;
            }
            throw new InvalidOperationException(
                $"llid {asset.Llid} for '{relpath}' is already used by another asset; pick a path that does not exist in the retail client");
        }

        llidLookup[asset.Llid] = new List<string> { asset.Uuid };
        NtMap("llid")[asset.Uuid] = asset.Llid;
        NtMap("name")[asset.Uuid] = asset.Name;
        NtMap("relpath")[asset.Uuid] = asset.RelPath;
        foreach (string tag in asset.Tags) {
            NtMap(tag)[asset.Uuid] = tag;
        }
        nameToUuid = null; // rebuild the reverse index on next ResolveLlid
        return asset;
    }

    private Dictionary<string, string> NtMap(string key) {
        if (!ntLookup.TryGetValue(key, out Dictionary<string, string> map)) {
            map = new Dictionary<string, string>();
            ntLookup[key] = map;
        }
        return map;
    }

    // RFC 4122 version-5-style uuid (SHA-1 over a fixed namespace string + the logpath).
    private static string NameBasedUuid(string logpath) {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        byte[] hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes("ms2odyssey-custom-asset:" + logpath));
        hash[6] = (byte) ((hash[6] & 0x0F) | 0x50);
        hash[8] = (byte) ((hash[8] & 0x3F) | 0x80);
        string hex = string.Concat(hash.Take(16).Select(b => b.ToString("x2")));
        return $"{hex.Substring(0, 8)}-{hex.Substring(8, 4)}-{hex.Substring(12, 4)}-{hex.Substring(16, 4)}-{hex.Substring(20, 12)}";
    }

    private static Dictionary<string, string> ParseNtFile(string data) {
        var result = new Dictionary<string, string>();
        foreach (string line in data.Split("\n")) {
            if (string.IsNullOrWhiteSpace(line)) {
                continue;
            }

            Match match = extractRegex.Match(line);
            Debug.Assert(match.Success, $"failed to match: {line}");

            result.Add(match.Groups[1].Value, match.Groups[2].Value);
        }

        return result;
    }
}
