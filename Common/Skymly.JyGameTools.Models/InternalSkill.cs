using System;
using System.Xml.Serialization;

namespace Skymly.JyGameTools.Models
{
    [Serializable]
    [XmlRoot("root", IsNullable = false, ElementName = "internal_skill")]
    [XmlType(TypeName = "internal_skill")]
    public class InternalSkill
    {
        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "trigger")]
        [XmlType(TypeName = "trigger")]
        public class Trigger_InternalSkill
        {

        }
        [Serializable]
        [XmlRoot("root", IsNullable = false, ElementName = "unique")]
        [XmlType(TypeName = "unique")]
        public class Unique_InternalSkill
        {

        }
        [XmlAttribute("critical")]
        public string Critical { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("icon")]
        public string Icon { get; set; }

        [XmlAttribute("hard")]
        public string Hard { get; set; }

        [XmlAttribute("info")]
        public string Info { get; set; }

        [XmlAttribute("yin")]
        public string Yin { get; set; }

        [XmlAttribute("defence")]
        public string Defence { get; set; }

        [XmlAttribute("attack")]
        public string Attack { get; set; }

        [XmlAttribute("yang")]
        public string Yang { get; set; }
    }
}


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootInternal_skill {
    
    private rootInternal_skillUnique[] uniqueField;
    
    private rootInternal_skillTrigger[] triggerField;
    
    private string criticalField;
    
    private string nameField;
    
    private string iconField;
    
    private string hardField;
    
    private string infoField;
    
    private string yinField;
    
    private string defenceField;
    
    private string attackField;
    
    private string yangField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("unique", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootInternal_skillUnique[] unique {
        get {
            return this.uniqueField;
        }
        set {
            this.uniqueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("trigger", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootInternal_skillTrigger[] trigger {
        get {
            return this.triggerField;
        }
        set {
            this.triggerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string critical {
        get {
            return this.criticalField;
        }
        set {
            this.criticalField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string icon {
        get {
            return this.iconField;
        }
        set {
            this.iconField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hard {
        get {
            return this.hardField;
        }
        set {
            this.hardField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string info {
        get {
            return this.infoField;
        }
        set {
            this.infoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string yin {
        get {
            return this.yinField;
        }
        set {
            this.yinField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string defence {
        get {
            return this.defenceField;
        }
        set {
            this.defenceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string attack {
        get {
            return this.attackField;
        }
        set {
            this.attackField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string yang {
        get {
            return this.yangField;
        }
        set {
            this.yangField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootInternal_skillUnique {
    
    private string castsizeField;
    
    private string nameField;
    
    private string costballField;
    
    private string iconField;
    
    private string coversizeField;
    
    private string infoField;
    
    private string cdField;
    
    private string poweraddField;
    
    private string covertypeField;
    
    private string animationField;
    
    private string audioField;
    
    private string requirelvField;
    
    private string buffField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string castsize {
        get {
            return this.castsizeField;
        }
        set {
            this.castsizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string costball {
        get {
            return this.costballField;
        }
        set {
            this.costballField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string icon {
        get {
            return this.iconField;
        }
        set {
            this.iconField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string coversize {
        get {
            return this.coversizeField;
        }
        set {
            this.coversizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string info {
        get {
            return this.infoField;
        }
        set {
            this.infoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string cd {
        get {
            return this.cdField;
        }
        set {
            this.cdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string poweradd {
        get {
            return this.poweraddField;
        }
        set {
            this.poweraddField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string covertype {
        get {
            return this.covertypeField;
        }
        set {
            this.covertypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string animation {
        get {
            return this.animationField;
        }
        set {
            this.animationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string audio {
        get {
            return this.audioField;
        }
        set {
            this.audioField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string requirelv {
        get {
            return this.requirelvField;
        }
        set {
            this.requirelvField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string buff {
        get {
            return this.buffField;
        }
        set {
            this.buffField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootInternal_skillTrigger {
    
    private string lvField;
    
    private string argvsField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lv {
        get {
            return this.lvField;
        }
        set {
            this.lvField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string argvs {
        get {
            return this.argvsField;
        }
        set {
            this.argvsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}
