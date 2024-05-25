using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/interactobject.xml
[XmlRoot("ms2")]
public partial class InteractObjectRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<InteractObject> _interact;
}

public partial class InteractObject : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int type;
    [XmlAttribute] public int collection;
    [XmlAttribute] public int reactCount;

    [XmlElement] public Mesh mesh;
    [XmlElement] public Ui ui;
    [XmlElement] public Gathering gathering;
    [XmlElement] public Validate validate;
    [XmlElement] public Quest quest;
    [XmlElement] public Item item;
    [XmlElement] public ConditionAdditionalEffect conditionAdditionalEffect;
    [XmlElement] public Time time;
    [XmlElement] public User user;
    [XmlElement] public Reward reward;
    [XmlElement] public Drop drop;
    [XmlElement] public Spawn spawn;
    [XmlElement] public Skill skill;
    [XmlElement] public AdditionalEffect additionalEffect;
    [XmlElement] public Effect effect;
    [XmlElement] public Room room;
    [XmlElement] public HomePrivilege homePrivilege;
    [XmlElement] public WebOpen webOpen;
    [XmlElement] public DisplayUrl displayURL;
    [XmlElement] public Display display;
    [XmlElement] public Arena arena;
    [XmlElement] public Portal portal;
    [XmlElement] public Guild guild;
    [XmlElement] public Weapon weapon;
    [XmlElement] public Mastery mastery;

    public partial class Mesh {
        [XmlAttribute] public int normalCollision = 1;
        [XmlAttribute] public int reactableCollision = 1;
        [XmlAttribute] public string reactObjectAni = string.Empty;
        [M2dVector3] public Vector3 shapeDimension = new(150f, 150f, 150f);
    }

    public class Ui {
        [XmlAttribute] public string swf = string.Empty;
        [XmlAttribute] public string value = string.Empty;
    }

    public class Gathering {
        [XmlAttribute] public int receipeID;
    }

    public class Validate {
        [XmlAttribute] public int fieldID;
        [XmlAttribute] public float interactionDistance;
    }

    public partial class Quest {
        [M2dArray(Delimiter = '|')] public string[] maskQuestID = Array.Empty<string>();    // split on '|' and ','
        [M2dArray(Delimiter = '|')] public string[] maskQuestState = Array.Empty<string>(); // split on '|' and ','
    }

    public class Item {
        [XmlAttribute] public int code;
        [XmlAttribute] public int rank;
        [XmlAttribute] public int consume;
        [XmlAttribute] public int checkCount;
    }

    public partial class ConditionAdditionalEffect {
        [M2dArray] public int[] id = Array.Empty<int>();
        [M2dArray] public short[] level = Array.Empty<short>();
    }

    public class Time {
        [XmlAttribute] public int resetTime;
        [XmlAttribute] public int reactTime;
        [XmlAttribute] public int hideTime;
    }

    public partial class User {
        [M2dArray] public string[] reactAni = Array.Empty<string>();
        [XmlAttribute] public string successAni;
        [XmlAttribute] public string failAni;
    }

    public partial class Reward {
        [XmlAttribute] public long exp;
        [M2dEnum] public ExpType firstExpType;
        [XmlAttribute] public float firstRelativeExpRate;
        [M2dEnum] public ExpType expType;
        [XmlAttribute] public float relativeExpRate;
    }

    public partial class Drop {
        [M2dArray] public int[] globalDropBoxId;
        [M2dArray] public int[] individualDropBoxId;
        [M2dEnum] public ObjectLevel objectLevel;
        [XmlAttribute] public int objectDropRank = 1;
        [XmlAttribute] public int dropHeight;
        [XmlAttribute] public int dropDistance;
    }

    public partial class Spawn {
        [M2dArray] public int[] code = Array.Empty<int>();
        [M2dArray] public int[] count = Array.Empty<int>();
        [M2dArray] public int[] radius = Array.Empty<int>();
        [M2dArray] public int[] prop = Array.Empty<int>();
        [M2dArray] public int[] lifeTime = Array.Empty<int>();
    }

    public class Skill {
        [XmlAttribute] public int code;
        [XmlAttribute] public short level;
        [XmlAttribute] public int friendly = -1;
        [XmlAttribute] public int count = 1;
        [XmlAttribute] public int interval;
        [XmlAttribute] public int prop = 10000;
    }

    public partial class AdditionalEffect {
        [XmlElement] public Modify modify;
        [XmlElement] public Invoke invoke;

        public class Modify {
            [XmlAttribute] public int code;
            [XmlAttribute] public int modifyTime;
        }

        public partial class Invoke {
            [M2dArray] public int[] code = Array.Empty<int>();
            [M2dArray] public short[] level = Array.Empty<short>();
            [M2dArray] public int[] prop = Array.Empty<int>();
        }
    }

    public partial class Effect {
        [XmlAttribute] public string normal = string.Empty;
        [XmlAttribute] public string reactable = string.Empty;
        [XmlAttribute] public string success = string.Empty;
        [XmlAttribute] public string interaction = string.Empty;

        [XmlElement] public Quest maskNormal;
        [XmlElement] public Quest maskReactable;
        [XmlElement] public Quest maskInteraction;
    }

    public class Room {
        [XmlAttribute] public int privateRoomID;
        [XmlAttribute] public int portalLifeTime;
        [XmlAttribute] public int partyPortal;
        [XmlAttribute] public int bossNpcID;
        [XmlAttribute] public int hideBossName;
    }

    public class HomePrivilege {
        [XmlAttribute] public int check;
    }

    public class WebOpen {
        [XmlAttribute] public int type = 1;
        [XmlAttribute] public string url = string.Empty;
    }

    public class DisplayUrl {
        [XmlAttribute] public int type;
        [XmlAttribute] public string indirectURL = string.Empty;
    }

    public class Display {
        [XmlAttribute] public string minimapIcon = string.Empty;
        [XmlAttribute] public bool notice;
    }

    public class Arena {
        [XmlAttribute] public int canInteractTeamId;
    }

    public class Portal {
        [XmlAttribute] public int targetPortalId;
    }

    public class Guild {
        [XmlAttribute] public int housePosterId;
    }

    public class Weapon {
        [XmlAttribute] public int weaponItemId;
    }

    public class Mastery {
        [XmlAttribute] public int type; // 3,4,5,6
        [XmlAttribute] public int value;
    }
}
