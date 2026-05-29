using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/maidproperty.xml
[XmlRoot("ms2")]
public class MaidPropertyRoot {
    [XmlElement] public List<MaidProperty> Property;
}

public class MaidProperty {
    [XmlAttribute] public int MaidID;
    [XmlAttribute] public int RecipeGroupID;
    [XmlAttribute] public int NPCID;
}
