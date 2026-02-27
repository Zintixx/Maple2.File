using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/pvprankingduelmode.xml
[XmlRoot("ms2")]
public class PvpRankingDuelModeRoot {
    [XmlElement] public List<PvpRankingDuelMode> gradeInfo;
}

public partial class PvpRankingDuelMode {
    [XmlAttribute] public int grade;
    [XmlAttribute] public int gradeRating;
    [XmlAttribute] public int winnerReward;
    [XmlAttribute] public int loserReward;
    [XmlAttribute] public int weeklyRewardMax;
    [XmlAttribute] public int winnerRating;
    [XmlAttribute] public int loserRating;
}
