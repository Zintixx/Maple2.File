using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public partial class CancelEffectProperty {
    [XmlAttribute] public bool cancelCheckSameCaster;
    [XmlAttribute] public bool cancelPassiveEffect;
    [M2dArray] public int[] cancelEffectCodes = Array.Empty<int>();
    [M2dArray] public int[] cancelBuffCategories = Array.Empty<int>();
}
