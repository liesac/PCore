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
    
    public partial class Company
    {
        public Company()
        {
            this.ApplicationUserRole = new HashSet<ApplicationUserRole>();
            this.CompanyApplication = new HashSet<CompanyApplication>();
            this.UserApplication = new HashSet<UserApplication>();
        }
    
        public long IdCompany { get; set; }
        public string Name { get; set; }
        public System.DateTime ValidThru { get; set; }
    
        public virtual ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
        public virtual ICollection<CompanyApplication> CompanyApplication { get; set; }
        public virtual ICollection<UserApplication> UserApplication { get; set; }
    }
}