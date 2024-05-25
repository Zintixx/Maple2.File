using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/petproperty.xml
[XmlRoot("ms2")]
public partial class PetPropertyRoot {
    [M2dFeatureLocale(Selector = "code")] private IList<PetProperty> _pets;
}

public partial class PetProperty : IFeatureLocale {
    [XmlAttribute] public int type;
    [XmlAttribute] public int code;
    [XmlAttribute] public int slotNum;
    [XmlAttribute] public int collectGroupId;
    [XmlAttribute] public bool isCollectPreview;
    [XmlAttribute] public int tamingGroupID;
    [XmlAttribute] public bool enablePetExtraction;
    [XmlAttribute] public int npcID;
    [M2dArray] public int[] itemIDs = Array.Empty<int>();
    [M2dArray] public string[] tamingAiPresets = Array.Empty<string>();
    [XmlAttribute] public int passiveSkillId;
    [XmlAttribute] public short passiveSkillLevel;
    [XmlAttribute] public float warpDistance;
    [XmlAttribute] public float traceDistance;
    [XmlAttribute] public float battleTraceDistance;
    [XmlAttribute] public float nameTagOffsetY;
    [XmlAttribute] public short optionLevel;
    [XmlAttribute] public float constantOptionFactor;
    [M2dArray] public int[] additionalEffectID;
    [M2dArray] public short[] additionalEffectLevel = Array.Empty<short>();

    // useless data
    [XmlElement] public Skill skill;

    public class Skill {
        [XmlAttribute] public int id;
        [XmlAttribute] public short level;
    }
}
