using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

public partial class TalkScript : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string tag = string.Empty; // "limitFameGrade"
    [XmlAttribute] public bool randomPick;

    [XmlElement] public List<CinematicContent> content;

    // Ignored by client.
    [XmlAttribute] public string buttonSet = string.Empty; // "roulette"
}

// Only used for Scripts/Npc/%d.xml <script>
public partial class ConditionTalkScript : TalkScript, IFeatureLocale {
    [M2dArray] public int[] gotoConditionTalkID = Array.Empty<int>();
}

// Only used for Scripts/Quest/%d.xml <script>
public partial class QuestTalkScript : TalkScript, IFeatureLocale {
    [XmlAttribute] public int jobCondition;
}
