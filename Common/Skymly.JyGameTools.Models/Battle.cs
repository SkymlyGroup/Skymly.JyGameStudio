using BootstrapBlazor.Components;

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
        [Display(Name = "主键")]
        [AutoGenerateColumn(Ignore = true)]
        public Guid Id { get; set; }= Guid.NewGuid();

        [AutoGenerateColumn(Order = 3, Filterable = true, Searchable = true)]
        [XmlAttribute("music")]
        public string Music { get; set; }

        [AutoGenerateColumn(Order = 4, Filterable = true, Searchable = true)]
        [XmlAttribute("must")]
        public string Must { get; set; }

        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true)]
        [XmlAttribute("key")]
        public string Key { get; set; }

        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true)]
        [XmlAttribute("mapkey")]
        public string Mapkey { get; set; } 

        [XmlIgnore]
        [NotMapped]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> Friends => BattleRoles.Where(v => v.Team == "1").ToList();

        [NotMapped]
        [XmlIgnore]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> Enemies => BattleRoles.Where(v => v.Team == "2").ToList();

        [XmlArray(ElementName = "roles")]
        [XmlArrayItem(ElementName = "role")]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> BattleRoles { get; set; } = new();

        [NotMapped]
        [XmlArray(ElementName = "random")]
        [XmlArrayItem(ElementName = "role")]
        [AutoGenerateColumn(Ignore = true)]
        public List<BattleRole> Randoms { get; set; } = new();

    }

    [Serializable]
    [XmlRoot("root", IsNullable = false)]
    [XmlType(TypeName = "role")]
    [Table(nameof(BattleRole))]
    public class BattleRole
    {
        public BattleRole()
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
        [ForeignKey(nameof(Battle))]
        public Guid BattleId { get; set; }

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
        [NotMapped]
        public bool IsBossSpecified { get => this.IsBoss; }
        [NotMapped]
        [XmlIgnore]
        public bool KeySpecified { get => !string.IsNullOrWhiteSpace(Team) || !string.IsNullOrWhiteSpace(Key); }


    }
}


