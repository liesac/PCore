// <copyright file="ApplicationUserRoleDto.cs" company="">
// Mauricio Suárez. All rights reserved.
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the DTO from ApplicationUserRole</summary>
namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using Newtonsoft.Json;
	using System;
    
	/// <summary>
	/// Gets or sets the column of the application.
	/// </summary>
	/// <value>The ApplicationUserRole.</value>
	/// <author>Mauricio Suárez.</author>
	public class ApplicationUserRoleDto : BaseDto
	{
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdApplicationUserRole.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdApplicationUserRole { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdCompany.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdCompany { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdApplicationRole.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdApplicationRole { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdUserApplication.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdUserApplication { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The State.</value>
		/// <author>Mauricio Suárez.</author>
		public bool? State { get; set; }
		
		/// <summary>
		/// This is the DTO from ApplicationRole.
		/// </summary>
		/// <value>The ApplicationRole.</value>
		/// <author>Mauricio Suárez.</author>
	    public ApplicationRoleDto ApplicationRole { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableApplicationRole { get; set; }
		
		/// <summary>
		/// This is the DTO from Company.
		/// </summary>
		/// <value>The Company.</value>
		/// <author>Mauricio Suárez.</author>
	    public CompanyDto Company { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableCompany { get; set; }
		
		/// <summary>
		/// This is the DTO from UserApplication.
		/// </summary>
		/// <value>The UserApplication.</value>
		/// <author>Mauricio Suárez.</author>
	    public UserApplicationDto UserApplication { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableUserApplication { get; set; }
		
	}
}