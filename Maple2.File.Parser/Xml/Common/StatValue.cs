using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.Common;

[XmlType(Namespace = "Common")]
public class StatValue {
    [XmlAttribute] public long str;
    [XmlAttribute] public long dex;
    [XmlAttribute("int")] public long @int;
    [XmlAttribute] public long luk;
    [XmlAttribute] public long hp;
    [XmlAttribute] public long hp_rgp;
    [XmlAttribute] public long hp_inv;
    [XmlAttribute] public long sp;
    [XmlAttribute] public long sp_rgp;
    [XmlAttribute] public long sp_inv;
    [XmlAttribute] public long ep;
    [XmlAttribute] public long ep_rgp;
    [XmlAttribute] public long ep_inv;
    [XmlAttribute] public long asp;
    [XmlAttribute] public long msp;
    [XmlAttribute] public long atp;
    [XmlAttribute] public long evp;
    [XmlAttribute] public long cap;
    [XmlAttribute] public long cad;
    [XmlAttribute] public long car;
    [XmlAttribute] public long ndd;
    [XmlAttribute] public long abp;
    [XmlAttribute] public long jmp;
    [XmlAttribute] public long pap;
    [XmlAttribute] public long map;
    [XmlAttribute] public long par;
    [XmlAttribute] public long mar;
    [XmlAttribute] public long wapmin;
    [XmlAttribute] public long wapmax;

    [XmlAttribute] public long dmg;

    //[XmlAttribute] public long dmg;
    [XmlAttribute] public long pen;
    [XmlAttribute] public long rmsp;
    [XmlAttribute] public long bap;
    [XmlAttribute] public long bap_pet;

    public long this[byte i] => i switch {
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
        _ => throw new ArgumentOutOfRangeException(nameof(i), i, "Invalid StatValue index."),
    };
}
