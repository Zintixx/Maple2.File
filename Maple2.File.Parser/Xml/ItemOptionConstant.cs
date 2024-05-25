using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml;

// ./data/xml/itemoption/constant/itemoptionconstant_%s.xml
[XmlRoot("ms2")]
public partial class ItemOptionConstantRoot {
    [M2dFeatureLocale(Selector = "code|grade")] private IList<ItemOptionConstantData> _option;
}

public partial class ItemOptionConstantData : ItemOption, IFeatureLocale {
    [XmlAttribute] public int code;
    [XmlAttribute] public int grade;

    [XmlAttribute] public float nddcalibrationfactor_rate_base;
    [XmlAttribute] public float wapcalibrationfactor_rate_base;
    [XmlAttribute] public float hpcalibrationfactor_rate_base;
    [XmlAttribute] public long hiddennddadd_value_base;
    [XmlAttribute] public long hiddenwapadd_value_base;
    [XmlAttribute] public long hiddenbapadd_value_base;
    [XmlAttribute] public long hiddenhpadd_value_base;

    [XmlAttribute] public int sgi_target;
}
