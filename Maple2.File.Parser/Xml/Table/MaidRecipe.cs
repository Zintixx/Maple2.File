using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/maidrecipe.xml
[XmlRoot("ms2")]
public partial class MaidRecipeRoot {
    [M2dFeatureLocale(Selector = "Id")] private IList<MaidRecipe> _recipe;
}

public partial class MaidRecipe : IFeatureLocale {
    [XmlAttribute] public int Id;
    [XmlAttribute] public string FirstIngredientItemID = string.Empty;
    [XmlAttribute] public int FirstIngredientCount;
    [XmlAttribute] public string SecondIngredientItemID = string.Empty;
    [XmlAttribute] public int SecondIngredientCount;
    [XmlAttribute] public string ThirdIngredientItemID = string.Empty;
    [XmlAttribute] public int ThirdIngredientCount;
    [XmlAttribute] public int WorkbenchType;
    [XmlAttribute] public int LeadTimeNormal;
    [XmlAttribute] public int LeadTimeGood;
    [XmlAttribute] public int LeadTimeVeryGood;
    [XmlAttribute] public int MaidExp;
    [XmlAttribute] public int MaidMood;
    [XmlAttribute] public int ProductItemID;
    [XmlAttribute] public int ProductsocketDataID;
    [XmlAttribute] public int ProductCount;
    [XmlAttribute] public int ProductRank;
}
