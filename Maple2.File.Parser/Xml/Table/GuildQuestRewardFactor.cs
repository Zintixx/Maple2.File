using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildquestrewardfactor.xml
[XmlRoot("ms2")]
public partial class GuildQuestRewardFactorRoot {
    [M2dFeatureLocale(Selector = "level")] private IList<GuildQuestRewardFactor> _guildNpc;
}

public partial class GuildQuestRewardFactor : IFeatureLocale {
    [XmlAttribute] public int level;
    [XmlAttribute] public float guildExpFactor;
    [XmlAttribute] public float userExpFactor;
    [XmlAttribute] public float guildFundFactor;
    [XmlAttribute] public float userMesoFactor;
    [XmlAttribute] public float GuildCoinFactor;
}
