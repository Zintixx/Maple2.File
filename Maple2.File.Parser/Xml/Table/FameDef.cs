using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/famedef.xml
[XmlRoot("ms2")]
public partial class FameDef {
    [M2dFeatureLocale(Selector = "name")] private IList<FameSeason> _season;
}

public partial class FameSeason : IFeatureLocale {
    [XmlAttribute] public string name = string.Empty;
    [XmlAttribute] public int requireQuest;
    [XmlAttribute] public int requireLv;
    [XmlAttribute] public string limitNpcScriptTag = string.Empty;
    [XmlElement] public List<Fame> fame;

    public class Fame {
        [XmlAttribute] public string alliance = string.Empty;
        [XmlAttribute] public int officerNpcKind;
        [XmlAttribute] public string symbol = string.Empty;
    }

}
