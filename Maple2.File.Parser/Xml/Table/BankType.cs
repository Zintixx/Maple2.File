using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/banktype.xml
[XmlRoot("ms2")]
public class BankTypeRoot {
    [XmlElement] public List<BankType> bankType;
}

public partial class BankType {
    [XmlAttribute] public int id;
    [XmlAttribute] public bool useCash;
    [XmlAttribute] public int slotCount;
    [M2dArray] public int[] storeItemType = Array.Empty<int>();
}
