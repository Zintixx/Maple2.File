using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/petspawninfo.xml
[XmlRoot("ms2")]
public class PetSpawnInfoRoot {
    [XmlElement] public List<PetSpawnInfo> SpawnInfo;
}

public class PetSpawnInfo {
    [XmlAttribute] public int fieldID;
    [XmlAttribute] public int petID;
    [XmlAttribute] public int npcID;
}
