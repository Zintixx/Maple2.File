using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/fishingspot.xml
[XmlRoot("ms2")]
public partial class FishingSpotRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<FishingSpot> _spot;
}

public partial class FishingSpot : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int minMastery;
    [XmlAttribute] public int maxMastery;
    [M2dArray] public string[] liquidType = Array.Empty<string>();
}
