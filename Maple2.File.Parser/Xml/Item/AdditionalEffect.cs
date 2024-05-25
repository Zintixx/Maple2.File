using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Item;

public partial class AdditionalEffect {
    [M2dArray] public int[] id = Array.Empty<int>();
    [M2dArray] public short[] level = Array.Empty<short>();
    [XmlAttribute] public bool dropEffect;
}
