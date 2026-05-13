using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/npcStatFactorByPlayerCount.xml
[XmlRoot("ms2")]
public class NpcStatFactorByPlayerCountRoot {
    [XmlElement] public List<NpcStatFactorByPlayerCount> PlayerCountFactor;
}

public partial class NpcStatFactorByPlayerCount {
    [XmlAttribute] public int factorID;
    [XmlAttribute] public int @class;
    [XmlAttribute] public int playerCount;
    [XmlAttribute] public float hpRate;
    [XmlAttribute] public int hpValue;
    [XmlAttribute] public float papRate;
    [XmlAttribute] public int papValue;
    [XmlAttribute] public float mapRate;
    [XmlAttribute] public int mapValue;
    [XmlAttribute] public float nddRate;
    [XmlAttribute] public int nddValue;
    [XmlAttribute] public float capRate;
    [XmlAttribute] public int capValue;
}
