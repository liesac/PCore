// <copyright file="CompanyApplicationDto.cs" company="">
// Mauricio Suárez. All rights reserved.
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the DTO from CompanyApplication</summary>
namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using Newtonsoft.Json;
	using System;
    
	/// <summary>
	/// Gets or sets the column of the application.
	/// </summary>
	/// <value>The CompanyApplication.</value>
	/// <author>Mauricio Suárez.</author>
	public class CompanyApplicationDto : BaseDto
	{
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdCompanyApplication.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdCompanyApplication { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdCompany.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdCompany { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdApplication.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdApplication { get; set; }
		
		/// <summary>
		/// This is the DTO from Application.
		/// </summary>
		/// <value>The Application.</value>
		/// <author>Mauricio Suárez.</author>
	    public ApplicationDto Application { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableApplication { get; set; }
		
		/// <summary>
		/// This is the DTO from Company.
		/// </summary>
		/// <value>The Company.</value>
		/// <author>Mauricio Suárez.</author>
	    public CompanyDto Company { get; set; }
	
	    [JsonIgnore]
		public bool? ReferenceTableCompany { get; set; }
		
	}
}