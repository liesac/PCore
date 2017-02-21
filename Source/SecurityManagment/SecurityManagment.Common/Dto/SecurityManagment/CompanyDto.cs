// <copyright file="CompanyDto.cs" company="">
// Mauricio Suárez. All rights reserved.
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the DTO from Company</summary>
namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using Newtonsoft.Json;
	using System;
    using System.Collections.Generic;
	/// <summary>
	/// Gets or sets the column of the application.
	/// </summary>
	/// <value>The Company.</value>
	/// <author>Mauricio Suárez.</author>
	public class CompanyDto : BaseDto
	{
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdCompany.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdCompany { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The Name.</value>
		/// <author>Mauricio Suárez.</author>
		public string Name { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The ValidThru.</value>
		/// <author>Mauricio Suárez.</author>
		public DateTime? ValidThru { get; set; }
		
		/// <summary>
		/// This is the list DTO from ApplicationUserRole.
		/// </summary>
		/// <value>The list ApplicationUserRole.</value>
		/// <author>Mauricio Suárez.</author>
	    public List<ApplicationUserRoleDto> ApplicationUserRole { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableApplicationUserRole { get; set; }
		
		/// <summary>
		/// This is the list DTO from CompanyApplication.
		/// </summary>
		/// <value>The list CompanyApplication.</value>
		/// <author>Mauricio Suárez.</author>
	    public List<CompanyApplicationDto> CompanyApplication { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableCompanyApplication { get; set; }
		
	}
}