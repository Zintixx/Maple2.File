using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/famelog.xml
[XmlRoot("ms2")]
public class FameLogRoot {
    [XmlElement] public List<FameLog> fame;
}

public class FameLog {
    [XmlAttribute] public int id;
    [XmlAttribute] public string alliance = string.Empty;
    [XmlAttribute] public int grade;
}
