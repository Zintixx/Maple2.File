﻿using System.Collections.Generic;
using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Script;

// ./data/xml/script/npc/%08d.xml
[XmlRoot("ms2")]
public partial class NpcScript {
    [M2dFeatureLocale] private IList<TalkScript> _select;
    [M2dFeatureLocale] private TalkScript _job;
    [M2dFeatureLocale] private IList<TalkScript> _monologue;
    [M2dFeatureLocale] private IList<TalkScript> _script;
}