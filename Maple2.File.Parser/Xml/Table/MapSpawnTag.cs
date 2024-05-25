using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/mapspawntag.xml
[XmlRoot("ms2")]
public partial class MapSpawnTag {
    [M2dFeatureLocale(Selector = "mapCode|spawnPointID")] private IList<Region> _region;

    public partial class Region : IFeatureLocale {
        [XmlAttribute] public int mapCode;
        [XmlAttribute] public int spawnPointID;
        [XmlAttribute] public int difficulty;
        [XmlAttribute] public int difficultyMin;
        [XmlAttribute] public int population;
        [XmlAttribute] public int coolTime;
        [M2dArray] public string[] tag;
        [XmlAttribute] public int petPopulation;
        [XmlAttribute] public int petSpawnProbability;
    }
}
