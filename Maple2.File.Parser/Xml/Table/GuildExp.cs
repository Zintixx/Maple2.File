using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildexp.xml
[XmlRoot("ms2")]
public class GuildExpRoot {
    [XmlElement] public List<GuildExp> guildExp;
}

public partial class GuildExp {
    [XmlAttribute] public int level;
    [XmlAttribute] public int value;
}
