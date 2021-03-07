﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Maple2.File.Parser.Xml.Skill;
using Maple2.File.Parser.Xml.Skill.Property;

// ./data/xml/skill/%02d/%08u.xml
namespace Maple2.File.Parser.Xml {
    [XmlRoot("ms2")]
    public class SkillData {
        [XmlAttribute] public string feature = string.Empty;

        [XmlElement] public List<Basic> basic;
        [XmlElement] public List<SkillLevelData> level;
    }

    public class SkillLevelData {
        [XmlAttribute] public string feature = string.Empty;
        [XmlAttribute] public short value;

        [XmlElement] public BeginCondition beginCondition;
        [XmlElement] public ChangeSkill changeSkill;
        [XmlElement] public MagicControl magicControl;
        [XmlElement] public AutoTargeting autoTargeting;
        [XmlElement] public Push push;
        [XmlElement] public Consume consume;
        [XmlElement] public TargetItem targetItem;
        [XmlElement] public Upgrade upgrade;
        [XmlElement] public RegionSkill detectProperty;
        [XmlElement] public RegionSkill sensorProperty;
        [XmlElement] public SplashManualActiveProperty splashManualActiveProperty;
        [XmlElement] public SkillGlideData glideProperty;
        [XmlElement] public Combo combo;
        [XmlElement] public RecoveryProperty recoveryProperty;
        [XmlElement] public List<TriggerSkill> conditionSkill;
        [XmlElement] public List<SkillMotionData> motion;
    }

    public class SkillGlideData {
        [XmlAttribute] public float gravity;
        [XmlAttribute] public float heightLimit;
        [XmlAttribute] public float horizontalAccelerate;
        [XmlAttribute] public float horizontalVelocity;
        [XmlAttribute] public float verticalAccelerate;
        [XmlAttribute] public float verticalVelocity;
        [XmlAttribute] public float verticalVibrateAmplitude;
        [XmlAttribute] public float verticalVibrateFrequency;
        [XmlAttribute] public float glideVerticalAccelerateLimit;
        [XmlAttribute] public float glideHorizontalAccelerateLimit;
        [XmlAttribute] public bool bEffect;
        [XmlAttribute] public string effectRun = string.Empty;
        [XmlAttribute] public string effectIdle = string.Empty;
        [XmlAttribute] public string aniIdle = string.Empty;
        [XmlAttribute] public string aniLeft = string.Empty;
        [XmlAttribute] public string aniRight = string.Empty;
        [XmlAttribute] public string aniRun = string.Empty;
        [XmlAttribute] public bool onGroundDisable;
    }
}