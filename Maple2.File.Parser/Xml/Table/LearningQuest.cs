using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/learningquest.xml
[XmlRoot("ms2")]
public partial class LearningQuestRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<LearningQuest> _learning;
}

public partial class LearningQuest : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int category;
    [XmlAttribute] public int reqLevel;
    [XmlAttribute] public int reqQuest;
    [XmlAttribute] public int reqField;
    [XmlAttribute] public string movie = string.Empty;
    [XmlAttribute] public int gotoField;
    [XmlAttribute] public int gotoPortal;
}
