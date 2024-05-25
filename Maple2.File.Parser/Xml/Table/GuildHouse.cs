using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildhouse.xml
[XmlRoot("ms2")]
public partial class GuildHouseRoot {
    [M2dFeatureLocale(Selector = "level|theme")] private IList<GuildHouse> _guildHouse;
}

public partial class GuildHouse : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public byte theme;
    [XmlAttribute] public int fieldID;
    [XmlAttribute] public int upgradeReqGuildLevel;
    [XmlAttribute] public int upgradeCost;
    [XmlAttribute] public int rethemeCost;
    [XmlAttribute] public byte areaSize;
    [M2dArray] public int[] facility = Array.Empty<int>();
    [XmlAttribute] public int stringKey;
    [XmlAttribute] public string imagePath = string.Empty;
    [XmlAttribute] public string thumbnailPath = string.Empty;
}
