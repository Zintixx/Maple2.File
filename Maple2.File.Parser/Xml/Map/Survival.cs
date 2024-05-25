using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Map;

public partial class Survival {
    [XmlAttribute] public short defaultMark;
    [XmlAttribute] public int defaultNameTag;

    // Ignored by client.
    [XmlAttribute] public int userDrop;
    [XmlAttribute] public int userAdditionalDrop;
    [XmlAttribute] public int userDropOwnership;
    [XmlAttribute] public int plusInven;
    [XmlAttribute] public int plusInven_Basic;
    [XmlAttribute] public int plusInven_Zero;
    [M2dArray] public int[] enteranceBuffIDs = Array.Empty<int>();
    [M2dArray] public short[] enteranceBuffLevels = Array.Empty<short>();
    [XmlAttribute] public bool ExtrafallDamage;
}
