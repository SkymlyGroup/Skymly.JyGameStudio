﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// 此源代码由 xsd 自动生成, Version=4.8.3928.0。
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootItem_trigger {
    
    private rootItem_triggerTrigger[] triggerField;
    
    private string minlevelField;
    
    private string maxlevelField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("trigger", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootItem_triggerTrigger[] trigger {
        get {
            return this.triggerField;
        }
        set {
            this.triggerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string minlevel {
        get {
            return this.minlevelField;
        }
        set {
            this.minlevelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string maxlevel {
        get {
            return this.maxlevelField;
        }
        set {
            this.maxlevelField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootItem_triggerTrigger {
    
    private rootItem_triggerTriggerParam[] paramField;
    
    private string nameField;
    
    private string wField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("param", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public rootItem_triggerTriggerParam[] param {
        get {
            return this.paramField;
        }
        set {
            this.paramField = value;
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
    public string w {
        get {
            return this.wField;
        }
        set {
            this.wField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class rootItem_triggerTriggerParam {
    
    private string poolField;
    
    private string minField;
    
    private string maxField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pool {
        get {
            return this.poolField;
        }
        set {
            this.poolField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string min {
        get {
            return this.minField;
        }
        set {
            this.minField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string max {
        get {
            return this.maxField;
        }
        set {
            this.maxField = value;
        }
    }
}