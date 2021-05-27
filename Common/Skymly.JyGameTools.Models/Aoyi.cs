using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using BootstrapBlazor.Components;
using System.ComponentModel;

namespace Skymly.JyGameStudio.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "aoyi")]
    [XmlType(TypeName = "aoyi")]
    [Table(nameof(Aoyi))]
    public class Aoyi
    {
        public Aoyi()
        {

        }


        [Key]
        [XmlIgnore]
        [Display(Name = "主键")]
        [AutoGenerateColumn(Ignore = true)]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Display(Name = "起手式")]
        [AutoGenerateColumn(Order =2, Filterable = true, Searchable = true)]
        [XmlAttribute("start")]
        public string Start { get; set; }

        [Display(Name = "Buff")]
        [AutoGenerateColumn(Order =3, Filterable = true, Searchable = true)]
        [XmlAttribute("buff")]
        public string Buff { get; set; }

        [Display(Name = "动画")]
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
        [XmlAttribute("animation")]
        public string Animation { get; set; }

        [Display(Name = "概率")]
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
        [XmlAttribute("probability")]
        public string Probability { get; set; }

        [Display(Name = "名称")]
        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
        [XmlAttribute("name")]
        public string Name { get; set; }


        [Display(Name = "等级")]
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
        [XmlAttribute("level")]
        public string Level { get; set; }

        [Display(Name = "触发条件")]
        [XmlElement("condition")]
        [AutoGenerateColumn(Ignore = true)]
        public List<AoyiCondition> AoyiConditions { get; set; }

        [Display(Name = "威力加成")]
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
        [XmlAttribute("addPower")]
        public string AddPower { get; set; }
    }


    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "condition")]
    [XmlType(TypeName = "condition")]
    [Table(nameof(AoyiCondition))]
    public class AoyiCondition
    {
        public AoyiCondition()
        {

        }


        [Display(Name = "主键")]
        [AutoGenerateColumn(Ignore = true)]
        [XmlIgnore]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "外键")]
        [AutoGenerateColumn(Ignore = true)]
        [XmlIgnore]
        [ForeignKey(nameof(Aoyi))]
        public Guid AoyiId { get; set; }

        [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
        [Display(Name = "条件等级")]
        [XmlAttribute("level")]
        public string Level { get; set; }

        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
        [Display(Name = "条件值")]
        [XmlAttribute("value")]
        public string Value { get; set; }

        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
        [Display(Name = "条件类型")]
        [XmlAttribute("type")]
        public string Type { get; set; }

    }

}
