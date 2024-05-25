using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/feature_setting.xml
[XmlRoot("ms2")]
public class FeatureSetting {
    [XmlElement] public List<Setting> setting;
}

public class Setting {
    [XmlAttribute] public int TW;
    [XmlAttribute] public int TH;
    [XmlAttribute] public int NA;
    [XmlAttribute] public int CN;
    [XmlAttribute] public int JP;
    [XmlAttribute] public int KR;
    [XmlAttribute] public string type = string.Empty;
}
