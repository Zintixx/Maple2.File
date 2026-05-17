using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/fame.xml
[XmlRoot("ms2")]
public partial class FameRoot {
    [M2dFeatureLocale(Selector = "alliance|grade")] private IList<Fame> _fame;
}

public partial class Fame : IFeatureLocale {
    [XmlAttribute] public string alliance = string.Empty;
    [XmlAttribute] public int grade;
    [XmlAttribute] public int requirePoint;
    [XmlAttribute] public int additionalEffectID;
    [XmlAttribute] public int additionalEffectLevel;
}
