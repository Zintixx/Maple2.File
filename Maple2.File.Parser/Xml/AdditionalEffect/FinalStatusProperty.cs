using System.Xml.Serialization;

namespace Maple2.File.Parser.Xml.AdditionalEffect;

public class FinalStatusProperty {
    [XmlElement] public FinalStat Stat;

    // Ignored by client.
    [XmlAttribute] public string value = string.Empty;
    [XmlAttribute] public string rate = string.Empty;
}

public class FinalStat {
    [XmlAttribute] public long finalstrvalue;
    [XmlAttribute] public long finaldexvalue;
    [XmlAttribute] public long finalintvalue;
    [XmlAttribute] public long finallukvalue;
    [XmlAttribute] public long finalhpvalue;
    [XmlAttribute] public long finalhp_rgpvalue;
    [XmlAttribute] public long finalhp_invvalue;
    [XmlAttribute] public long finalspvalue;
    [XmlAttribute] public long finalsp_rgpvalue;
    [XmlAttribute] public long finalsp_invvalue;
    [XmlAttribute] public long finalepvalue;
    [XmlAttribute] public long finalep_rgpvalue;
    [XmlAttribute] public long finalep_invvalue;
    [XmlAttribute] public long finalaspvalue;
    [XmlAttribute] public long finalmspvalue;
    [XmlAttribute] public long finalatpvalue;
    [XmlAttribute] public long finalevpvalue;
    [XmlAttribute] public long finalcapvalue;
    [XmlAttribute] public long finalcadvalue;
    [XmlAttribute] public long finalcarvalue;
    [XmlAttribute] public long finalnddvalue;
    [XmlAttribute] public long finalabpvalue;
    [XmlAttribute] public long finaljmpvalue;
    [XmlAttribute] public long finalpapvalue;
    [XmlAttribute] public long finalmapvalue;
    [XmlAttribute] public long finalparvalue;
    [XmlAttribute] public long finalmarvalue;
    [XmlAttribute] public long finalwapminvalue;
    [XmlAttribute] public long finalwapmaxvalue;

    [XmlAttribute] public long finaldmgvalue;

    //[XmlAttribute] public long finaldmgvalue;
    [XmlAttribute] public long finalpenvalue;
    [XmlAttribute] public long finalrmspvalue;
    [XmlAttribute] public long finalbapvalue;
    [XmlAttribute] public long finalbap_petvalue;

    [XmlAttribute] public float finalstrrate;
    [XmlAttribute] public float finaldexrate;
    [XmlAttribute] public float finalintrate;
    [XmlAttribute] public float finallukrate;
    [XmlAttribute] public float finalhprate;
    [XmlAttribute] public float finalhp_rgprate;
    [XmlAttribute] public float finalhp_invrate;
    [XmlAttribute] public float finalsprate;
    [XmlAttribute] public float finalsp_rgprate;
    [XmlAttribute] public float finalsp_invrate;
    [XmlAttribute] public float finaleprate;
    [XmlAttribute] public float finalep_rgprate;
    [XmlAttribute] public float finalep_invrate;
    [XmlAttribute] public float finalasprate;
    [XmlAttribute] public float finalmsprate;
    [XmlAttribute] public float finalatprate;
    [XmlAttribute] public float finalevprate;
    [XmlAttribute] public float finalcaprate;
    [XmlAttribute] public float finalcadrate;
    [XmlAttribute] public float finalcarrate;
    [XmlAttribute] public float finalnddrate;
    [XmlAttribute] public float finalabprate;
    [XmlAttribute] public float finaljmprate;
    [XmlAttribute] public float finalpaprate;
    [XmlAttribute] public float finalmaprate;
    [XmlAttribute] public float finalparrate;
    [XmlAttribute] public float finalmarrate;
    [XmlAttribute] public float finalwapminrate;
    [XmlAttribute] public float finalwapmaxrate;

    [XmlAttribute] public float finaldmgrate;

    //[XmlAttribute] public float finaldmgrate;
    [XmlAttribute] public float finalpenrate;
    [XmlAttribute] public float finalrmsprate;
    [XmlAttribute] public float finalbaprate;
    [XmlAttribute] public float finalbap_petrate;

    public long Value(byte i) {
        return i switch {
            0 => finalstrvalue,
            1 => finaldexvalue,
            2 => finalintvalue,
            3 => finallukvalue,
            4 => finalhpvalue,
            5 => finalhp_rgpvalue,
            6 => finalhp_invvalue,
            7 => finalspvalue,
            8 => finalsp_rgpvalue,
            9 => finalsp_invvalue,
            10 => finalepvalue,
            11 => finalep_rgpvalue,
            12 => finalep_invvalue,
            13 => finalaspvalue,
            14 => finalmspvalue,
            15 => finalatpvalue,
            16 => finalevpvalue,
            17 => finalcapvalue,
            18 => finalcadvalue,
            19 => finalcarvalue,
            20 => finalnddvalue,
            21 => finalabpvalue,
            22 => finaljmpvalue,
            23 => finalpapvalue,
            24 => finalmapvalue,
            25 => finalparvalue,
            26 => finalmarvalue,
            27 => finalwapminvalue,
            28 => finalwapmaxvalue,
            29 => finaldmgvalue,
            30 => finaldmgvalue,
            31 => finalpenvalue,
            32 => finalrmspvalue,
            33 => finalbapvalue,
            34 => finalbap_petvalue,
            _ => throw new ArgumentOutOfRangeException(nameof(i), i, "Invalid Final Stat value."),
        };
    }

    public float Rate(byte i) {
        return i switch {
            0 => finalstrrate,
            1 => finaldexrate,
            2 => finalintrate,
            3 => finallukrate,
            4 => finalhprate,
            5 => finalhp_rgprate,
            6 => finalhp_invrate,
            7 => finalsprate,
            8 => finalsp_rgprate,
            9 => finalsp_invrate,
            10 => finaleprate,
            11 => finalep_rgprate,
            12 => finalep_invrate,
            13 => finalasprate,
            14 => finalmsprate,
            15 => finalatprate,
            16 => finalevprate,
            17 => finalcaprate,
            18 => finalcadrate,
            19 => finalcarrate,
            20 => finalnddrate,
            21 => finalabprate,
            22 => finaljmprate,
            23 => finalpaprate,
            24 => finalmaprate,
            25 => finalparrate,
            26 => finalmarrate,
            27 => finalwapminrate,
            28 => finalwapmaxrate,
            29 => finaldmgrate,
            30 => finaldmgrate,
            31 => finalpenrate,
            32 => finalrmsprate,
            33 => finalbaprate,
            34 => finalbap_petrate,
            _ => throw new ArgumentOutOfRangeException(nameof(i), i, "Invalid Final Stat rate."),
        };
    }
}
