using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Item;

public partial class Limit {
    [M2dEnum] public Gender genderLimit = Gender.All;
    [XmlAttribute] public short levelLimit = 1;
    [XmlAttribute] public short levelLimitMax;
    [XmlAttribute] public int transferType;
    [M2dNullable] public int? globalTransferType;
    [M2dNullable] public int? globalTransferTypeNA;
    [XmlAttribute] public int transferTypeVersion;
    [XmlAttribute] public bool shopSell;
    [XmlAttribute] public bool enableBreak;
    [XmlAttribute] public bool enableRegisterMeratMarket;
    [XmlAttribute] public bool exceptEnchant;
    [XmlAttribute] public bool vip;
    [XmlAttribute] public bool wedding;
    [XmlAttribute] public int tradeLimitRank = 4;
    [XmlAttribute] public int vipLevel;
    [XmlAttribute] public bool enableSocketTransfer = true;
    [M2dArray] public int[] jobLimit = Array.Empty<int>();
    [M2dArray] public int[] disableJobLimit = Array.Empty<int>();
    [M2dArray] public int[] recommendJobs = Array.Empty<int>();
}
