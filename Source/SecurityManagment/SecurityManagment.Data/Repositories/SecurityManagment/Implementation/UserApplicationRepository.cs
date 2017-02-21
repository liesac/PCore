// <copyright file="UserApplicationRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from UserApplication.</summary>
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
	/// <value>The UserApplication.</value>
	/// <author>Mauricio Suárez.</author>
	public class UserApplicationRepository : IUserApplicationRepository //BaseRepository<SecurityManagmentEntities>, 
	{
		/// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="listUserApplicationDto">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<UserApplicationDto> GetUserApplication(List<UserApplicationDto> listUserApplicationDto)
        {
            return this.ExecuteGetUserApplication(null, listUserApplicationDto);
        }

        /// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listUserApplicationDto">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<UserApplicationDto> GetUserApplication(PaginationDto paginationDto, List<UserApplicationDto> listUserApplicationDto)
        {
            return this.ExecuteGetUserApplication(paginationDto, listUserApplicationDto);
        }
		
		/// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="lFilterUserApplication">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<UserApplicationDto> GetUserApplication(UserApplicationDto dtoUserApplication)
        {
			List<UserApplicationDto> listFilterUserApplication = new List<UserApplicationDto>();
            listFilterUserApplication.Add(dtoUserApplication);
            return this.ExecuteGetUserApplication(null, listFilterUserApplication);
        }
		
		/// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterUserApplication">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<UserApplicationDto> GetUserApplication(PaginationDto paginationDto, UserApplicationDto dtoUserApplication)
        {
			List<UserApplicationDto> listFilterUserApplication = new List<UserApplicationDto>();
            listFilterUserApplication.Add(dtoUserApplication);
            return this.ExecuteGetUserApplication(paginationDto, listFilterUserApplication);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listUserApplicationDto">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetUserApplicationCount(List<UserApplicationDto> listUserApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<UserApplication, UserApplicationDto>(listUserApplicationDto);

                return context.UserApplication.AsExpandable()
                .Where(predicate)
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataUserApplication">List of data to store UserApplication.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<UserApplicationDto> SaveUserApplication(UserApplicationDto dtoUserApplication)
        {
			List<UserApplicationDto> listDataUserApplication = new List<UserApplicationDto>();
            listDataUserApplication.Add(dtoUserApplication);
			return this.SaveUserApplication(listDataUserApplication);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataUserApplication">List of data to store UserApplication.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<UserApplicationDto> SaveUserApplication(List<UserApplicationDto> listUserApplicationDto)
        {
            List<UserApplication> listSaleResult = new List<UserApplication>();
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<UserApplication> set = objectContext.CreateObjectSet<UserApplication>();
                string[] entitySaleKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listUserApplicationDto, entitySaleKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (UserApplicationDto dtoSale in listUserApplicationDto)
                {
                    UserApplication entitySale = Mapper.Map<UserApplicationDto, UserApplication>(dtoSale);

                    if (resultValidateInsertOrUpdateCount > 0)
                    {

                        if (resultValidateInsertOrUpdate[i])
                        {
                            context.UserApplication.Attach(entitySale);
                            context.Entry(entitySale).State = System.Data.Entity.EntityState.Modified;
                        }
                        else
                        {
                            context.UserApplication.Add(entitySale);
                        }
                    }
                    else
                    {
                        context.UserApplication.Add(entitySale);
                    }

                    listSaleResult.Add(entitySale);
                    i++;
                }

                context.SaveChanges();
            }

            listUserApplicationDto = null;
            return listSaleResult.Select(Mapper.Map<UserApplication, UserApplicationDto>).ToList();
        }
		
		/// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<UserApplicationDto> ExecuteUnPaginated(List<UserApplicationDto> listUserApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<UserApplication, UserApplicationDto>(listUserApplicationDto);

                return context.UserApplication
                .Include(ConditionalQuery.GenerateIncludes(listUserApplicationDto)).AsExpandable()
                .Where(predicate)
                .Select(Mapper.Map<UserApplication, UserApplicationDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<UserApplicationDto> ExecutePaginated(PaginationDto paginationDto, List<UserApplicationDto> listUserApplicationDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdUserApplication";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.UserApplication
				.Include(ConditionalQuery.GenerateIncludes(listUserApplicationDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listUserApplicationDto), ConditionalQuery.GenerateParametersConditionalQuery(listUserApplicationDto))
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<UserApplication, UserApplicationDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listUserApplicationDto">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<UserApplicationDto> ExecuteGetUserApplication(PaginationDto paginationDto, List<UserApplicationDto> listUserApplicationDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listUserApplicationDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listUserApplicationDto);
            }
        }
	}
}