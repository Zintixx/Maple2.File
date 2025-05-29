﻿using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Skill;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

// ./data/xml/additionaleffect/%08d.xml
[XmlRoot("ms2")]
public partial class AdditionalEffectLevelData {
    [M2dFeatureLocale(Selector = "BasicProperty.level")] private IList<AdditionalEffectData> _level;
}

public partial class AdditionalEffectData : IFeatureLocale {
    [XmlElement] public BeginCondition beginCondition;
    [XmlElement] public BasicProperty BasicProperty;
    [XmlElement] public MotionProperty MotionProperty;
    [XmlElement] public CancelEffectProperty CancelEffectProperty;
    [XmlElement] public ImmuneEffectProperty ImmuneEffectProperty;
    [XmlElement] public ResetSkillCoolDownTimeProperty ResetSkillCoolDownTimeProperty;
    [XmlElement] public ModifyEffectDurationProperty ModifyEffectDurationProperty;
    [XmlElement] public ModifyOverlapCountProperty ModifyOverlapCountProperty;
    [XmlElement] public StatusProperty StatusProperty;
    [XmlElement] public FinalStatusProperty FinalStatusProperty;
    [XmlElement] public OffensiveProperty OffensiveProperty;
    [XmlElement] public DefensiveProperty DefensiveProperty;
    [XmlElement] public RecoveryProperty RecoveryProperty;
    [XmlElement] public ExpProperty ExpProperty;
    [XmlElement] public DotDamageProperty DotDamageProperty;
    [XmlElement] public DotBuffProperty DotBuffProperty;
    [XmlElement] public ConsumeProperty ConsumeProperty;
    [XmlElement] public ReflectProperty ReflectProperty;
    [XmlElement] public UIProperty UIProperty;
    [XmlElement] public ShieldProperty ShieldProperty;
    [XmlElement] public MesoGuardProperty MesoGuardProperty;
    [XmlElement] public InvokeEffectProperty InvokeEffectProperty;
    [XmlElement] public SpecialEffectProperty SpecialEffectProperty;
    [XmlElement] public RideeProperty RideeProperty;

    [XmlElement] public List<TriggerSkill> splashSkill;
    [XmlElement] public List<TriggerSkill> conditionSkill;
}

// ./data/xml/additional/%03d.xml
[XmlRoot("ms2")]
public partial class AdditionalEffectDataRootNew {
    [XmlElement] public List<AdditionalEffectLevelDataNew> additional;
}

public partial class AdditionalEffectLevelDataNew {
    [XmlAttribute] public int id;
    //[XmlElement] public List<AdditionalEffectDataNew> level;
    [M2dFeatureLocale] private IList<AdditionalEffectDataNew> _level;
}

public partial class AdditionalEffectDataNew : IFeatureLocale {
//    [M2dArray] public string[] stringParam = Array.Empty<string>();
//    [XmlElement] public BeginCondition beginCondition;
   [XmlElement] public BasicProperty BasicProperty;
    /*[XmlElement] public MotionProperty MotionProperty;
    [XmlElement] public CancelEffectProperty CancelEffectProperty;
    [XmlElement] public ImmuneEffectProperty ImmuneEffectProperty;
    [XmlElement] public ResetSkillCoolDownTimeProperty ResetSkillCoolDownTimeProperty;
    [XmlElement] public ModifyEffectDurationProperty ModifyEffectDurationProperty;
    [XmlElement] public ModifyOverlapCountProperty ModifyOverlapCountProperty;
    [XmlElement] public StatusPropertyNew StatusProperty;
    [XmlElement] public StatNew Stat;
    [XmlElement] public SpecialAbilityNew SpecialAbility;
    [XmlElement] public FinalStatusProperty FinalStatusProperty;
    [XmlElement] public OffensiveProperty OffensiveProperty;
    [XmlElement] public DefensiveProperty DefensiveProperty;
    [XmlElement] public RecoveryProperty RecoveryProperty;
    [XmlElement] public ExpProperty ExpProperty;
    [XmlElement] public DotDamageProperty DotDamageProperty;
    [XmlElement] public DotBuffProperty DotBuffProperty;
    [XmlElement] public ConsumeProperty ConsumeProperty;
    [XmlElement] public ReflectProperty ReflectProperty;
    [XmlElement] public UIProperty UIProperty;
    [XmlElement] public ShieldProperty ShieldProperty;
    [XmlElement] public MesoGuardProperty MesoGuardProperty;
    [XmlElement] public InvokeEffectProperty InvokeEffectProperty;
    [XmlElement] public SpecialEffectProperty SpecialEffectProperty;
    [XmlElement] public RideeProperty RideeProperty;

    [XmlElement] public List<TriggerSkill> splashSkill;
    [XmlElement] public List<TriggerSkill> conditionSkill;*/
}
