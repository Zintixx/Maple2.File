using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/petexp.xml
[XmlRoot("ms2")]
public partial class PetExpRoot {
    [M2dFeatureLocale(Selector = "level")] private IList<PetExp> _exp;
}

public partial class PetExp : IFeatureLocale {
    [XmlAttribute] public short level = 1;
    [XmlAttribute] public int normal;
    [XmlAttribute] public int rare;
    [XmlAttribute] public int elite;
    [XmlAttribute] public int excellent;
    [XmlAttribute] public int legendary;
    [XmlAttribute] public int artifact;
}
