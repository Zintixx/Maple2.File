﻿using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Skill {
    public class ChangeSkill {
        [XmlIgnore] public int[] changeSkillCheckEffectID = Empty<int>();
        [XmlIgnore] public int[] changeSkillCheckEffectLevel = Empty<int>();
        [XmlIgnore] public int[] changeSkillCheckEffectOverlapCount = Empty<int>();
        [XmlIgnore] public int[] changeSkillID = Empty<int>();
        [XmlIgnore] public int[] changeSkillLevel = Empty<int>();
        [XmlAttribute] public int originSkillID;
        [XmlAttribute] public short originSkillLevel = 1;
        [XmlAttribute] public int autoChange;

        /* Custom Attribute Serializers */
        [XmlAttribute("changeSkillCheckEffectID")]
        public string _changeSkillCheckEffectID {
            get => Serialize.IntCsv(changeSkillCheckEffectID);
            set => changeSkillCheckEffectID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("changeSkillCheckEffectLevel")]
        public string _changeSkillCheckEffectLevel {
            get => Serialize.IntCsv(changeSkillCheckEffectLevel);
            set => changeSkillCheckEffectLevel = Deserialize.IntCsv(value);
        }

        [XmlAttribute("changeSkillCheckEffectOverlapCount")]
        public string _changeSkillCheckEffectOverlapCount {
            get => Serialize.IntCsv(changeSkillCheckEffectOverlapCount);
            set => changeSkillCheckEffectOverlapCount = Deserialize.IntCsv(value);
        }

        [XmlAttribute("changeSkillID")]
        public string _changeSkillID {
            get => Serialize.IntCsv(changeSkillID);
            set => changeSkillID = Deserialize.IntCsv(value);
        }

        [XmlAttribute("changeSkillLevel")]
        public string _changeSkillLevel {
            get => Serialize.IntCsv(changeSkillLevel);
            set => changeSkillLevel = Deserialize.IntCsv(value);
        }
    }
}