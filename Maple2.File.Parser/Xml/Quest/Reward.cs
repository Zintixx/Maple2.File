using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Quest;

// Note acceptReward only uses slotTab & slotIndex + essentialItem & essentialJobItem
public partial class Reward {
    [XmlAttribute] public int money;
    [XmlAttribute] public int exp;
    [XmlAttribute] public int guildFund;
    [XmlAttribute] public int guildExp;
    [XmlAttribute] public int guildCoin;
    [XmlAttribute] public int menteeCoin;
    [XmlAttribute] public int missionPoint;
    [XmlAttribute] public int useMainFamePoint;
    [XmlAttribute] public int fameLog;
    [XmlAttribute] public int rewardExpExtra;
    [M2dEnum] public RelativeExp relativeExp = RelativeExp.unknown;
    [M2dEnum] public RelativeMeso relativeMeso = RelativeMeso.Unknown;
    [XmlAttribute] public long weddingExp;
    [XmlAttribute] public int karma;
    [XmlAttribute] public int lu;
    [XmlAttribute] public int slotTab = 4;
    [XmlAttribute] public int slotIndex;

    //[XmlElement] public List<Item> selectedItem; // Never set
    [XmlElement] public List<Item> essentialItem;
    [XmlElement] public List<Item> essentialJobItem;
    [XmlElement] public List<Item> globalEssentialItem; // Feature 149
    [XmlElement] public List<Item> globalEssentialJobItem; // Feature 149

    public class Item {
        [XmlAttribute] public int count;
        [XmlAttribute] public int code;
        [XmlAttribute] public int rank = 1;
        //[XmlAttribute] public int equip; // Never set
    }
}
