using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/meratmarketcategory.xml
[XmlRoot("ms2")]
public partial class MeretMarketCategoryRoot {
    [XmlElement] public List<MeretMarketCategory> category;
    [M2dFeatureLocale] private IList<MeretMarketEnvironment> _environment;
}

public partial class MeretMarketCategory {
    [XmlAttribute] public int id;
    [XmlAttribute] public string tabType = string.Empty;
    [XmlElement] public List<Tab> tab;

    public partial class Tab {
        [XmlAttribute] public string name = string.Empty;
        [XmlAttribute] public int id;
        [XmlAttribute] public string symbol = string.Empty;
        [M2dArray] public string[] category = Array.Empty<string>();
        [XmlAttribute] public byte priority;
        [XmlAttribute] public byte @static;
        [XmlAttribute] public bool sortGender;
        [XmlAttribute] public bool sortJob;
        [XmlAttribute] public bool alwaysOpen;
        [XmlElement] public List<Tab> tab;
    }
}

public partial class MeretMarketEnvironment : IFeatureLocale {
    [XmlElement] public List<MeretMarketCategory> category;
}
