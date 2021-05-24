using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Skymly.JyGameTools.Models
{

    [Serializable]
    [XmlRoot("root")]
    [XmlType(TypeName = "root")]
    public class AoyiRoot
    {


        public void Complated()
        {
            if (aoyis!=null)
            {
                foreach (var aoyi in aoyis)
                {
                    foreach (var cond in aoyi.AoyiConditions)
                    {
                        cond.AoyiId = aoyi.Id;
                    }
                }
            }
        }

        private List<Aoyi> aoyis;

        [XmlElement("aoyi")]
        public List<Aoyi> Aoyis 
        { 
            get
            { 
                Complated(); 
                return aoyis; 
            }
            set => aoyis = value;
        }


    }


    [Serializable]
    [XmlRoot("root")]
    [XmlType(TypeName = "root")]
    public class BattleRoot
    {
        [XmlElement("battle")]
        public List<Battle> Battles { get; set; }
    }



    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class ResourceRoot
    //    {
    //        public ResourceRoot()
    //        {

    //        }

    //        [XmlElement("resource")]
    //        public List<Resource> Resources { get; set; }

    //    }


    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class MapRoot
    //    {
    //        [XmlElement("map")]
    //        public List<Map> Maps { get; set; }
    //    }

    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //public class RoleRoot
    //    {
    //        [XmlElement("role")]
    //        public List<Role> Roles { get; set; }
    //    }

    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class TowerRoot
    //    {
    //        [XmlElement("tower")]
    //        public List<Tower> Towers { get; set; }
    //    }


    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class StoryRoot
    //    {
    //        [XmlElement("story")]
    //        public List<Story> Stories { get; set; }
    //    }


    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class ModInfoRoot
    //    {
    //        [XmlElement("mod")]
    //        public ModInfo ModInfo { get; set; }
    //    }


    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class SkillRoot
    //    {
    //        [XmlElement("skill")]
    //        public List<Skill> Skills { get; set; }

    //        public SkillRoot()
    //        {

    //        }

    //        public void AutoComplete()
    //        {
    //            Parallel.ForEach(Skills, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, skill =>
    //            {
    //                foreach (Skill_unique unique in skill.Uniques)
    //                {
    //                    unique.Belong = skill.Name;
    //                }
    //                foreach (Skill_correct correct in skill.Corrects)
    //                {
    //                    correct.Belong = skill.Name;
    //                }
    //            });
    //        }
    //    }


    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class ItemRoot
    //    {
    //        [XmlElement("item")]
    //        public List<Item> Items { get; set; }
    //    }






    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class ShopRoot
    //    {
    //        [XmlElement("shop")]
    //        public List<Shop> Shops { get; set; }
    //    }




    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class SpecialRoot
    //    {
    //        [XmlElement("special_skill")]
    //        public List<Skill_special> Specials { get; set; }
    //    }

    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class Grow_templateRoot
    //    {
    //        [XmlElement("grow_template")]
    //        public List<Grow_template> Grow_Templates { get; set; }
    //    }




    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class Resource_SuggesttipsRoot
    //    {
    //        [XmlElement("resource")]
    //        public List<Resource_Suggesttips> Suggesttips { get; set; }
    //    }

    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class Skill_internalRoot
    //    {
    //        [XmlElement("internal_skill")]
    //        public List<Skill_internal> Skill_Internals { get; set; }

    //        public void AutoComplete()
    //        {
    //            Parallel.ForEach(Skill_Internals, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, skill =>
    //            {
    //                foreach (Skill_unique unique in skill.Uniques)
    //                {
    //                    unique.Belong = skill.Name;
    //                }
    //            });
    //        }

    //    }

    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class MenpaiRoot
    //    {
    //        [XmlElement("menpai")]
    //        public List<Menpai> Menpais { get; set; }
    //    }

    //    [Serializable]
    //    [XmlRoot("root")]
    //    [XmlType(TypeName = "root")]
    //    public class GlobalRoot
    //    {
    //        [XmlElement("trigger")]
    //        public List<GlobalTrigger> Globals { get; set; }
    //    }

}
