using System.Xml;
using System.Xml.Serialization;
using Maple2.File.Parser.MapXBlock;

namespace Maple2.File.Parser.Flat.Convert;

[XmlRoot("block")]
public class GameBlock {
    [XmlAttribute("version")] public int Version = 3;
    [XmlAttribute("name")] public string Name;

    [XmlElement("model-references")] public ModelReferences ModelReferences;
    [XmlElement("tool-settings")] public ToolSettings ToolSettings;

    [XmlElement("layers")] public Layers Layers;
    [XmlElement("entities")] public Entities Entities;
    [XmlElement("selections")] public Selections Selections;
    [XmlElement("entity-folders")] public EntityFolders EntityFolders;
}

public class ModelReferences {
    [XmlAttribute("version")] public int Version = 1;

    [XmlElement("reference")] public List<string> References;
}

public class ToolSettings {
    [XmlAttribute("version")] public int Version = 1;

    [XmlElement("setting")] public List<Setting> Settings;

    public class Setting {
        [XmlAttribute("id")] public string Id;
        [XmlAttribute("property-type")] public string PropertyType;

        [XmlElement("value")] public string Value;
    }
}

public class Layers {
    [XmlAttribute("version")] public int Version = 1;
}

public class Entities {
    [XmlAttribute("version")] public int Version = 1;

    [XmlElement("entity")] public List<Entity> EntityList;

    public class Entity {
        [XmlAttribute("id")] public string Id;
        [XmlAttribute("model-name")] public string ModelName;
        [XmlAttribute("model-id")] public string ModelId;
        [XmlAttribute("name")] public string Name;
        [XmlAttribute("iterations")] public int Iterations;
        [XmlAttribute("visible")] public bool Visible = true;
        [XmlAttribute("locked")] public bool Locked = false;

        [XmlElement("properties")] public Properties Properties;
    }
}

public class Properties {
    [XmlElement("property")] public List<Entity.Property> PropertyList;
}

public class Selections {
    [XmlAttribute("version")] public int Version = 1;
}

public class EntityFolders {
    [XmlAttribute("version")] public int Version = 1;
}
