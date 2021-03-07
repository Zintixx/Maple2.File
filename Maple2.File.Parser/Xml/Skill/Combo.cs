﻿using System.Xml.Serialization;
using Maple2.File.Parser.Tools;
using static System.Array;

namespace Maple2.File.Parser.Xml.Skill {
    public class Combo {
        [XmlAttribute] public int comboSkill;
        [XmlAttribute] public int chargingSkill;
        [XmlAttribute] public int comboOriginSkill;
        [XmlAttribute] public int npcComboSkillID;
        [XmlAttribute] public short npcComboSkillLevel = 1;
        [XmlAttribute] public bool disableChargingAttackSkipFrame;
        [XmlIgnore] public int[] inputSkill = Empty<int>();
        [XmlIgnore] public int[] outputSkill = Empty<int>();

        /* Custom Attribute Serializers */
        [XmlAttribute("inputSkill")]
        public string _inputSkill {
            get => Serialize.IntCsv(inputSkill);
            set => inputSkill = Deserialize.IntCsv(value);
        }

        [XmlAttribute("outputSkill")]
        public string _outputSkill {
            get => Serialize.IntCsv(outputSkill);
            set => outputSkill = Deserialize.IntCsv(value);
        }
    }
}