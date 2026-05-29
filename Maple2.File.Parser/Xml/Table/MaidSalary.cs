using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/maidsalary.xml
[XmlRoot("ms2")]
public class MaidSalaryRoot {
    [XmlElement] public List<MaidSalary> key;
}

public partial class MaidSalary {
    [XmlAttribute] public int id;
    [XmlAttribute] public int SalaryType;
    [XmlAttribute] public int SalaryAmount;
}
