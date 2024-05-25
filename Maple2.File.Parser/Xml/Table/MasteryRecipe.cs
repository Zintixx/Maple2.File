using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/masteryreceipe.xml
[XmlRoot("ms2")]
public partial class MasteryRecipeRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<MasteryRecipe> _receipe;
}

public partial class MasteryRecipe : IFeatureLocale {
    [XmlAttribute] public int id;
    [M2dEnum] public MasteryType masteryType;
    [XmlAttribute] public bool exceptRewardExp;
    [XmlAttribute] public int requireMastery;
    [XmlAttribute] public long requireMeso;
    [M2dArray] public int[] requireQuest = Array.Empty<int>();
    [XmlAttribute] public short requireLevel;
    [XmlAttribute] public long rewardExp;
    [XmlAttribute] public int rewardMastery;
    [XmlAttribute] public int gatheringTime;
    [XmlAttribute] public int highPropLimitCount;
    [XmlAttribute] public int normalPropLimitCount;
    [M2dArray] public string[] requireItem1 = Array.Empty<string>();
    [M2dArray] public string[] requireItem2 = Array.Empty<string>();
    [M2dArray] public string[] requireItem3 = Array.Empty<string>();
    [M2dArray] public string[] requireItem4 = Array.Empty<string>();
    [M2dArray] public string[] requireItem5 = Array.Empty<string>();
    [M2dArray] public int[] habitatMapId = Array.Empty<int>();
    [M2dArray] public int[] rewardItem1 = Array.Empty<int>();
    [M2dArray] public int[] rewardItem2 = Array.Empty<int>();
    [M2dArray] public int[] rewardItem3 = Array.Empty<int>();
    [M2dArray] public int[] rewardItem4 = Array.Empty<int>();
    [M2dArray] public int[] rewardItem5 = Array.Empty<int>();
}
