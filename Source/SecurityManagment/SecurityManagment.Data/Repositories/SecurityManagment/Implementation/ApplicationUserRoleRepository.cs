// <copyright file="ApplicationUserRoleRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from ApplicationUserRole.</summary>
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

namespace SecurityManagment.Data.Repositories.SecurityManagment.Implementation
{
	/// <summary>
	/// Gets or sets the table of the application.
	/// </summary>
	/// <value>The ApplicationUserRole.</value>
	/// <author>Mauricio Suárez.</author>
	public class ApplicationUserRoleRepository : IApplicationUserRoleRepository //BaseRepository<SecurityManagmentEntities>, 
	{
		/// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="listApplicationUserRoleDto">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationUserRoleDto> GetApplicationUserRole(List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            return this.ExecuteGetApplicationUserRole(null, listApplicationUserRoleDto);
        }

        /// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationUserRoleDto">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationUserRoleDto> GetApplicationUserRole(PaginationDto paginationDto, List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            return this.ExecuteGetApplicationUserRole(paginationDto, listApplicationUserRoleDto);
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="lFilterApplicationUserRole">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<ApplicationUserRoleDto> GetApplicationUserRole(ApplicationUserRoleDto dtoApplicationUserRole)
        {
			List<ApplicationUserRoleDto> listFilterApplicationUserRole = new List<ApplicationUserRoleDto>();
            listFilterApplicationUserRole.Add(dtoApplicationUserRole);
            return this.ExecuteGetApplicationUserRole(null, listFilterApplicationUserRole);
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterApplicationUserRole">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<ApplicationUserRoleDto> GetApplicationUserRole(PaginationDto paginationDto, ApplicationUserRoleDto dtoApplicationUserRole)
        {
			List<ApplicationUserRoleDto> listFilterApplicationUserRole = new List<ApplicationUserRoleDto>();
            listFilterApplicationUserRole.Add(dtoApplicationUserRole);
            return this.ExecuteGetApplicationUserRole(paginationDto, listFilterApplicationUserRole);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listApplicationUserRoleDto">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetApplicationUserRoleCount(List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationUserRole, ApplicationUserRoleDto>(listApplicationUserRoleDto);

                return context.ApplicationUserRole.AsExpandable()
                .Where(predicate)
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataApplicationUserRole">List of data to store ApplicationUserRole.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveApplicationUserRole(ApplicationUserRoleDto dtoApplicationUserRole)
        {
			List<ApplicationUserRoleDto> listDataApplicationUserRole = new List<ApplicationUserRoleDto>();
            listDataApplicationUserRole.Add(dtoApplicationUserRole);
			return this.SaveApplicationUserRole(listDataApplicationUserRole);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataApplicationUserRole">List of data to store ApplicationUserRole.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveApplicationUserRole(List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<ApplicationUserRole> set = objectContext.CreateObjectSet<ApplicationUserRole>();
                string[] entityOrderDetailKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listApplicationUserRoleDto, entityOrderDetailKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (ApplicationUserRoleDto dtoApplicationUserRole in listApplicationUserRoleDto)
                {

                    if (resultValidateInsertOrUpdateCount > 0)                    {
                        ApplicationUserRole entityOrderDetail = null;
                        if (resultValidateInsertOrUpdate[i])
                        {
                            entityOrderDetail = Mapper.Map<ApplicationUserRoleDto, ApplicationUserRole>(dtoApplicationUserRole);
                            context.Entry(entityOrderDetail).State = System.Data.Entity.EntityState.Modified;
                            context.ApplicationUserRole.Attach(entityOrderDetail);
                        }
                        else
                        {
                            context.ApplicationUserRole.Add(Mapper.Map<ApplicationUserRoleDto, ApplicationUserRole>(dtoApplicationUserRole));
                        }
                    }
                    else
                    {
                        context.ApplicationUserRole.Add(Mapper.Map<ApplicationUserRoleDto, ApplicationUserRole>(dtoApplicationUserRole));
                    }
                    i++;
                }

                context.SaveChanges();
            }

            return true;
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<ApplicationUserRoleDto> ExecuteUnPaginated(List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationUserRole, ApplicationUserRoleDto>(listApplicationUserRoleDto);

                return context.ApplicationUserRole
                .Include(ConditionalQuery.GenerateIncludes(listApplicationUserRoleDto)).AsExpandable()
                .Where(predicate)
                .Select(Mapper.Map<ApplicationUserRole, ApplicationUserRoleDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<ApplicationUserRoleDto> ExecutePaginated(PaginationDto paginationDto, List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdApplicationUserRole";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.ApplicationUserRole
				.Include(ConditionalQuery.GenerateIncludes(listApplicationUserRoleDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listApplicationUserRoleDto), ConditionalQuery.GenerateParametersConditionalQuery(listApplicationUserRoleDto))
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<ApplicationUserRole, ApplicationUserRoleDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationUserRoleDto">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<ApplicationUserRoleDto> ExecuteGetApplicationUserRole(PaginationDto paginationDto, List<ApplicationUserRoleDto> listApplicationUserRoleDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listApplicationUserRoleDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listApplicationUserRoleDto);
            }
        }
	}
}