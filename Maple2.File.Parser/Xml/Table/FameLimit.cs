using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/famelimit.xml
[XmlRoot("ms2")]
public partial class FameLimitRoot {
    [M2dFeatureLocale(Selector = "alliance")] private IList<FameLimit> _condition;
}

public partial class FameLimit : IFeatureLocale {
    [XmlAttribute] public string alliance = string.Empty;
    [M2dArray] public string[] requireAlliance = Array.Empty<string>();
    [M2dArray] public int[] requireGrade = Array.Empty<int>();
}
