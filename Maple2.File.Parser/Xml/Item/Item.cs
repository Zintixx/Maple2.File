using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

// ./data/xml/item/%01d/%02d/%08u.xml
[XmlRoot("ms2")]
public partial class ItemDataRoot {
    [M2dFeatureLocale] private ItemData _environment;
}

public partial class ItemData : IFeatureLocale {
    [XmlElement] public Basic basic = new();
    [XmlElement] public Slots slots = new();
    [XmlElement] public Customize customize = new();
    [XmlElement] public Mutation mutation = new();
    [XmlElement] public Cutting cutting = new();
    [XmlElement] public Install install = new();
    [XmlElement] public Property property = new();
    [XmlElement] public Material material = new();
    [XmlElement] public Life life = new();
    [XmlElement] public Limit limit = new();
    [XmlElement] public Skill skill = new();
    [XmlElement] public Skill objectWeaponSkill = new();
    [XmlElement] public Title title = new();
    [XmlElement] public Drop drop = new();
    [XmlElement] public UCC ucc = new();
    [XmlElement] public Effect effect = new();
    [XmlElement] public Fusion fusion = new();
    [XmlElement] public Pet pet = new();
    [XmlElement] public Ride ride = new();
    [XmlElement] public Badge gem = new();
    [XmlElement] public AdditionalEffect AdditionalEffect = new();
    [XmlElement] public Function function = new();
    [XmlElement] public Tool tool = new();
    [XmlElement] public Option option = new();
    [XmlElement] public Maid maid = new();
    [XmlElement] public PCBang PCBang = new();
    [XmlElement] public MusicScore MusicScore = new();
    [XmlElement] public Housing housing = new();
    [XmlElement] public Shop Shop = new();
}

// ./data/xml/itemdata/%03d.xml
[XmlRoot("ms2")]
public partial class ItemDataNew {
    [XmlElement] public List<ItemDataRootNew> item;
}

public partial class ItemDataRootNew {
    [XmlAttribute] public int id;
    [M2dFeatureLocale] private ItemData _environment;
}

public partial class ItemDataNew : IFeatureLocale {
    [XmlElement] public Basic basic = new();
    [XmlElement] public Slots slots = new();
    [XmlElement] public Customize customize = new();
    [XmlElement] public Mutation mutation = new();
    [XmlElement] public Cutting cutting = new();
    [XmlElement] public Install install = new();
    [XmlElement] public Property property = new();
    [XmlElement] public Material material = new();
    [XmlElement] public Life life = new();
    [XmlElement] public Limit limit = new();
    [XmlElement] public Skill skill = new();
    [XmlElement] public Skill objectWeaponSkill = new();
    [XmlElement] public Title title = new();
    [XmlElement] public Drop drop = new();
    [XmlElement] public UCC ucc = new();
    [XmlElement] public Effect effect = new();
    [XmlElement] public Fusion fusion = new();
    [XmlElement] public Pet pet = new();
    [XmlElement] public Ride ride = new();
    [XmlElement] public Badge gem = new();
    [XmlElement] public AdditionalEffect AdditionalEffect = new();
    [XmlElement] public Function function = new();
    [XmlElement] public Tool tool = new();
    [XmlElement] public Option option = new();
    [XmlElement] public Maid maid = new();
    [XmlElement] public PCBang PCBang = new();
    [XmlElement] public MusicScore MusicScore = new();
    [XmlElement] public Housing housing = new();
    [XmlElement] public Shop Shop = new();
}
