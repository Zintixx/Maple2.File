using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/dungeonrewardcoupon.xml
[XmlRoot("ms2")]
public class DungeonRewardCouponRoot {
    [XmlElement] public List<DungeonRewardCoupon> dungeonRewardCoupon;
}

public class DungeonRewardCoupon {
    [XmlAttribute] public int id;
    [XmlAttribute] public string ticketTag;
    [XmlAttribute] public int baseItemID;
    [XmlAttribute] public int maxExtraCount;
    [XmlElement] public List<DungeonRewardBaseRate> baseRate;
}

public class DungeonRewardBaseRate {
    [XmlAttribute] public int v;
}
