using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table.Server;

// ./data/server/table/Server/MaidRecipeSvr.xml
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
    [XmlAttribute] public int ProductItemID;
    [XmlAttribute] public int ProductsocketDataID;
    [XmlAttribute] public int ProductCount;
    [XmlAttribute] public int ProductRank;
    [XmlAttribute] public int JackpotItemID;
    [XmlAttribute] public int JackpotsocketDataID;
    [XmlAttribute] public int JackpotCount;
    [XmlAttribute] public int JackpotRank;
    [XmlAttribute] public float JackpotRate;
    [XmlAttribute] public int JackpotMood;
    [XmlAttribute] public int ImmediatelyCompleteFee;
}
