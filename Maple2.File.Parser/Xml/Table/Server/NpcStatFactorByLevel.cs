using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/npcStatFactorByLevel.xml
[XmlRoot("ms2")]
public class NpcStatFactorByLevelRoot {
    [XmlElement] public List<NpcStatFactorByLevel> levelFactor;
}

public partial class NpcStatFactorByLevel {
    [XmlAttribute] public int level;
    [XmlAttribute] public int @class;
    [XmlAttribute] public float hp;
    [XmlAttribute] public float pap;
    [XmlAttribute] public float map;
    [XmlAttribute] public float ndd;
    [XmlAttribute] public float cap;
}
