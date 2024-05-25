using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/ugcdesign.xml
[XmlRoot("ms2")]
public partial class UgcDesignRoot {
    [M2dFeatureLocale(Selector = "itemID")] private IList<UgcDesign> _list;
}

public partial class UgcDesign : IFeatureLocale {
    [XmlAttribute] public int dpOrder;
    [XmlAttribute] public int itemID;
    [XmlAttribute] public int category;
    [XmlAttribute] public bool visible;
    [XmlAttribute] public byte itemGrade;
    [XmlAttribute] public byte priceType;
    [XmlAttribute] public long price;
    [XmlAttribute] public long salePrice;
    [XmlAttribute] public long marketMinPrice;
    [XmlAttribute] public long marketMaxPrice;
    [XmlAttribute] public byte saleTag;
}
