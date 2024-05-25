using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemoptionpick.xml
[XmlRoot("ms2")]
public class ItemOptionPickRoot {
    [XmlElement] public List<ItemOptionPick> itemOptionPick;
}

public partial class ItemOptionPick {
    [XmlAttribute] public int optionPickID;
    [XmlAttribute] public int itemGrade;
    [M2dArray] public int[] randomPick = Array.Empty<int>();
    [M2dArray(KeepEmpty = true)] public string[] constant_value = Array.Empty<string>();
    [M2dArray(KeepEmpty = true)] public string[] constant_rate = Array.Empty<string>();
    [M2dArray(KeepEmpty = true)] public string[] static_value = Array.Empty<string>();
    [M2dArray(KeepEmpty = true)] public string[] static_rate = Array.Empty<string>();
    [M2dArray(KeepEmpty = true)] public string[] random_value = Array.Empty<string>();
    [M2dArray(KeepEmpty = true)] public string[] random_rate = Array.Empty<string>();
}
