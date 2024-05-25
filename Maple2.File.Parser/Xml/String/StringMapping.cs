using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.String;

[XmlRoot("ms2")]
public partial class StringMapping {
    [M2dFeatureLocale(Selector = "id")] private IList<Key> _key;
}
