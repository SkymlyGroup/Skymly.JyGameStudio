using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Skymly.JyGameStudio.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "aoyi")]
    [XmlType(TypeName = "aoyi")]
    [Table(nameof(Aoyi))]
    public class Aoyi
    {

        [Key]
        [XmlIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

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

        //[NotMapped]
        [XmlElement("condition")]
        public List<AoyiCondition> AoyiConditions { get; set; }

        [XmlAttribute("addPower")]
        public string AddPower { get; set; }
    }


    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "condition")]
    [XmlType(TypeName = "condition")]
    [Table(nameof(AoyiCondition))]
    public class AoyiCondition
    {
     
        [XmlIgnore]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [XmlIgnore]
        [ForeignKey(nameof(Aoyi))]
        public Guid AoyiId { get; set; }

        [XmlAttribute("level")]
        public string Level { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }


    }

}
