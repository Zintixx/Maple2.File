using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/maidrecipegroup.xml
[XmlRoot("ms2")]
public class MaidRecipeGroupRoot {
    [XmlElement] public List<MaidRecipeGroup> group;
}

public partial class MaidRecipeGroup {
    [XmlAttribute] public int GroupID;
    [M2dArray] public int[] RecipeIDs;
    [M2dArray] public int[] RequireLevels;
}
