using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Script;

public class ScriptContent {
    [XmlAttribute] public string text = string.Empty;
    [XmlAttribute] public string voiceID = string.Empty;
    [XmlAttribute] public string illust = string.Empty;
}

public class CinematicContent : ScriptContent {
    [XmlAttribute] public int buttonSet;
    [XmlAttribute] public bool openTalkReward;
    [XmlAttribute] public int functionID;
    [XmlAttribute] public int otherNpcTalk;
    [XmlAttribute] public string leftIllust = string.Empty;
    [XmlAttribute] public string rightIllust = string.Empty;
    [XmlAttribute] public string speakerIllust = string.Empty;
    [XmlAttribute] public int speakerNpc;
    [XmlAttribute] public string imagePlate = string.Empty;
    [XmlAttribute] public int myTalk;
    [XmlAttribute] public string movie = string.Empty;
    [XmlAttribute] public int redirect;
    [XmlAttribute] public string screenEffectMovie = string.Empty;
    [XmlAttribute] public string screenEffectAction = string.Empty;
    [XmlAttribute] public int screenEffectValue;

    [XmlElement] public List<CinematicDistractor> distractor;
    [XmlElement("event")] public List<CinematicEventScript> @event;
}
