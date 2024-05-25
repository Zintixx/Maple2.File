using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Npc;

public partial class Skill {
    [M2dArray] public int[] ids = Array.Empty<int>();
    [M2dArray] public short[] levels = Array.Empty<short>();
    [M2dArray] public int[] priorities = Array.Empty<int>();
    [M2dArray] public int[] probs = Array.Empty<int>();
    [XmlAttribute] public int coolDown;
}
