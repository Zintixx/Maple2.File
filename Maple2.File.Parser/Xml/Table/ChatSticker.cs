using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/chatemoticon.xml
[XmlRoot("ms2")]
public partial class ChatStickerRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ChatSticker> _chatEmoticon;
}

public partial class ChatSticker : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int group_id;
    [XmlAttribute] public int category_id;
    [XmlAttribute] public string image_path = string.Empty;

    // Not present in xml.
    [XmlAttribute] public int height;
    [XmlAttribute] public int width;
    [XmlAttribute] public int vspace;
}
