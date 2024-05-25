using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildproperty.xml
[XmlRoot("ms2")]
public partial class GuildPropertyRoot {
    [M2dFeatureLocale(Selector = "level")] private IList<GuildProperty> _property;
}

public partial class GuildProperty : IFeatureLocale {
    [XmlAttribute] public short level;
    [XmlAttribute] public int accumExp;
    [XmlAttribute] public byte capacity;
    [XmlAttribute] public long fundMax;
    [XmlAttribute] public int donationMax;
    [XmlAttribute] public int attendGuildExp;
    [XmlAttribute] public int winMiniGameGuildExp;
    [XmlAttribute] public int loseMiniGameGuildExp;
    [XmlAttribute] public int raidGuildExp;
    [XmlAttribute] public int attendGuildFund;
    [XmlAttribute] public int winMiniGameGuildFund;
    [XmlAttribute] public int loseMiniGameGuildFund;
    [XmlAttribute] public int raidGuildFund;
    [XmlAttribute] public float attendUserExpFactor;
    [XmlAttribute] public float donationUserExpFactor;
    [XmlAttribute] public int attendGuildCoin;
    [XmlAttribute] public int donateGuildCoin;
    [XmlAttribute] public int winMiniGameGuildCoin;
    [XmlAttribute] public int loseMiniGameGuildCoin;
}
