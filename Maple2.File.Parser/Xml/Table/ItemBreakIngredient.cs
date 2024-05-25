using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itembreakingredient.xml
[XmlRoot("ms2")]
public partial class ItemBreakIngredientRoot {
    [M2dFeatureLocale(Selector = "ItemID")] private IList<ItemBreakIngredient> _item;
}

public partial class ItemBreakIngredient : IFeatureLocale {
    [XmlAttribute] public int ItemID;
    [XmlAttribute] public int IngredientItemID1;
    [XmlAttribute] public int IngredientCount1;
    [XmlAttribute] public int IngredientItemID2;
    [XmlAttribute] public int IngredientCount2;
    [XmlAttribute] public int IngredientItemID3;
    [XmlAttribute] public int IngredientCount3;
}
