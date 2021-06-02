using Newtonsoft.Json;
#if NET5_0
using BootstrapBlazor.Components;
#endif
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
#if NET5_0
[AutoGenerateColumn(Ignore = true)]
#endif
        [Key]
        [XmlIgnore]
        [Display(Name = "主键")] 
        public Guid Id { get; set; } = Guid.NewGuid();

#if NET5_0
[AutoGenerateColumn(Order = 3, Filterable = false, Searchable = true)]
#endif
        [Display(Name = "音乐")] 
        [XmlAttribute("music")]
        public string Music { get; set; }
#if NET5_0
 [AutoGenerateColumn(Order = 4, Filterable = false, Searchable = true)]
#endif
        [Display(Name = "必须上场")]
        [XmlAttribute("must")]
        public string Must { get; set; }
#if NET5_0
[AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "战斗名称")] 
        [XmlAttribute("key")]
        public string Key { get; set; }
#if NET5_0
[AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "背景地图")] 
        [XmlAttribute("mapkey")]
        public string Mapkey { get; set; }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [JsonIgnore]
        [XmlIgnore]
        [NotMapped]
        public List<BattleRole> Friends
        {
            get => BattleRoles.Where(v => v.Team == "1").ToList();
            set { }
        }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [JsonIgnore]
        [NotMapped]
        [XmlIgnore]
        public List<BattleRole> Enemies
        {
            get => BattleRoles.Where(v => v.Team == "2").ToList();
            set { }
        }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [XmlArray(ElementName = "roles"), XmlArrayItem(ElementName = "role")]

        public List<BattleRole> BattleRoles { get; set; } = new();
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [NotMapped]
        [XmlArray(ElementName = "random"), XmlArrayItem(ElementName = "role")]
        public List<BattleRole> Randoms { get; set; } = new();

    }

    [Serializable, XmlRoot("root", IsNullable = false), XmlType(TypeName = "role")]
    [Table(nameof(BattleRole))]
    public class BattleRole
    {
        public BattleRole()
        {
        }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [Display(Name = "主键")]
        [XmlIgnore]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
#if NET5_0
        [ AutoGenerateColumn(Ignore = true)]
#endif
        [Display(Name = "外键")]
        [XmlIgnore]
        [ForeignKey(nameof(Battle))]
        public Guid BattleId { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 8, Filterable = true, Searchable = false)]
#endif
        [Display(Name = "Y")]
        [XmlAttribute("y")]
        public string Y { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 9, Filterable = true, Searchable = false)]
#endif
        [Display(Name = "面向")] 
        [XmlAttribute("face")]
        public string Face { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = false)]
#endif
        [Display(Name = "队伍")] 
        [XmlAttribute("team")]
        public string Team { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "角色Key")] 
        [XmlAttribute("key")]
        public string Key { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = false)]
#endif
        [Display(Name = "序号")] 
        [XmlAttribute("index")]
        public string Index { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "角色Name")]
        [XmlAttribute("name")]
        public string Name { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 5, Filterable = true, Searchable = false)]
#endif
        [Display(Name = "等级")] 
        [XmlAttribute("level")]
        public string Level { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 7, Filterable = true, Searchable = false)]
#endif
        [Display(Name = "X")] 
        [XmlAttribute("x")]
        public string X { get; set; }


#if NET5_0
        [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = false, ComponentType = typeof(Switch))]
#endif
        [Display(Name = "是否为Boss")] 
        [XmlAttribute("boss")]
        public bool IsBoss { get; set; }
#if NET5_0
        [AutoGenerateColumn(Order = 6, Filterable = true, Searchable = true)]
#endif
        [Display(Name = "动画模型")]
        [XmlAttribute("animation")]
        public string Animation { get; set; }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [XmlIgnore]
        [NotMapped]
        public bool IsBossSpecified { get => this.IsBoss; set { } }
#if NET5_0
        [AutoGenerateColumn(Ignore = true)]
#endif
        [NotMapped]
        [XmlIgnore]
        public bool KeySpecified { get => !string.IsNullOrWhiteSpace(Team) || !string.IsNullOrWhiteSpace(Key); set { } }

    }
}


