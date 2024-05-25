using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemsocket.xml
[XmlRoot("ms2")]
public partial class ItemSocketRoot {
    [M2dFeatureLocale(Selector = "id|grade")] private IList<ItemSocket> _itemSocket;
}

public partial class ItemSocket : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int grade;
    [XmlAttribute] public byte maxCount;
    [XmlAttribute] public int openType;
    [M2dArray] public int[] randomOpenRange = Array.Empty<int>();
    [XmlAttribute] public byte fixOpenCount;
}
