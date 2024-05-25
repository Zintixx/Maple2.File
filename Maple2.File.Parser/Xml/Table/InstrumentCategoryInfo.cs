using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/instrumentcategoryinfo.xml
[XmlRoot("ms2")]
public partial class InstrumentCategoryInfoRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<InstrumentCategoryInfo> _category;
}

public partial class InstrumentCategoryInfo : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int GMId;
    [XmlAttribute] public int percussionId;
    [XmlAttribute] public string icon = string.Empty;
    [XmlAttribute] public string defaultOctave = string.Empty;
}
