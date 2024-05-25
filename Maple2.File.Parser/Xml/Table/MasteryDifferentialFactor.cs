using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/masterydifferentialfactor.xml
[XmlRoot("ms2")]
public class MasteryDifferentialFactorRoot {
    [XmlElement] public List<MasteryDifferentialFactor> v;
}

public class MasteryDifferentialFactor {
    [XmlAttribute] public int differential;
    [XmlAttribute] public int factor;
    [XmlAttribute] public string icon = string.Empty;
}
