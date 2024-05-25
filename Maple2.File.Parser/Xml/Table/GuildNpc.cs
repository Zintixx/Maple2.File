using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildnpc.xml
[XmlRoot("ms2")]
public partial class GuildNpcRoot {
    [M2dFeatureLocale(Selector = "type|level")] private IList<GuildNpc> _npc;
}

public partial class GuildNpc : IFeatureLocale {
    [M2dEnum] public GuildNpcType type;
    [XmlAttribute] public short level;
    [XmlAttribute] public int upgradeCost;
    [XmlAttribute] public int requireGuildLevel;
    [XmlAttribute] public int requireHouseLevel;
    [XmlAttribute] public string stringKey;
}
