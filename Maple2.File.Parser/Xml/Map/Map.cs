using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Map;

// ./data/xml/map/%08d.xml
[XmlRoot("ms2")]
public partial class MapDataRoot {
    [M2dFeatureLocale] private MapData _environment;
}

public partial class MapData : IFeatureLocale {
    [XmlElement] public XBlock xblock = new();
    [XmlElement] public Property property = new();
    [XmlElement] public Drop drop = new();
    [XmlElement] public Split split = new();
    [XmlElement] public CashCall cashCall = new();
    [XmlElement] public Indoor indoor = new();
    [XmlElement] public UI ui = new();
    [XmlElement] public BGM bgm = new();
    [XmlElement] public HDR hdr = new();
    [XmlElement] public Survival survival = new();
    [XmlElement] public Camera camera = new();
    [XmlElement] public Shadow shadow = new();
    [XmlElement] public FOV fov = new();
    [XmlElement] public Optimize optimize = new();
    [XmlElement] public WorldMap worldmap = new(); // Ignored by client.
}

// .data/xml/table/fielddata.xml
[XmlRoot("ms2")]
public partial class MapDataRootNew {
    // list of fieldData with ID as mapId, then inside its environment as MapDataRoot
    [XmlElement("fieldData")] public List<MapDataRootNew> fieldData = [];
}

public partial class MapDataRootNew {
    [XmlAttribute] public int id;
    [M2dFeatureLocale] private MapData _environment = new();
}
