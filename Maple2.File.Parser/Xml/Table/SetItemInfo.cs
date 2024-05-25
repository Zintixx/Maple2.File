using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/setiteminfo.xml
[XmlRoot("ms2")]
public partial class SetItemInfoRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<SetItemInfo> _set;
}

public partial class SetItemInfo : IFeatureLocale {
    [XmlAttribute] public int id;
    [M2dArray] public int[] itemIDs;
    [XmlAttribute] public int optionID;
    [XmlAttribute] public bool showEffectIfItsSetItemMotion;
    [XmlAttribute] public bool isDisableTooltip;
}
