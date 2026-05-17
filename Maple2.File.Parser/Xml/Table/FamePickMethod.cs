using System.Xml.Serialization;
using M2dXmlGenerator;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/famepickmethod.xml
[XmlRoot("ms2")]
public partial class FamePickMethod {
    [M2dFeatureLocale] private IList<Environment> _environment;

    public partial class Environment : IFeatureLocale {
        [M2dFeatureLocale] private IList<PickMethod> _method;

    }

    public partial class PickMethod : IFeatureLocale {
        [XmlAttribute] public string type = string.Empty;
        [XmlAttribute] public int repeatType;
        [M2dArray] public int[] pickCountByRank = Array.Empty<int>();
        [XmlAttribute] public int reloadOnAccept;
        [XmlAttribute] public int reloadOnComplete;
        [XmlElement] public List<Alliance> _alliance;
    }

    public class Alliance {
        [XmlAttribute] public int id;
    }
}

