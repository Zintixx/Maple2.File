using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemrepackingscroll.xml
[XmlRoot("ms2")]
public partial class ItemRepackingScrollRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ItemRepackingScroll> _rePackingScroll;
}

public partial class ItemRepackingScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public short minLv;
    [XmlAttribute] public short maxLv;
    [M2dArray] public int[] slot = Array.Empty<int>();
    [M2dArray] public int[] rank = Array.Empty<int>();
    [XmlAttribute] public bool petType;
}
