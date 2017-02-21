// <copyright file="ApplicationRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from Application.</summary>
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
	/// <value>The Application.</value>
	/// <author>Mauricio Suárez.</author>
	public class ApplicationRepository : IApplicationRepository //BaseRepository<SecurityManagmentEntities>, 
	{
		/// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="listApplicationDto">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationDto> GetApplication(List<ApplicationDto> listApplicationDto)
        {
            return this.ExecuteGetApplication(null, listApplicationDto);
        }

        /// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationDto">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationDto> GetApplication(PaginationDto paginationDto, List<ApplicationDto> listApplicationDto)
        {
            return this.ExecuteGetApplication(paginationDto, listApplicationDto);
        }

        public List<ApplicationDto> GetApplicationByUser(List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {

                var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationUserRole, ApplicationUserRoleDto>(listApplicationUserRoleDto);

                return (List<ApplicationDto>)UtilitiesObject.RemoveOtherObjects(context.ApplicationUserRole
                .Include(ConditionalQuery.GenerateIncludes(listApplicationUserRoleDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(data => data.ApplicationRole.Application)
                .Distinct()
                .Select(Mapper.Map<Application, ApplicationDto>).ToList());
                
            }
        }
		
		/// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="lFilterApplication">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<ApplicationDto> GetApplication(ApplicationDto dtoApplication)
        {
			List<ApplicationDto> listFilterApplication = new List<ApplicationDto>();
            listFilterApplication.Add(dtoApplication);
            return this.ExecuteGetApplication(null, listFilterApplication);
        }
		
		/// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterApplication">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<ApplicationDto> GetApplication(PaginationDto paginationDto, ApplicationDto dtoApplication)
        {
			List<ApplicationDto> listFilterApplication = new List<ApplicationDto>();
            listFilterApplication.Add(dtoApplication);
            return this.ExecuteGetApplication(paginationDto, listFilterApplication);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listApplicationDto">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetApplicationCount(List<ApplicationDto> listApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<Application, ApplicationDto>(listApplicationDto);

                return context.Application.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataApplication">List of data to store Application.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveApplication(ApplicationDto dtoApplication)
        {
			List<ApplicationDto> listDataApplication = new List<ApplicationDto>();
            listDataApplication.Add(dtoApplication);
			return this.SaveApplication(listDataApplication);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataApplication">List of data to store Application.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveApplication(List<ApplicationDto> listApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<Application> set = objectContext.CreateObjectSet<Application>();
                string[] entityOrderDetailKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listApplicationDto, entityOrderDetailKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (ApplicationDto dtoApplication in listApplicationDto)
                {

                    if (resultValidateInsertOrUpdateCount > 0)                    {
                        Application entityOrderDetail = null;
                        if (resultValidateInsertOrUpdate[i])
                        {
                            entityOrderDetail = Mapper.Map<ApplicationDto, Application>(dtoApplication);
                            context.Entry(entityOrderDetail).State = System.Data.Entity.EntityState.Modified;
                            context.Application.Attach(entityOrderDetail);
                        }
                        else
                        {
                            context.Application.Add(Mapper.Map<ApplicationDto, Application>(dtoApplication));
                        }
                    }
                    else
                    {
                        context.Application.Add(Mapper.Map<ApplicationDto, Application>(dtoApplication));
                    }
                    i++;
                }

                context.SaveChanges();
            }

            return true;
        }
		
		/// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<ApplicationDto> ExecuteUnPaginated(List<ApplicationDto> listApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<Application, ApplicationDto>(listApplicationDto);

                return context.Application.AsExpandable()
                .Include(ConditionalQuery.GenerateIncludes(listApplicationDto))
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<Application, ApplicationDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<ApplicationDto> ExecutePaginated(PaginationDto paginationDto, List<ApplicationDto> listApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdApplication";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.Application
				.Include(ConditionalQuery.GenerateIncludes(listApplicationDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listApplicationDto), ConditionalQuery.GenerateParametersConditionalQuery(listApplicationDto)).AsParallel()
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<Application, ApplicationDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationDto">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<ApplicationDto> ExecuteGetApplication(PaginationDto paginationDto, List<ApplicationDto> listApplicationDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listApplicationDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listApplicationDto);
            }
        }
	}
}