using BootstrapBlazor.Components;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace Skymly.JyGameStudio.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false)]
    [XmlType(TypeName = "battle")]
    [Table(nameof(Battle))]
    public class Battle
    {
        public Battle()
        {
        }

        [Key]
        [XmlIgnore]
        [Display(Name = "主键"), AutoGenerateColumn(Ignore = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "音乐"), AutoGenerateColumn(Order = 3, Filterable = false, Searchable = true)]
        [XmlAttribute("music")]
        public string Music { get; set; }

        [Display(Name = "必须上场"), AutoGenerateColumn(Order = 4, Filterable = false, Searchable = true)]
        [XmlAttribute("must")]
        public string Must { get; set; }

        [Display(Name = "战斗名称"), AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
        [XmlAttribute("key")]
        public string Key { get; set; }

        [Display(Name = "背景地图"), AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
        [XmlAttribute("mapkey")]
        public string Mapkey { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [NotMapped]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> Friends { get => BattleRoles.Where(v => v.Team == "1").ToList(); set { } }

        [JsonIgnore]
        [NotMapped]
        [XmlIgnore]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> Enemies { get => BattleRoles.Where(v => v.Team == "2").ToList(); set { } }
        
        [XmlArray(ElementName = "roles"), XmlArrayItem(ElementName = "role")]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> BattleRoles { get; set; } = new();

        [NotMapped]
        [XmlArray(ElementName = "random"), XmlArrayItem(ElementName = "role")]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> Randoms { get; set; } = new();

    }

    [Serializable, XmlRoot("root", IsNullable = false), XmlType(TypeName = "role")]
    [Table(nameof(BattleRole))]
    public class BattleRole
    {
        public BattleRole()
        {
        }

        [Display(Name = "主键"), AutoGenerateColumn(Ignore = true)]
        [XmlIgnore]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Display(Name = "外键"), AutoGenerateColumn(Ignore = true)]
        [XmlIgnore]
        [ForeignKey(nameof(Battle))]
        public Guid BattleId { get; set; }

        [Display(Name = "Y"), AutoGenerateColumn(Order = 8, Filterable = true, Searchable = false)]
        [XmlAttribute("y")]
        public string Y { get; set; }

        [Display(Name = "面向"), AutoGenerateColumn(Order = 9, Filterable = true, Searchable = false)]
        [XmlAttribute("face")]
        public string Face { get; set; }

        [Display(Name = "队伍"), AutoGenerateColumn(Order = 4, Filterable = true, Searchable = false)]
        [XmlAttribute("team")]
        public string Team { get; set; }

        [Display(Name = "角色Key"), AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
        [XmlAttribute("key")]
        public string Key { get; set; }

        [Display(Name = "序号"), AutoGenerateColumn(Order = 3, Filterable = true, Searchable = false)]
        [XmlAttribute("index")]
        public string Index { get; set; }

        [Display(Name = "角色Name"), AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [Display(Name = "等级"), AutoGenerateColumn(Order = 5, Filterable = true, Searchable = false)]
        [XmlAttribute("level")]
        public string Level { get; set; }

        [Display(Name = "X"), AutoGenerateColumn(Order = 7, Filterable = true, Searchable = false)]
        [XmlAttribute("x")]
        public string X { get; set; }

        [Display(Name = "是否为Boss"), AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false, ComponentType = typeof(Switch))]
        [XmlAttribute("boss")]
        public bool IsBoss { get; set; }

        [Display(Name = "动画模型"), AutoGenerateColumn(Order = 6, Filterable = true, Searchable = true)]
        [XmlAttribute("animation")]
        public string Animation { get; set; }

        [XmlIgnore]
        [NotMapped]
        [AutoGenerateColumn(Ignore = true)]
        public bool IsBossSpecified { get => this.IsBoss; }
        [NotMapped]
        [XmlIgnore]
        [AutoGenerateColumn(Ignore = true)]
        public bool KeySpecified { get => !string.IsNullOrWhiteSpace(Team) || !string.IsNullOrWhiteSpace(Key); }

    }
}


