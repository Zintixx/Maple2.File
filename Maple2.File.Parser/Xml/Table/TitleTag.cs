using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/titletag.xml
[XmlRoot("ms2")]
public partial class TitleTagRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<TitleTag> _key;
}

public partial class TitleTag : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string tag = string.Empty;
    [XmlAttribute] public bool account;
}
