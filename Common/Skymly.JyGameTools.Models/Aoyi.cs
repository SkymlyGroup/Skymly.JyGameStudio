using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skymly.JyGameTools.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "aoyi")]
    [XmlType(TypeName = "aoyi")]
    public class Aoyi
    {
        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "condition")]
        [XmlType(TypeName = "condition")]
        public class Condition_Aoyi
        {
            [XmlAttribute("level")]
            public string Level { get; set; }

            [XmlAttribute("value")]
            public string Value { get; set; }

            [XmlAttribute("type")]
            public string Type { get; set; }
        }

        [XmlAttribute("start")]
        public string Start { get; set; }

        [XmlAttribute("buff")]
        public string Buff { get; set; }

        [XmlAttribute("animation")]
        public string Animation { get; set; }

        [XmlAttribute("probability")]
        public string Probability { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("level")]
        public string Level { get; set; }

        [XmlElement("condition")]
        public List<Condition_Aoyi> Conditions { get; set; }

        [XmlAttribute("addPower")]
        public string PowerAdd { get; set; }
    }
}
