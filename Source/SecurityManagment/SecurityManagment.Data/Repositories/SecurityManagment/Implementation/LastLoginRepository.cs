// <copyright file="LastLoginRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from LastLogin.</summary>
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
	/// <value>The LastLogin.</value>
	/// <author>Mauricio Suárez.</author>
	public class LastLoginRepository : ILastLoginRepository //BaseRepository<SecurityManagmentEntities>, 
	{
		/// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="listLastLoginDto">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<LastLoginDto> GetLastLogin(List<LastLoginDto> listLastLoginDto)
        {
            return this.ExecuteGetLastLogin(null, listLastLoginDto);
        }

        /// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listLastLoginDto">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<LastLoginDto> GetLastLogin(PaginationDto paginationDto, List<LastLoginDto> listLastLoginDto)
        {
            return this.ExecuteGetLastLogin(paginationDto, listLastLoginDto);
        }
		
		/// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="lFilterLastLogin">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<LastLoginDto> GetLastLogin(LastLoginDto dtoLastLogin)
        {
			List<LastLoginDto> listFilterLastLogin = new List<LastLoginDto>();
            listFilterLastLogin.Add(dtoLastLogin);
            return this.ExecuteGetLastLogin(null, listFilterLastLogin);
        }
		
		/// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterLastLogin">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<LastLoginDto> GetLastLogin(PaginationDto paginationDto, LastLoginDto dtoLastLogin)
        {
			List<LastLoginDto> listFilterLastLogin = new List<LastLoginDto>();
            listFilterLastLogin.Add(dtoLastLogin);
            return this.ExecuteGetLastLogin(paginationDto, listFilterLastLogin);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listLastLoginDto">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetLastLoginCount(List<LastLoginDto> listLastLoginDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<LastLogin, LastLoginDto>(listLastLoginDto);

                return context.LastLogin.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataLastLogin">List of data to store LastLogin.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveLastLogin(LastLoginDto dtoLastLogin)
        {
			List<LastLoginDto> listDataLastLogin = new List<LastLoginDto>();
            listDataLastLogin.Add(dtoLastLogin);
			return this.SaveLastLogin(listDataLastLogin);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataLastLogin">List of data to store LastLogin.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveLastLogin(List<LastLoginDto> listLastLoginDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<LastLogin> set = objectContext.CreateObjectSet<LastLogin>();
                string[] entityOrderDetailKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listLastLoginDto, entityOrderDetailKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (LastLoginDto dtoLastLogin in listLastLoginDto)
                {

                    if (resultValidateInsertOrUpdateCount > 0)                    {
                        LastLogin entityOrderDetail = null;
                        if (resultValidateInsertOrUpdate[i])
                        {
                            entityOrderDetail = Mapper.Map<LastLoginDto, LastLogin>(dtoLastLogin);
                            context.Entry(entityOrderDetail).State = System.Data.Entity.EntityState.Modified;
                            context.LastLogin.Attach(entityOrderDetail);
                        }
                        else
                        {
                            context.LastLogin.Add(Mapper.Map<LastLoginDto, LastLogin>(dtoLastLogin));
                        }
                    }
                    else
                    {
                        context.LastLogin.Add(Mapper.Map<LastLoginDto, LastLogin>(dtoLastLogin));
                    }
                    i++;
                }

                context.SaveChanges();
            }

            return true;
        }
		
		/// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<LastLoginDto> ExecuteUnPaginated(List<LastLoginDto> listLastLoginDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<LastLogin, LastLoginDto>(listLastLoginDto);

                return context.LastLogin
                .Include(ConditionalQuery.GenerateIncludes(listLastLoginDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<LastLogin, LastLoginDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<LastLoginDto> ExecutePaginated(PaginationDto paginationDto, List<LastLoginDto> listLastLoginDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdLastLogin";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.LastLogin
				.Include(ConditionalQuery.GenerateIncludes(listLastLoginDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listLastLoginDto), ConditionalQuery.GenerateParametersConditionalQuery(listLastLoginDto)).AsParallel()
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<LastLogin, LastLoginDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listLastLoginDto">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<LastLoginDto> ExecuteGetLastLogin(PaginationDto paginationDto, List<LastLoginDto> listLastLoginDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listLastLoginDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listLastLoginDto);
            }
        }
	}
}