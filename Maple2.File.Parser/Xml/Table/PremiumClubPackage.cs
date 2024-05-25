using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/vipgoodstable.xml
[XmlRoot("ms2")]
public partial class PremiumClubPackageRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<PremiumClubPackage> _goods;
}

public partial class PremiumClubPackage : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public bool disable;
    [XmlAttribute] public int displayOrder;
    [XmlAttribute] public string salesStartDate;
    [XmlAttribute] public string salesEndDate;
    [XmlAttribute] public long vipPeriod;
    [XmlAttribute] public long price;
    [XmlAttribute] public long salePrice;
    [XmlAttribute] public int saleTag;
    [XmlAttribute] public int buyLimit;
    [XmlAttribute] public int buyLimitResetType;
    [M2dEnum] public PremiumClubPriceType priceType = PremiumClubPriceType.BlueMeret;
    [M2dArray] public int[] bonusItemID = Array.Empty<int>();
    [M2dArray] public int[] bonusItemRank = Array.Empty<int>();
    [M2dArray] public int[] bonusItemCount = Array.Empty<int>();
    [M2dArray] public int[] bonusItemPeriod = Array.Empty<int>();
}
