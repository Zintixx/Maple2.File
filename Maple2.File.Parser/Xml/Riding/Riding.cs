using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Xml.Common;

namespace Maple2.File.Parser.Xml.Riding;

// ./data/xml/riding/%08d.xml
[XmlRoot("ms2")]
public partial class RidingRoot {
    [M2dFeatureLocale] private Riding _riding;
}

public partial class Riding : IFeatureLocale {
    [XmlElement] public Basic basic = new();
    [XmlElement] public Collision collision = new();
    [XmlElement] public Capsule capsule = new();
    [XmlElement] public Shadow shadow = new();
    [XmlElement] public StatValue stat = new();
    [XmlElement] public FaceCamera faceCamera = new();
}

// KMS2: ./data/xml/riding/%08d.xml
[XmlRoot("ms2")]
public class RidingNewRoot {
    [XmlElement("riding")] public RidingNew riding;
}

public class RidingNew : Riding {
    [XmlElement("passengers")] public List<PassengerRiding> passengers = [];
}

