using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/feature.xml
[XmlRoot("ms2")]
public class FeatureRoot {
    [XmlElement] public List<Feature> feature;
}

public class Feature {
    [XmlAttribute] public int TW;
    [XmlAttribute] public int TH;
    [XmlAttribute] public int NA;
    [XmlAttribute] public int CN;
    [XmlAttribute] public int JP;
    [XmlAttribute] public int KR;
    [XmlAttribute] public string name = string.Empty;
}
