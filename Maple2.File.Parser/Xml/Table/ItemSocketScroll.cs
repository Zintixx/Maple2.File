using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemsocketscroll.xml
[XmlRoot("ms2")]
public partial class ItemSocketScrollRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ItemSocketScroll> _scroll;
}

public partial class ItemSocketScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int type;
    [XmlAttribute] public short minLv;
    [XmlAttribute] public short maxLv;
    [M2dArray] public int[] slot = Array.Empty<int>();
    [M2dArray] public int[] rank = Array.Empty<int>();
    [XmlAttribute] public int tradableCountDeduction;
    [M2dArray] public int[] usePart = Array.Empty<int>();
}
