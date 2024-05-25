using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.MapXBlock;

namespace Maple2.File.Parser.Flat.Convert;

public class XBlockToBlock {
    private readonly M2dReader reader;
    private readonly FlatTypeIndex index;
    private readonly XmlSerializer blockSerializer;
    private readonly XmlSerializer xblockSerializer;
    private readonly XmlSerializerNamespaces xmlNamespace;

    public XBlockToBlock(M2dReader reader, string root = "flat") {
        this.reader = reader;
        index = new FlatTypeIndex(reader, root);
        blockSerializer = new XmlSerializer(typeof(GameBlock));
        xblockSerializer = new XmlSerializer(typeof(GameXBlock));
        xmlNamespace = new XmlSerializerNamespaces();
        xmlNamespace.Add(string.Empty, string.Empty);
    }

    public void Convert() {
        ParallelQuery<GameBlock> blocks = reader.Files
            .Where(file => file.Name.StartsWith("xblock/"))
            .AsParallel()
            .Select(file => {
                var xblock = xblockSerializer.Deserialize(reader.GetXmlReader(file)) as GameXBlock;
                Debug.Assert(xblock != null);

                GameBlock block = DefaultBlock(Path.GetFileNameWithoutExtension(file.Name));
                foreach (Entity entity in xblock.entitySet.entity) {
                    FlatType flatType = index.GetType(entity.modelName);
                    if (flatType == null) {
                        Console.WriteLine($"[{block.Name}] No FlatType for {entity.modelName}");
                        continue;
                    }

                    block.Entities.EntityList.Add(new Entities.Entity {
                        // 00000000000000000000000000000000 => 00000000-0000-0000-0000-000000000000
                        Id = Guid.Parse(entity.id).ToString("D"),
                        ModelName = entity.modelName,
                        ModelId = flatType.ToGuid().ToString(),
                        Name = entity.name,
                        Iterations = entity.iterations,
                        Properties = new Properties {
                            PropertyList = entity.property,
                        },
                    });
                }

                return block;
            });

        foreach (GameBlock block in blocks) {
            string name = $"convert/block/{block.Name}.block";
            Directory.CreateDirectory(Path.GetDirectoryName(name) ?? string.Empty);

            var writer = new XmlTextWriter(new StreamWriter(name, false, Encoding.UTF8));
            writer.Formatting = Formatting.Indented;
            blockSerializer.Serialize(writer, block, xmlNamespace);
            // Console.WriteLine($"Created {name}");
        }
    }

    private static GameBlock DefaultBlock(string name) {
        return new GameBlock {
            Version = 3,
            Name = name,
            ModelReferences = new ModelReferences {
                References = new List<string> {
                    @"..\Library\maplestory2library\maplestory2.emtproj",
                    @"..\Presets\presets common\presets common.emtproj",
                    @"..\Presets\presets cube\presets cube.emtproj",
                    @"..\Presets\presets cube_shadow\presets cube_shadow.emtproj",
                    @"..\Presets\presets npc\presets npc.emtproj",
                    @"..\Presets\presets object_shadow\presets object_shadow.emtproj",
                    @"..\Presets\presets test\presets test.emtproj",
                    @"..\Presets\presets object\presets object.emtproj",
                },
            },
            ToolSettings = new ToolSettings {
                Settings = new List<ToolSettings.Setting> {
                    new() {
                        Id = "Emergent.WorldBuilder.CustomShaders.CustomShaderDirectory",
                        PropertyType = "String",
                        Value = "",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.ExportFolder",
                        PropertyType = "String",
                        Value = "../Exported", // TODO: Is this correct?
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.Exporter",
                        PropertyType = "String",
                        Value = "XmlBlockExporter",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.Grid.ScalePrecision",
                        PropertyType = "Float",
                        Value = "0.1",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.Grid.ScalePrecisionEnabled",
                        PropertyType = "Boolean",
                        Value = "False",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.Grid.TranslationPrecision",
                        PropertyType = "Float",
                        Value = "0.1",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.Grid.TranslationPrecisionEnabled",
                        PropertyType = "Boolean",
                        Value = "False",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.SnapPoints.SnapPointStickinessRadius",
                        PropertyType = "Float",
                        Value = "0.5",
                    },
                    new() {
                        Id = "Emergent.WorldBuilder.World.Scale",
                        PropertyType = "Float",
                        Value = "1",
                    },
                },
            },
            Layers = new Layers(),
            Entities = new Entities {
                EntityList = new List<Entities.Entity>(),
            },
            Selections = new Selections(),
            EntityFolders = new EntityFolders(),
        };
    }
}
