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
    
    public partial class Page
    {
        public Page()
        {
            this.GUI = new HashSet<GUI>();
            this.MenuOption = new HashSet<MenuOption>();
            this.MenuOption1 = new HashSet<MenuOption>();
        }
    
        public long IdPage { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long IdApplication { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual ICollection<GUI> GUI { get; set; }
        public virtual ICollection<MenuOption> MenuOption { get; set; }
        public virtual ICollection<MenuOption> MenuOption1 { get; set; }
    }
}
