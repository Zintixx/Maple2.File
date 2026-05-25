using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/characterability.xml
[XmlRoot("ms2")]
public class CharacterAbilityRoot {
    [XmlElement] public List<CharacterAbility> ability;
}

public class CharacterAbility {
    [XmlAttribute] public int id;
    [XmlAttribute] public int categoryID;
    [XmlAttribute] public int requireLevel;
    [XmlAttribute] public int additionalEffectID;
    [XmlAttribute] public int additionalEffectLevel;
}
