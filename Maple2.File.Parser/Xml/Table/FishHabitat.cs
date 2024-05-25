using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/na/fishhabitat.xml
[XmlRoot("ms2")]
public partial class FishHabitatRoot {
    [XmlElement] public List<FishHabitat> fish;
}

public partial class FishHabitat {
    [XmlAttribute] public int id;
    [M2dArray] public int[] habitat = Array.Empty<int>();
}
