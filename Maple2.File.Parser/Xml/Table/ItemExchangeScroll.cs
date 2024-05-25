using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.Parser.Enum;

namespace Maple2.File.Parser.Xml.Table;

// ./data/xml/table/itemexchangescrolltable.xml
[XmlRoot("ms2")]
public partial class ItemExchangeScrollRoot {
    [M2dFeatureLocale(Selector = "id")] private IList<ItemExchangeScroll> _exchange;
}

public partial class ItemExchangeScroll : IFeatureLocale {
    [XmlAttribute] public int id;
    [XmlAttribute] public int maxGrade;
    [XmlAttribute] public int tradableCountDeduction;

    [M2dEnum] public ItemExchangeScrollType type;
    [XmlElement] public Ingredient receipe;
    [XmlElement] public Ingredient requireEquip;
    [XmlElement] public Ingredient exchange;
    [XmlElement] public Require require;

    public class Ingredient {
        [XmlAttribute] public int id;
        [XmlAttribute] public int rank;
        [XmlAttribute] public int count;
    }

    public partial class Require {
        [XmlAttribute] public long meso;
        [XmlElement] public List<Item> item;
    }

    public partial class Item {
        [M2dArray] public string[] id = Array.Empty<string>();
    }
}
