using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/seasondata_arcade.xml
// ./data/xml/table/na/seasondata_bosscolosseum.xml
// ./data/xml/table/na/seasondata_darkstream.xml
// ./data/xml/table/na/seasondata_guildpvp.xml
// ./data/xml/table/na/seasondata_maplesurvival.xml
// ./data/xml/table/na/seasondata_maplesurvival_squad.xml
// ./data/xml/table/na/seasondata_pvp.xml
// ./data/xml/table/na/seasondata_ugcmapcommendation.xml
// ./data/xml/table/na/seasondata_worldchampion.xml
[XmlRoot("ms2")]
public class SeasonDataRoot {
    [XmlElement] public List<SeasonData> Season;
}

public partial class SeasonData {
    [XmlAttribute] public int seasonID;
    [XmlAttribute] public string seasonName = string.Empty;
    [XmlAttribute] public string eventStart = string.Empty;
    [XmlAttribute] public string eventEnd = string.Empty;
    [XmlAttribute] public int grade1;
    [XmlAttribute] public int grade2;
    [XmlAttribute] public int grade3;
    [XmlAttribute] public int grade4;
    [XmlAttribute] public int grade5;
    [XmlAttribute] public int grade6;
    [XmlAttribute] public int grade7;
}
