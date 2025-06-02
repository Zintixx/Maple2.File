using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

// ./data/xml/npc/%02d/%08d.xml
[XmlRoot("ms2")]
public partial class NpcDataRoot {
    [M2dFeatureLocale] private NpcData _environment;
    [XmlElement] public List<EffectDummy> effectdummy;
}

public partial class NpcData : IFeatureLocale {
    [XmlElement] public Model model = new();
    [XmlElement] public Basic basic = new();
    [XmlElement] public Stat stat = new();
    [XmlElement] public Speed speed = new();
    [XmlElement] public Distance distance = new();
    [XmlElement] public Crystals crystals = new();
    [XmlElement] public Skill skill = new();
    [XmlElement] public AdditionalEffect additionalEffect = new();
    [XmlElement] public Interact interact = new();
    [XmlElement] public Combat combat = new(); // Ignored by client.
    [XmlElement] public Assist assist = new();
    [XmlElement] public AiInfo aiInfo = new();
    [XmlElement] public Collision collision = new();
    [XmlElement] public NodeCollisions nodeCollisions = new();
    [XmlElement] public NodeServerCollisions nodeServerCollisions = new();
    [XmlElement] public Capsule capsule = new();
    [XmlElement] public ValidBattleCylinder validBattleCylinder = new();
    [XmlElement] public Dead dead = new();
    [XmlElement] public Push push = new();
    [XmlElement] public Exp exp = new();
    [XmlElement] public Shadow shadow = new();
    [XmlElement] public Normal normal = new();
    [XmlElement] public DropItemInfo dropiteminfo = new();
    [XmlElement] public LookAtTarget lookattarget = new();
    [XmlElement] public Corpse corpse = new();
    [XmlElement] public Ride ride = new(); // Ignored by client.
}

[XmlRoot("ms2")]
public partial class NpcDataListNew {
    [XmlElement("npc")] public List<NpcDataRootNew> npcs = [];
}

public partial class NpcDataRootNew {
    [XmlAttribute] public int id;
    [XmlElement] public NpcDataNew environment = new();
}

public partial class NpcDataNew : NpcData {
    [XmlElement] public List<EffectDummy> effectdummy = [];
}
