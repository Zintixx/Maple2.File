using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml.Skill;

public partial class BeginCondition {
    [XmlAttribute] public short level = 1;
    [XmlAttribute] public long money;
    [M2dEnum] public Gender gender = Gender.All;
    [XmlAttribute] public bool target;
    [XmlAttribute] public float probability = 1.0f;
    [XmlAttribute] public float invokeEffectFactor = 1.0f;
    [XmlAttribute] public float cooldownTime;
    [XmlAttribute] public float defaultRechardingCooldownTime;
    [XmlAttribute] public bool useCoolDownShowUI;
    [XmlAttribute] public bool allowDeadState; // 0,1
    [XmlAttribute] public float requireDurationWithoutDamage;
    [XmlAttribute] public float requireDurationWithoutMove;
    [XmlAttribute] public bool useTargetCountFactor; // 0
    [XmlAttribute] public bool onlyShadowWorld;
    [XmlAttribute] public bool onlyFlyableMap;
    [XmlAttribute] public int applyPvPZoneType; // 0,1,2
    [XmlAttribute] public bool allowBattleRidingState;
    [XmlAttribute] public bool onlyBattleRidingState;
    [XmlAttribute] public bool allowMapleSurvival;

    [XmlElement] public List<Job> job; // 1,10,20,30,40,50,60,70,80,90,100,110 | 330
    [XmlElement] public List<MapCodes> requireMapCodes;
    [XmlElement] public List<DungeonRoomGroupTypes> requireDungeonRoomGroupTypes;
    [XmlElement] public StatValue stat;
    [XmlElement] public List<Item> item;
    [XmlElement] public List<Weapon> weapon;
    [XmlElement("owner")] public SubConditionTarget skillOwner;
    [XmlElement("caster")] public SubConditionTarget skillCaster;
    [XmlElement("target")] public SubConditionTarget skillTarget;

    // Skill ONLY
    [XmlElement] public List<Effect> requireEffect;
    [XmlElement] public List<SkillElement> requireSkillElement;
    [XmlElement] public List<HasNotAdditionalEffectGroup> hasNotAdditionalEffectGroup; // 10,11
    [XmlElement] public List<AchieveCodes> requireAchieveCodes;
    [XmlElement] public List<AchieveGrades> requireAchieveGrades; // 1,2,4,6

    // AdditionalEffect ONLY
    [XmlElement] public List<MapCategoryCodes> requireMapCategoryCodes; // 9
    [XmlElement] public List<MapContinentCodes> requireMapContinentCodes; // 202
    [XmlElement] public List<SkillCodes> requireSkillCodes;

    // Ignored by client.
    [XmlAttribute] public float defaultRechargingCooldownTime;
    [XmlAttribute] public bool isShadowWorld;
    [XmlAttribute] public bool glideOnGroundDisable;

    public class Job {
        [XmlAttribute] public int code;
    }

    public class Effect {
        [XmlAttribute] public int code;
    }

    public class SkillElement {
        [XmlAttribute] public int element;
    }

    public class MapCodes {
        [XmlAttribute] public int code;
    }

    public class MapCategoryCodes {
        [XmlAttribute] public int code;
    }

    public class MapContinentCodes {
        [XmlAttribute] public int code;
    }

    public class DungeonRoomGroupTypes {
        [XmlAttribute] public string type = string.Empty;
    }

    public class SkillCodes {
        [XmlAttribute] public int code;
    }

    public class HasNotAdditionalEffectGroup {
        [XmlAttribute] public int id;
    }

    public class AchieveCodes {
        [XmlAttribute] public int id;
    }

    public class AchieveGrades {
        [XmlAttribute] public int grade;
    }

    public class Item {
        [XmlAttribute] public int id;
        [XmlAttribute] public int count;
        [XmlAttribute] public int rank;
    }

    public class Weapon {
        [XmlAttribute] public int lh;
        [XmlAttribute] public int rh;
    }
}
