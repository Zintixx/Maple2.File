using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/instrumentinfo.xml
[XmlRoot("ms2")]
public partial class InstrumentInfoRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<InstrumentInfo> _instrument;
}

public partial class InstrumentInfo : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int category;
    [XmlAttribute] public string asset = string.Empty;
    [XmlAttribute] public int equipItemId;
    [XmlAttribute] public int soloRelayScoreCount = 1;
    [XmlAttribute] public string readyEffect = string.Empty;
    [XmlAttribute] public string playEffect = string.Empty;
    [XmlAttribute] public bool isExpensive;
    [XmlAttribute] public string animationReady = string.Empty;
    [XmlAttribute] public string animationPlayIdle = string.Empty;
    [XmlAttribute] public string animationPlayLevel1 = string.Empty;
    [XmlAttribute] public string animationPlayLevel2 = string.Empty;
    [XmlAttribute] public string animationPlayLevel3 = string.Empty;
    [XmlAttribute] public string animationPlayLevel4 = string.Empty;
}
