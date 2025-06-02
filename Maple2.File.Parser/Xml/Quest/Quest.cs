using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

// ./data/xml/quest/%08d.xml
[XmlRoot("ms2")]
public partial class QuestDataRootRoot {
    [M2dFeatureLocale] private QuestDataRoot _environment;
}

public partial class QuestDataRoot : IFeatureLocale {
    [XmlElement] public QuestData quest;
}

public partial class QuestData {
    [XmlElement] public Basic basic = new();
    [XmlElement] public Notify notify = new();
    [XmlElement] public Require require = new();

    [XmlElement] public List<Condition> condition = [];

    //[XmlElement] public Navigation navi;
    [XmlElement] public Start start = new();
    [XmlElement] public Complete complete = new();
    [XmlElement] public Reward completeReward = new();
    [XmlElement] public Reward acceptReward = new();
    [XmlElement] public ProgressMap progressMap = new();
    [XmlElement] public Guide guide = new();
    [XmlElement] public EventMission eventMission = new();
    [XmlElement] public MentoringMission mentoringMission = new(); // feature="Mentoring"
    [XmlElement] public Dispatch dispatch = new();
    [XmlElement] public GotoNpc gotoNpc = new();
    [XmlElement] public GotoDungeon gotoDungeon = new();
    [XmlElement] public Remote remoteAccept = new();
    [XmlElement] public Remote remoteComplete = new();
    [XmlElement] public SummonPortal summonPortal = new();

    public class Start {
        [XmlAttribute] public int npc;
    }

    public partial class Complete {
        [XmlAttribute] public int npc;
        [M2dEnum] public NavigationType type = NavigationType.unknown;

        //[M2dArray] public int[] code = Array.Empty<int>(); // Never set
        [M2dArray] public int[] map = Array.Empty<int>();

        // Ignored by client.
        [XmlAttribute] public int fieldID;
    }
}


[XmlRoot("ms2")]
public partial class QuestDataRootNew {
    [XmlElement("quest")] public List<QuestDataNew> quests = [];
}

public partial class QuestDataNew : QuestData, IFeatureLocale {
    [XmlAttribute] public int id;
}
