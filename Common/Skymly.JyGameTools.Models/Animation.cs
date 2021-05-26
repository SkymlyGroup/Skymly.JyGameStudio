using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Skymly.JyGameStudio.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "animation")]
    [XmlType(TypeName = "animation")]
    public class Animation
    {
        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "group")]
        [XmlType(TypeName = "group")]
        public class Group_Animation
        {
            [Serializable]
            [XmlRoot("root", IsNullable = false, ElementName = "image")]
            [XmlType(TypeName = "image")]
            public class Image_Group
            {
                [XmlAttribute("anchorx")]
                public string Anchorx { get; set; }

                [XmlAttribute("anchory")]
                public string Anchory { get; set; }

                [XmlAttribute("w")]
                public string W { get; set; }

                [XmlAttribute("h")]
                public string H { get; set; }
            }

            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlElement("image")]
            public List<Image_Group> Images { get; set; }
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("group")]
        public List<Group_Animation> Groups { get; set; }
    }
}



