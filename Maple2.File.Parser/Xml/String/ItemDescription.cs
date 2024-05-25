using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.String;

[XmlRoot("ms2")]
public partial class ItemDescription {
    [M2dFeatureLocale(Selector = "id")] private IList<Key> _key;

    public partial class Key : IFeatureLocale {
        [XmlAttribute] public int id;
        [XmlAttribute] public string tooltipDescription = string.Empty;
        [XmlAttribute] public string guideDescription = string.Empty;
    }
}
