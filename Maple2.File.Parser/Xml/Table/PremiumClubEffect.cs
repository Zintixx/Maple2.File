using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/vipbenefiteffecttable.xml
[XmlRoot("ms2")]
public partial class PremiumClubEffectRoot {
    [M2dFeatureLocale(Selector = "effectID|effectLevel")] private IList<PremiumClubEffect> _benefit;
}

public partial class PremiumClubEffect : IFeatureLocale {
    [XmlAttribute] public int effectID;
    [XmlAttribute] public short effectLevel;
}
