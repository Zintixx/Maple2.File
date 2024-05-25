using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/nextexp.xml
[XmlRoot("ms2")]
public partial class NextExpRoot {
    [M2dFeatureLocale(Selector = "level")] private IList<NextExp> _exp;
}

public partial class NextExp : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public long value;
}
