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
    
    public partial class Application
    {
        public Application()
        {
            this.ApplicationRole = new HashSet<ApplicationRole>();
            this.CompanyApplication = new HashSet<CompanyApplication>();
            this.LastLogin = new HashSet<LastLogin>();
            this.NotificationsSettings = new HashSet<NotificationsSettings>();
            this.Page = new HashSet<Page>();
        }
    
        public long IdApplication { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }
        public bool ValidateActiveDirectory { get; set; }
        public string ImageUrl { get; set; }
    
        public virtual ICollection<ApplicationRole> ApplicationRole { get; set; }
        public virtual ICollection<CompanyApplication> CompanyApplication { get; set; }
        public virtual ICollection<LastLogin> LastLogin { get; set; }
        public virtual ICollection<NotificationsSettings> NotificationsSettings { get; set; }
        public virtual ICollection<Page> Page { get; set; }
    }
}
