using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// in New XML only
// ./data/xml/table/statstringtable.xml
// ./data/xml/table/specialabilitystringtable.xml
[XmlRoot("ms2")]
public class StatStringRoot {
    [XmlElement] public List<StatString> key;
}

public class StatString {
    [XmlAttribute] public int id;
    [XmlAttribute] public string option = string.Empty;
    [XmlAttribute] public int valueType;
    [XmlAttribute] public int commonStringID;
    [XmlAttribute] public int valueStringID;
    [XmlAttribute] public int rateStringID;
}
