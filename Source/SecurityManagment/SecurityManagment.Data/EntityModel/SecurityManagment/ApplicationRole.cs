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
    
    public partial class ApplicationRole
    {
        public ApplicationRole()
        {
            this.ApplicationUserRole = new HashSet<ApplicationUserRole>();
            this.MenuOption = new HashSet<MenuOption>();
        }
    
        public long IdApplicationRole { get; set; }
        public long IdRole { get; set; }
        public long IdApplication { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual ICollection<MenuOption> MenuOption { get; set; }
    }
}
