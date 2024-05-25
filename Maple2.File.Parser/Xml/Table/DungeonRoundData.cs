using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/dungeonrounddata.xml
[XmlRoot("ms2")]
public partial class DungeonRoundDataRoot {
    [XmlElement] public List<DungeonRoundGroup> DungeonRoundGroup;
}

public partial class DungeonRoundGroup {
    [XmlAttribute] public int id;
    [XmlElement] public List<DungeonRoundGroupEntry> v;
}

public class DungeonRoundGroupEntry {
    [XmlAttribute] public int rewardID;
    [XmlAttribute] public int gearScore;
}
