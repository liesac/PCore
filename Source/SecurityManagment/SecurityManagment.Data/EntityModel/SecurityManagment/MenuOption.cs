//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecurityManagment.Data.EntityModel.SecurityManagment
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuOption
    {
        public long IdMenuOption { get; set; }
        public long IdPage { get; set; }
        public Nullable<long> IdSecurityGUI { get; set; }
        public Nullable<long> IdMenuOptionFather { get; set; }
        public long IdApplicationRole { get; set; }
        public bool PageLock { get; set; }
        public string Target { get; set; }
        public bool IsMenu { get; set; }
    
        public virtual ApplicationRole ApplicationRole { get; set; }
        public virtual Page Page { get; set; }
        public virtual Page Page1 { get; set; }
        public virtual SecurityGUI SecurityGUI { get; set; }
    }
}
