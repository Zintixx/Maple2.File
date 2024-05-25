using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildevent.xml
[XmlRoot("ms2")]
public class GuildEventRoot {
    [XmlElement] public List<GuildEvent> guildEvent;
}

public partial class GuildEvent {
    [XmlAttribute] public int id;
    [XmlAttribute] public int mapCode;
    [XmlAttribute] public int maxUserCount;
    [XmlAttribute] public string imagePath = string.Empty;
}
