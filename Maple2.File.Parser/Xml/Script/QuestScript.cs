using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

// ./data/xml/script/quest/%s.xml
[XmlRoot("ms2")]
public class QuestScriptRoot {
    [XmlElement] public List<QuestScript> quest;
}

public partial class QuestScript {
    [XmlAttribute] public int id;

    [M2dFeatureLocale(Selector = "id")] private IList<QuestTalkScript> _script;
}
