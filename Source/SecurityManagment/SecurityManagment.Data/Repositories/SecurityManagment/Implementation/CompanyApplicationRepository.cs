// <copyright file="CompanyApplicationRepository.cs" company="">
// </copyright>
// <author>Mauricio Suarez.</author>
// <summary>This is the REPOSITORY from CompanyApplication.</summary>
using AutoMapper;
using Data;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;
using SecurityManagment.Data.EntityModel.SecurityManagment;
using SecurityManagment.Data.Repositories.SecurityManagment.Interface;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using LinqKit;
using SecurityManagment.Common.Utilities;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Implementation
{
	/// <summary>
	/// Gets or sets the table of the application.
	/// </summary>
	/// <value>The CompanyApplication.</value>
	/// <author>Mauricio Suarez.</author>
	public class CompanyApplicationRepository : ICompanyApplicationRepository //BaseRepository<MyCoinEntities>, 
	{
		/// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
        /// <author>Mauricio Suarez.</author>
        public List<CompanyApplicationDto> GetCompanyApplication(List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            return this.ExecuteGetCompanyApplication(null, listCompanyApplicationDto);
        }

        /// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
        /// <author>Mauricio Suarez.</author>
        public List<CompanyApplicationDto> GetCompanyApplication(PaginationDto paginationDto, List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            return this.ExecuteGetCompanyApplication(paginationDto, listCompanyApplicationDto);
        }
		
		/// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="dtoCompanyApplication">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
		/// <author>Mauricio Suarez.</author>
        public List<CompanyApplicationDto> GetCompanyApplication(CompanyApplicationDto dtoCompanyApplication)
        {
			List<CompanyApplicationDto> listFilterCompanyApplication = new List<CompanyApplicationDto>();
            listFilterCompanyApplication.Add(dtoCompanyApplication);
            return this.ExecuteGetCompanyApplication(null, listFilterCompanyApplication);
        }
		
		/// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterCompanyApplication">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
		/// <author>Mauricio Suarez.</author>
        public List<CompanyApplicationDto> GetCompanyApplication(PaginationDto paginationDto, CompanyApplicationDto dtoCompanyApplication)
        {
			List<CompanyApplicationDto> listFilterCompanyApplication = new List<CompanyApplicationDto>();
            listFilterCompanyApplication.Add(dtoCompanyApplication);
            return this.ExecuteGetCompanyApplication(paginationDto, listFilterCompanyApplication);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suarez.</author>
        public int GetCompanyApplicationCount(List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<CompanyApplication, CompanyApplicationDto>(listCompanyApplicationDto);

                return context.CompanyApplication.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="dtoCompanyApplication">List of data to store CompanyApplication.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<CompanyApplicationDto> SaveCompanyApplication(CompanyApplicationDto dtoCompanyApplication)
        {
			List<CompanyApplicationDto> listDataCompanyApplication = new List<CompanyApplicationDto>();
            listDataCompanyApplication.Add(dtoCompanyApplication);
			return this.SaveCompanyApplication(listDataCompanyApplication);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listCompanyApplicationDto">List of data to store CompanyApplication.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
		public List<CompanyApplicationDto> SaveCompanyApplication(List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            List<CompanyApplication> listCompanyApplicationResult = new List<CompanyApplication>();
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<CompanyApplication> set = objectContext.CreateObjectSet<CompanyApplication>();
                string[] entityCompanyApplicationKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listCompanyApplicationDto, entityCompanyApplicationKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (CompanyApplicationDto dtoCompanyApplication in listCompanyApplicationDto)
                {
                    CompanyApplication entityCompanyApplication = Mapper.Map<CompanyApplicationDto, CompanyApplication>(dtoCompanyApplication);

                    if (resultValidateInsertOrUpdateCount > 0)
                    {

                        if (resultValidateInsertOrUpdate[i])
                        {
                            context.CompanyApplication.Attach(entityCompanyApplication);
							context.Entry(entityCompanyApplication).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.CompanyApplication.Add(entityCompanyApplication);
                        }
                    }
                    else
                    {
                        context.CompanyApplication.Add(entityCompanyApplication);
                    }

                    listCompanyApplicationResult.Add(entityCompanyApplication);
					i++;
                }

                context.SaveChanges();
            }

            listCompanyApplicationDto = null;
            return listCompanyApplicationResult.Select(Mapper.Map<CompanyApplication, CompanyApplicationDto>).ToList();
        }
		
		/// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="llistCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
		/// <author>Mauricio Suarez.</author>
        private List<CompanyApplicationDto> ExecuteUnPaginated(List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<CompanyApplication, CompanyApplicationDto>(listCompanyApplicationDto);

                return context.CompanyApplication
                .Include(ConditionalQuery.GenerateIncludes(listCompanyApplicationDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<CompanyApplication, CompanyApplicationDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
		/// <author>Mauricio Suarez.</author>
        private List<CompanyApplicationDto> ExecutePaginated(PaginationDto paginationDto, List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                
                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdCompanyApplication";
                    paginationDto.SortDirection = "ASC";
                }
				
				if (paginationDto.PageSize == 0 && paginationDto.CurrentPage == 0)
                {
                    paginationDto.PageSize = int.MaxValue;
                }
				
				var predicate = ConditionalQuery.GeneratePredicateQuery<CompanyApplication, CompanyApplicationDto>(listCompanyApplicationDto);

                return context.CompanyApplication.AsExpandable()
				.Include(ConditionalQuery.GenerateIncludes(listCompanyApplicationDto))
                .Where(predicate).AsParallel()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirection)
                .Skip(paginationDto.CurrentPage * paginationDto.PageSize)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<CompanyApplication, CompanyApplicationDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
		/// <author>Mauricio Suarez.</author>
        private List<CompanyApplicationDto> ExecuteGetCompanyApplication(PaginationDto paginationDto, List<CompanyApplicationDto> listCompanyApplicationDto)
        {   
            if (paginationDto != null)
            {
                return ExecutePaginated(paginationDto, listCompanyApplicationDto);
            }
            else
            {
                return ExecuteUnPaginated(listCompanyApplicationDto);
            }
        }
		
		/// <summary>
        /// Delete rows from table CompanyApplication.
        /// </summary>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>Comfirm execute command.</returns>
		/// <author>Mauricio Suarez.</author>
		public bool DeleteCompanyApplication(List<CompanyApplicationDto> listCompanyApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                var predicate = ConditionalQuery.GeneratePredicateQuery<CompanyApplication, CompanyApplicationDto>(listCompanyApplicationDto);

                context.CompanyApplication.RemoveRange(context.CompanyApplication.AsExpandable().Where(predicate));
                context.SaveChanges();

                return true;
            }
        }
	}
}