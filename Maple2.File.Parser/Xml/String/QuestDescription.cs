using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.String;

// TODO: Validate with IDA against client.
// ./data/xml/string/en/questdescription*.xml
[XmlRoot("ms2")]
public partial class QuestDescriptionRoot {
    [M2dFeatureLocale(Selector = "questID")] private IList<QuestDescription> _quest;
}

public partial class QuestDescription : IFeatureLocale {
    [XmlAttribute] public bool locking;
    [M2dArray(Delimiter = '|')] public int[] count = Array.Empty<int>();
    [XmlAttribute] public string complete = string.Empty;
    [M2dArray(Delimiter = '|')] public string[] manual = Array.Empty<string>();
    [XmlAttribute] public string desc = string.Empty;
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int questID;
}
