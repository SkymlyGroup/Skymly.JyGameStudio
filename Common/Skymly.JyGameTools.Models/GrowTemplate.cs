using System;
using System.Xml.Serialization;

namespace Skymly.JyGameTools.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "grow_template")]
    [XmlType(TypeName = "grow_template")]
    public class GrowTemplate
    {
        [XmlAttribute("shenfa")]
        public string Shenfa { get; set; }
        [XmlAttribute("hp")]
        public string Hp { get; set; }
        [XmlAttribute("qimen")]
        public string Qimen { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("mp")]
        public string Mp { get; set; }
        [XmlAttribute("bili")]
        public string Bili { get; set; }
        [XmlAttribute("dingli")]
        public string Dingli { get; set; }
        [XmlAttribute("daofa")]
        public string Daofa { get; set; }
        [XmlAttribute("quanzhang")]
        public string Quanzhang { get; set; }
        [XmlAttribute("gengu")]
        public string Gengu { get; set; }
        [XmlAttribute("wuxue")]
        public string Wuxue { get; set; }
        [XmlAttribute("fuyuan")]
        public string Fuyuan { get; set; }
        [XmlAttribute("wuxing")]
        public string Wuxing { get; set; }
        [XmlAttribute("jianfa")]
        public string Jianfa { get; set; }
    }
}

