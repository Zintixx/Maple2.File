using System.Numerics;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Riding;

// ./data/xml/riding/passenger/%08d.xml
[XmlRoot("ms2")]
public partial class PassengerRidingRoot {
    [M2dFeatureLocale(Selector = "passengerid")] private IList<PassengerRiding> _ridepassenger;
}

public partial class PassengerRiding : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int passengerid;
    [XmlAttribute] public string rideBone = string.Empty;
    [M2dVector3] public Vector3 rideTranslation;
    [M2dVector3] public Vector3 rideRotation;
    [XmlAttribute] public string rideAniPC = string.Empty;
    [XmlAttribute] public string rideAniPC_Idle = string.Empty;
    [XmlAttribute] public string rideAniPC_Run = string.Empty;
    [XmlAttribute] public string rideAniPC_Jump = string.Empty;
    [XmlAttribute] public string rideAniPC_SP_Idle = string.Empty;
    [XmlAttribute] public string rideAniPC_SP_Run = string.Empty;
    [XmlAttribute] public string rideAniPC_SP_Jump = string.Empty;
    [XmlAttribute] public float nameTagOffsetY;
    [XmlAttribute] public float hpBarOffsetY;
    [XmlAttribute] public bool nameTagHide;
    [XmlAttribute] public bool useRidingNavi;
}
