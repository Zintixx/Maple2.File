using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

public partial class MonologueScript : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public string tag; // "limitFameGrade"

    [XmlAttribute] public int popupProp;
    [XmlAttribute] public int popupState;

    [XmlElement] public List<ScriptContent> content; // CChatballonContent
}
