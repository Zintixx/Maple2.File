using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/banner.xml
[XmlRoot("ms2")]
public partial class BannerRoot {
    [XmlElement] public List<Banner> banner;
}

public partial class Banner {
    [XmlAttribute] public int id;
    [XmlAttribute] public int field;
    [XmlAttribute] public bool ad;
    [XmlAttribute] public int size;
    [XmlAttribute] public string @default = string.Empty;
    [M2dArray] public long[] price = Array.Empty<long>();
}
