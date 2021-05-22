using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skymly.JyGameTools.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "trigger")]
    [XmlType(TypeName = "trigger")]
    public class GlobalTrigger
    {
        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "condition")]
        [XmlType(TypeName = "condition")]
        public class Condition_GlobalTrigger
        {
            [XmlAttribute("value")]
            public string Value { get; set; }
            [XmlAttribute("type")]
            public string Type { get; set; }
        }
        [XmlAttribute("story")]
        public string Story { get; set; }
        [XmlElement("condition")]
        public List<Condition_GlobalTrigger> Conditions { get; set; }
    }
}


