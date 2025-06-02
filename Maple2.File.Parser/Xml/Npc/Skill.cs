using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Skill {
    [M2dArray] public int[] ids = [];
    [M2dArray] public short[] levels = [];
    [M2dArray] public int[] priorities = [];
    [M2dArray] public int[] probs = [];
    [XmlAttribute] public int coolDown;
}
