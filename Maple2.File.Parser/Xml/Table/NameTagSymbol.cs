using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/nametagsymbol.xml
[XmlRoot("ms2")]
public partial class NameTagSymbolRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<NameTagSymbol> _symbol;
}

public partial class NameTagSymbol : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string icon = string.Empty;
    [M2dEnum] public NameTagSymbolConditionType conditionType;
    [XmlAttribute] public int code;
    [XmlAttribute] public bool hideSymbol;
    [XmlAttribute] public bool pushSymbol;
    [XmlAttribute] public int buffID;
    [XmlAttribute] public short buffLv;
}
