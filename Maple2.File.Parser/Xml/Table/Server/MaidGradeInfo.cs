using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/MaidGradeInfo.xml
[XmlRoot("ms2")]
public class MaidGradeInfoRoot {
    [XmlElement] public List<MaidGradeInfo> Grade;
}

public class MaidGradeInfo {
    [XmlAttribute] public int Grade;
    [XmlAttribute] public float JackpotRate;
    [XmlAttribute] public float FeelNormalRate;
    [XmlAttribute] public float FeelGoodRate;
    [XmlAttribute] public float FeelVeryGoodRate;
}
