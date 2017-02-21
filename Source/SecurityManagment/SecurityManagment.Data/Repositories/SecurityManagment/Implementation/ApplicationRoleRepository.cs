// <copyright file="ApplicationRoleRepository.cs" company="">
// </copyright>
// <author>Mauricio Suarez.</author>
// <summary>This is the REPOSITORY from ApplicationRole.</summary>
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
	/// <value>The ApplicationRole.</value>
	/// <author>Mauricio Suarez.</author>
	public class ApplicationRoleRepository : IApplicationRoleRepository //BaseRepository<MyCoinEntities>, 
	{
		/// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
        /// <author>Mauricio Suarez.</author>
        public List<ApplicationRoleDto> GetApplicationRole(List<ApplicationRoleDto> listApplicationRoleDto)
        {
            return this.ExecuteGetApplicationRole(null, listApplicationRoleDto);
        }

        /// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
        /// <author>Mauricio Suarez.</author>
        public List<ApplicationRoleDto> GetApplicationRole(PaginationDto paginationDto, List<ApplicationRoleDto> listApplicationRoleDto)
        {
            return this.ExecuteGetApplicationRole(paginationDto, listApplicationRoleDto);
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="dtoApplicationRole">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
		/// <author>Mauricio Suarez.</author>
        public List<ApplicationRoleDto> GetApplicationRole(ApplicationRoleDto dtoApplicationRole)
        {
			List<ApplicationRoleDto> listFilterApplicationRole = new List<ApplicationRoleDto>();
            listFilterApplicationRole.Add(dtoApplicationRole);
            return this.ExecuteGetApplicationRole(null, listFilterApplicationRole);
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterApplicationRole">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
		/// <author>Mauricio Suarez.</author>
        public List<ApplicationRoleDto> GetApplicationRole(PaginationDto paginationDto, ApplicationRoleDto dtoApplicationRole)
        {
			List<ApplicationRoleDto> listFilterApplicationRole = new List<ApplicationRoleDto>();
            listFilterApplicationRole.Add(dtoApplicationRole);
            return this.ExecuteGetApplicationRole(paginationDto, listFilterApplicationRole);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suarez.</author>
        public int GetApplicationRoleCount(List<ApplicationRoleDto> listApplicationRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationRole, ApplicationRoleDto>(listApplicationRoleDto);

                return context.ApplicationRole.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="dtoApplicationRole">List of data to store ApplicationRole.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<ApplicationRoleDto> SaveApplicationRole(ApplicationRoleDto dtoApplicationRole)
        {
			List<ApplicationRoleDto> listDataApplicationRole = new List<ApplicationRoleDto>();
            listDataApplicationRole.Add(dtoApplicationRole);
			return this.SaveApplicationRole(listDataApplicationRole);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listApplicationRoleDto">List of data to store ApplicationRole.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
		public List<ApplicationRoleDto> SaveApplicationRole(List<ApplicationRoleDto> listApplicationRoleDto)
        {
            List<ApplicationRole> listApplicationRoleResult = new List<ApplicationRole>();
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<ApplicationRole> set = objectContext.CreateObjectSet<ApplicationRole>();
                string[] entityApplicationRoleKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listApplicationRoleDto, entityApplicationRoleKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (ApplicationRoleDto dtoApplicationRole in listApplicationRoleDto)
                {
                    ApplicationRole entityApplicationRole = Mapper.Map<ApplicationRoleDto, ApplicationRole>(dtoApplicationRole);

                    if (resultValidateInsertOrUpdateCount > 0)
                    {

                        if (resultValidateInsertOrUpdate[i])
                        {
                            context.ApplicationRole.Attach(entityApplicationRole);
							context.Entry(entityApplicationRole).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.ApplicationRole.Add(entityApplicationRole);
                        }
                    }
                    else
                    {
                        context.ApplicationRole.Add(entityApplicationRole);
                    }

                    listApplicationRoleResult.Add(entityApplicationRole);
					i++;
                }

                context.SaveChanges();
            }

            listApplicationRoleDto = null;
            return listApplicationRoleResult.Select(Mapper.Map<ApplicationRole, ApplicationRoleDto>).ToList();
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="llistApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
		/// <author>Mauricio Suarez.</author>
        private List<ApplicationRoleDto> ExecuteUnPaginated(List<ApplicationRoleDto> listApplicationRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationRole, ApplicationRoleDto>(listApplicationRoleDto);

                return context.ApplicationRole
                .Include(ConditionalQuery.GenerateIncludes(listApplicationRoleDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<ApplicationRole, ApplicationRoleDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
		/// <author>Mauricio Suarez.</author>
        private List<ApplicationRoleDto> ExecutePaginated(PaginationDto paginationDto, List<ApplicationRoleDto> listApplicationRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                
                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdApplicationRole";
                    paginationDto.SortDirection = "ASC";
                }
				
				if (paginationDto.PageSize == 0 && paginationDto.CurrentPage == 0)
                {
                    paginationDto.PageSize = int.MaxValue;
                }
				
				var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationRole, ApplicationRoleDto>(listApplicationRoleDto);

                return context.ApplicationRole.AsExpandable()
				.Include(ConditionalQuery.GenerateIncludes(listApplicationRoleDto))
                .Where(predicate).AsParallel()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirection)
                .Skip(paginationDto.CurrentPage * paginationDto.PageSize)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<ApplicationRole, ApplicationRoleDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
		/// <author>Mauricio Suarez.</author>
        private List<ApplicationRoleDto> ExecuteGetApplicationRole(PaginationDto paginationDto, List<ApplicationRoleDto> listApplicationRoleDto)
        {   
            if (paginationDto != null)
            {
                return ExecutePaginated(paginationDto, listApplicationRoleDto);
            }
            else
            {
                return ExecuteUnPaginated(listApplicationRoleDto);
            }
        }
		
		/// <summary>
        /// Delete rows from table ApplicationRole.
        /// </summary>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>Comfirm execute command.</returns>
		/// <author>Mauricio Suarez.</author>
		public bool DeleteApplicationRole(List<ApplicationRoleDto> listApplicationRoleDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                var predicate = ConditionalQuery.GeneratePredicateQuery<ApplicationRole, ApplicationRoleDto>(listApplicationRoleDto);

                context.ApplicationRole.RemoveRange(context.ApplicationRole.AsExpandable().Where(predicate));
                context.SaveChanges();

                return true;
            }
        }
	}
}