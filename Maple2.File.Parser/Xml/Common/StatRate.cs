using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Common;

[XmlType(Namespace = "Common")]
public class StatRate {
    [XmlAttribute] public float str;
    [XmlAttribute] public float dex;
    [XmlAttribute("int")] public float @int;
    [XmlAttribute] public float luk;
    [XmlAttribute] public float hp;
    [XmlAttribute] public float hp_rgp;
    [XmlAttribute] public float hp_inv;
    [XmlAttribute] public float sp;
    [XmlAttribute] public float sp_rgp;
    [XmlAttribute] public float sp_inv;
    [XmlAttribute] public float ep;
    [XmlAttribute] public float ep_rgp;
    [XmlAttribute] public float ep_inv;
    [XmlAttribute] public float asp;
    [XmlAttribute] public float msp;
    [XmlAttribute] public float atp;
    [XmlAttribute] public float evp;
    [XmlAttribute] public float cap;
    [XmlAttribute] public float cad;
    [XmlAttribute] public float car;
    [XmlAttribute] public float ndd;
    [XmlAttribute] public float abp;
    [XmlAttribute] public float jmp;
    [XmlAttribute] public float pap;
    [XmlAttribute] public float map;
    [XmlAttribute] public float par;
    [XmlAttribute] public float mar;
    [XmlAttribute] public float wapmin;
    [XmlAttribute] public float wapmax;

    [XmlAttribute] public float dmg;

    //[XmlAttribute] public float dmg;
    [XmlAttribute] public float pen;
    [XmlAttribute] public float rmsp;
    [XmlAttribute] public float bap;
    [XmlAttribute] public float bap_pet;

    public float this[byte i] => i switch {
        0 => str,
        1 => dex,
        2 => @int,
        3 => luk,
        4 => hp,
        5 => hp_rgp,
        6 => hp_inv,
        7 => sp,
        8 => sp_rgp,
        9 => sp_inv,
        10 => ep,
        11 => ep_rgp,
        12 => ep_inv,
        13 => asp,
        14 => msp,
        15 => atp,
        16 => evp,
        17 => cap,
        18 => cad,
        19 => car,
        20 => ndd,
        21 => abp,
        22 => jmp,
        23 => pap,
        24 => map,
        25 => par,
        26 => mar,
        27 => wapmin,
        28 => wapmax,
        29 => dmg,
        30 => dmg,
        31 => pen,
        32 => rmsp,
        33 => bap,
        34 => bap_pet,
        _ => throw new ArgumentOutOfRangeException(nameof(i), i, "Invalid StatRate index."),
    };
}
