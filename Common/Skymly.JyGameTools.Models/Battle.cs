using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skymly.JyGameTools.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "battle")]
    [XmlType(TypeName = "battle")]
    public class Battle
    {
        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "role")]
        [XmlType(TypeName = "role")]
        public class Role_Battle
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
            [XmlAttribute("x")]
            public string X { get; set; }
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlAttribute("level")]
            public string Level { get; set; }
            [XmlAttribute("animation")]
            public string Animation { get; set; }
            [XmlAttribute("boss")]
            public string Boss { get; set; }
        }

        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "roles")]
        [XmlType(TypeName = "roles")]
        public class Roles_Battle
        {
            [XmlElement("role")]
            public List<Role_Battle> Role { get; set; }
        }

        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "random")]
        [XmlType(TypeName = "random")]
        public class Random_Battle
        {
            [XmlElement("role")]
            public List<Role_Battle> Role { get; set; }
        }

        [XmlAttribute("music")]
        public string Music { get; set; }
        [XmlAttribute("must")]
        public string Must { get; set; }
        [XmlAttribute("key")]
        public string Key { get; set; }
        [XmlAttribute("mapkey")]
        public string Mapkey { get; set; }
        [XmlElement("roles")]
        public Role_Battle Roles { get; set; }
        [XmlElement("random")]
        public Role_Battle Random { get; set; }
    }
}


