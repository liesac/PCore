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
    
    public partial class SecurityGUI
    {
        public SecurityGUI()
        {
            this.MenuOption = new HashSet<MenuOption>();
        }
    
        public long IdSecurityGUI { get; set; }
        public long IdGUI { get; set; }
        public bool ControlLock { get; set; }
    
        public virtual GUI GUI { get; set; }
        public virtual ICollection<MenuOption> MenuOption { get; set; }
    }
}
