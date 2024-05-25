using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Script;

public class CinematicEventScript {
    [XmlAttribute] public int id;

    [XmlElement] public List<ScriptContent> content; // CScriptContent
}
