using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Skymly.JyGameStudio.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false)]
    [XmlType(TypeName = "battle")]
    public class Battle
    {

        [XmlAttribute("music")]
        public string Music { get; set; } = "";

        [XmlAttribute("must")]
        public string Must { get; set; } = "";

        [XmlAttribute("key")]
        public string Key { get; set; } = "";


        [XmlAttribute("mapkey")]
        public string Mapkey { get; set; } = "";

        [XmlIgnore]
        public List<BattleRole> Friends => Roles.Where(v => v.Team == "1").ToList();

        [XmlIgnore]
        public List<BattleRole> Enemies => Roles.Where(v => v.Team == "2").ToList();

        [XmlArray(ElementName = "roles")]
        [XmlArrayItem(ElementName = "role")]
        public List<BattleRole> Roles { get; set; } = new();

        [XmlArray(ElementName = "random")]
        [XmlArrayItem(ElementName = "role")]
        public List<BattleRole> Randoms { get; set; } = new();


        [Serializable]
        [XmlRoot("root", IsNullable = false)]
        [XmlType(TypeName = "role")]
        public class BattleRole
        {
            [XmlAttribute("y")]
            public string Y { get; set; }

            [XmlAttribute("face")]
            public string Face { get; set; }


            [XmlAttribute("team")]
            public string Team { get; set; }

            [XmlAttribute("key")]
            public string Key { get; set; }

            [XmlAttribute("index")]
            public string Index { get; set; }


            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("level")]
            public string Level { get; set; }

            [XmlAttribute("x")]
            public string X { get; set; }

            [XmlAttribute("boss")]
            public bool IsBoss { get; set; }

            [XmlAttribute("animation")]
            public string Animation { get; set; }

            [XmlIgnore]
            public bool IsBossSpecified { get => this.IsBoss; }

            [XmlIgnore]
            public bool KeySpecified { get => !string.IsNullOrWhiteSpace(Team) || !string.IsNullOrWhiteSpace(Key); }


        }
    }
}


