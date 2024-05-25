using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/enchantscroll.xml
[XmlRoot("ms2")]
public partial class EnchantScrollRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<EnchantScroll> _scroll;
}

public partial class EnchantScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public short scrollType;
    [XmlAttribute] public short minLv;
    [XmlAttribute] public short maxLv;
    [M2dArray] public int[] grade = Array.Empty<int>();
    [XmlAttribute] public int minGrade;
    [XmlAttribute] public int maxGrade;
    [M2dArray] public int[] slot = Array.Empty<int>();
    [M2dArray] public int[] rank = Array.Empty<int>();

    // Not present in xml
    // [XmlAttribute] public bool isLockTrade;
    // [XmlAttribute] public bool disableBreak;
}
