using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/itemlapenshardupgrade.xml
[XmlRoot("ms2")]
public partial class ItemLapenshardUpgradeRoot {
    [M2dFeatureLocale(Selector = "ItemId|LapenLevel")] private IList<ItemLapenshardUpgrade> _key;
}

public partial class ItemLapenshardUpgrade : IFeatureLocale {
    [XmlAttribute] public int ItemId;
    [XmlAttribute] public short LapenLevel;
    [M2dArray] public int[] EquipPart;
    [XmlAttribute] public int LapenGroupID;
    [XmlAttribute] public int NextItemID;
    [XmlAttribute] public int GroupLapenshardMinCount;
    [XmlAttribute] public long meso;
    [M2dArray(Delimiter = ':')] public string[] IngredientItemID1;
    [XmlAttribute] public int IngredientCount1;
    [M2dArray(Delimiter = ':')] public string[] IngredientItemID2;
    [XmlAttribute] public int IngredientCount2;
    [M2dArray(Delimiter = ':')] public string[] IngredientItemID3;
    [XmlAttribute] public int IngredientCount3;
}
