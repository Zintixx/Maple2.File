using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/fishingrod.xml
[XmlRoot("ms2")]
public partial class FishingRodRoot {
    [M2dFeatureLocale(Selector = "rodCode")] private IList<FishingRod> _rod;
}

public partial class FishingRod : IFeatureLocale {
    [XmlAttribute] public int rodCode;
    [XmlAttribute] public int itemCode;
    [XmlAttribute] public string chair = string.Empty;
    [XmlAttribute] public int fishMasteryLimit;
    [XmlAttribute] public int addFishMastery;
    [XmlAttribute] public int reduceFishingTime;
    [XmlAttribute] public string fishLureEffect = string.Empty;
    [XmlAttribute] public string fishingChairEffect = string.Empty;
}
