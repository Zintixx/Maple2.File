using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/{locale}/autoactionpricepackage.xml
[XmlRoot("ms2")]
public class AutoActionPricePackageRoot {
    [XmlElement] public List<AutoActionPricePackage> package;
}

public class AutoActionPricePackage {
    [XmlAttribute] public string content = string.Empty;
    [XmlAttribute] public int id;
    [XmlAttribute] public int duration;
    [XmlAttribute] public int merat;
}
