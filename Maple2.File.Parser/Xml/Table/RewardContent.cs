using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/rewardcontent.xml
[XmlRoot("ms2")]
public partial class RewardContentRoot {
    [M2dFeatureLocale(Selector = "rewardID")] private IList<RewardContent> _v;
}

public partial class RewardContent : IFeatureLocale {
    [XmlAttribute] public int rewardID;
    [XmlAttribute] public int mesoTableID;
    [XmlAttribute] public float mesoFactor;
    [XmlAttribute] public int expTableID;
    [XmlAttribute] public float expFactor;
    [XmlAttribute] public int itemTableID;
    [XmlAttribute] public int adventureExpTableID;
}
