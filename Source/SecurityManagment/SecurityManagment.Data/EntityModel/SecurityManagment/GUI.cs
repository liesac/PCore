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
    
    public partial class GUI
    {
        public GUI()
        {
            this.SecurityGUI = new HashSet<SecurityGUI>();
        }
    
        public long IdGUI { get; set; }
        public string IdentifierGUI { get; set; }
        public long IdPage { get; set; }
        public string Description { get; set; }
    
        public virtual Page Page { get; set; }
        public virtual ICollection<SecurityGUI> SecurityGUI { get; set; }
    }
}
