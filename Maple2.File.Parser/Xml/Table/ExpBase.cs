using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/expbasetable.xml
[XmlRoot("ms2")]
public partial class ExpBaseRoot {
    [XmlElement] public List<ExpBaseTable> table;
}

public partial class ExpBaseTable {
    [XmlAttribute] public int expTableID;
    [XmlElement] public List<Base> @base;

    public partial class Base {
        [XmlAttribute] public int level;
        [XmlAttribute] public long exp;
    }
}
