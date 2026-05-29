using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/maidexp.xml
[XmlRoot("ms2")]
public class MaidExpRoot {
    [XmlElement] public List<MaidExp> Exp;
}

public class MaidExp {
    [XmlAttribute] public int Level;
    [XmlAttribute] public int Exp;
}
