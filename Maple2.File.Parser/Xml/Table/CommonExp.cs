using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/commonexptable.xml
[XmlRoot("ms2")]
public partial class CommonExpRoot {
    [M2dFeatureLocale(Selector = "expType")] private IList<CommonExp> _exp;
}

public partial class CommonExp : IFeatureLocale {
    [M2dEnum] public CommonExpType expType;
    [XmlAttribute] public int expTableID;
    [XmlAttribute] public float factor;
}
