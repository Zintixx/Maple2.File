using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/gacha_info.xml
[XmlRoot("ms2")]
public partial class GachaInfoRoot {
    [M2dFeatureLocale(Selector = "randomBoxID")] private IList<GachaInfo> _randomBox;
}

public partial class GachaInfo : IFeatureLocale {
    [XmlAttribute] public int randomBoxID;
    [XmlAttribute] public byte randomBoxGroup;
    [XmlAttribute] public byte randomBoxSeasonKR;
    [XmlAttribute] public byte randomBoxSeasonCN;
    [XmlAttribute] public byte randomBoxSeasonNA;
    [XmlAttribute] public byte randomBoxSeasonJP;
    [XmlAttribute] public byte seasonNumberOnIcon;
    [XmlAttribute] public string saleEndDate = string.Empty;
    [XmlAttribute] public byte ui;
    [XmlAttribute] public int individualDropBoxID;
    [XmlAttribute] public int shopID;
    [XmlAttribute] public int coinItemID;
    [XmlAttribute] public int coinItemAmount;
}
