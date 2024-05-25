using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemremakescroll.xml
[XmlRoot("ms2")]
public partial class ItemRemakeScrollRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ItemRemakeScroll> _remakeScroll;
}

public partial class ItemRemakeScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public short minLv;
    [XmlAttribute] public short maxLv;
    [M2dArray] public int[] rank = Array.Empty<int>();
    [M2dArray] public int[] slot = Array.Empty<int>();
    [XmlAttribute] public bool onlyPet;
    [M2dArray] public int[] item = Array.Empty<int>();
    [XmlAttribute] public int representOpValue;
    [XmlAttribute] public int mainOpKind;
    [XmlAttribute] public int mainOpValue;
    [XmlAttribute] public int addOpKind;
    [XmlAttribute] public int addOpValue;
}
