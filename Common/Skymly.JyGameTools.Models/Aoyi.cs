using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;

#if NET5_0
using BootstrapBlazor.Components;
#endif

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
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        public Guid Id { get; set; } = Guid.NewGuid();

#if NET5_0
        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "起手式")]
        [XmlAttribute("start")]
        public string Start { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "Buff")]
        [XmlAttribute("buff")]
        public string Buff { get; set; }
#if NET5_0
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
#endif
        [Display(Name = "动画")]
        [XmlAttribute("animation")]
        public string Animation { get; set; }
#if NET5_0
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
#endif
        [Display(Name = "概率")]
        [XmlAttribute("probability")]
        public string Probability { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "名称")]
        [XmlAttribute("name")]
        public string Name { get; set; }

#if NET5_0
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
#endif
        [Display(Name = "等级")]
        [XmlAttribute("level")]
        public string Level { get; set; }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [Display(Name = "触发条件")]
        [XmlElement("condition")]
        public List<AoyiCondition> AoyiConditions { get; set; }
#if NET5_0
        [AutoGenerateColumn(Filterable = true, Searchable = false)]
#endif
        [Display(Name = "威力加成")]
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

        #region 导航属性
        [Display(Name = "主键")]
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [XmlIgnore]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();


        [Display(Name = "所属奥义")]
        [XmlIgnore]
        [JsonIgnore]
        [Key]
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        public Aoyi Aoyi { get; set; }

        [Display(Name = "外键")]
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [XmlIgnore]
        [ForeignKey(nameof(Aoyi))]
        public Guid AoyiId { get; set; }
        #endregion




#if NET5_0
        [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "条件等级")]
        [XmlAttribute("level")]
        public string Level { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "条件值")]
        [XmlAttribute("value")]
        public string Value { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "条件类型")]
        [XmlAttribute("type")]
        public string Type { get; set; }

    }

}
