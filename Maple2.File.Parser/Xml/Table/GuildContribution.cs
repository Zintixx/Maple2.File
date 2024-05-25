using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/guildcontribution.xml
[XmlRoot("ms2")]
public partial class GuildContributionRoot {
    [M2dFeatureLocale(Selector = "type")] private IList<GuildContribution> _contribution;
}

public partial class GuildContribution : IFeatureLocale {
    [M2dEnum] public GuildContributionType type;
    [XmlAttribute] public int value;
}
