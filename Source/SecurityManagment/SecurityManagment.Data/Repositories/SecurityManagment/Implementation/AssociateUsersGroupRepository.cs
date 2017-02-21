// <copyright file="AssociateUsersGroupRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from AssociateUsersGroup.</summary>
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
	/// <value>The AssociateUsersGroup.</value>
	/// <author>Mauricio Suárez.</author>
	public class AssociateUsersGroupRepository : IAssociateUsersGroupRepository //BaseRepository<SecurityManagmentEntities>, 
	{
		/// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="listAssociateUsersGroupDto">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<AssociateUsersGroupDto> GetAssociateUsersGroup(List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {
            return this.ExecuteGetAssociateUsersGroup(null, listAssociateUsersGroupDto);
        }

        /// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listAssociateUsersGroupDto">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<AssociateUsersGroupDto> GetAssociateUsersGroup(PaginationDto paginationDto, List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {
            return this.ExecuteGetAssociateUsersGroup(paginationDto, listAssociateUsersGroupDto);
        }
		
		/// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="lFilterAssociateUsersGroup">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<AssociateUsersGroupDto> GetAssociateUsersGroup(AssociateUsersGroupDto dtoAssociateUsersGroup)
        {
			List<AssociateUsersGroupDto> listFilterAssociateUsersGroup = new List<AssociateUsersGroupDto>();
            listFilterAssociateUsersGroup.Add(dtoAssociateUsersGroup);
            return this.ExecuteGetAssociateUsersGroup(null, listFilterAssociateUsersGroup);
        }
		
		/// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterAssociateUsersGroup">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<AssociateUsersGroupDto> GetAssociateUsersGroup(PaginationDto paginationDto, AssociateUsersGroupDto dtoAssociateUsersGroup)
        {
			List<AssociateUsersGroupDto> listFilterAssociateUsersGroup = new List<AssociateUsersGroupDto>();
            listFilterAssociateUsersGroup.Add(dtoAssociateUsersGroup);
            return this.ExecuteGetAssociateUsersGroup(paginationDto, listFilterAssociateUsersGroup);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listAssociateUsersGroupDto">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetAssociateUsersGroupCount(List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<AssociateUsersGroup, AssociateUsersGroupDto>(listAssociateUsersGroupDto);

                return context.AssociateUsersGroup.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataAssociateUsersGroup">List of data to store AssociateUsersGroup.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveAssociateUsersGroup(AssociateUsersGroupDto dtoAssociateUsersGroup)
        {
			List<AssociateUsersGroupDto> listDataAssociateUsersGroup = new List<AssociateUsersGroupDto>();
            listDataAssociateUsersGroup.Add(dtoAssociateUsersGroup);
			return this.SaveAssociateUsersGroup(listDataAssociateUsersGroup);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataAssociateUsersGroup">List of data to store AssociateUsersGroup.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveAssociateUsersGroup(List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<AssociateUsersGroup> set = objectContext.CreateObjectSet<AssociateUsersGroup>();
                string[] entityOrderDetailKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listAssociateUsersGroupDto, entityOrderDetailKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (AssociateUsersGroupDto dtoAssociateUsersGroup in listAssociateUsersGroupDto)
                {

                    if (resultValidateInsertOrUpdateCount > 0)                    {
                        AssociateUsersGroup entityOrderDetail = null;
                        if (resultValidateInsertOrUpdate[i])
                        {
                            entityOrderDetail = Mapper.Map<AssociateUsersGroupDto, AssociateUsersGroup>(dtoAssociateUsersGroup);
                            context.Entry(entityOrderDetail).State = System.Data.Entity.EntityState.Modified;
                            context.AssociateUsersGroup.Attach(entityOrderDetail);
                        }
                        else
                        {
                            context.AssociateUsersGroup.Add(Mapper.Map<AssociateUsersGroupDto, AssociateUsersGroup>(dtoAssociateUsersGroup));
                        }
                    }
                    else
                    {
                        context.AssociateUsersGroup.Add(Mapper.Map<AssociateUsersGroupDto, AssociateUsersGroup>(dtoAssociateUsersGroup));
                    }
                    i++;
                }

                context.SaveChanges();
            }

            return true;
        }
		
		/// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<AssociateUsersGroupDto> ExecuteUnPaginated(List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<AssociateUsersGroup, AssociateUsersGroupDto>(listAssociateUsersGroupDto);

                return context.AssociateUsersGroup
                .Include(ConditionalQuery.GenerateIncludes(listAssociateUsersGroupDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<AssociateUsersGroup, AssociateUsersGroupDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<AssociateUsersGroupDto> ExecutePaginated(PaginationDto paginationDto, List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdAssociateUsersGroup";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.AssociateUsersGroup
				.Include(ConditionalQuery.GenerateIncludes(listAssociateUsersGroupDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listAssociateUsersGroupDto), ConditionalQuery.GenerateParametersConditionalQuery(listAssociateUsersGroupDto)).AsParallel()
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<AssociateUsersGroup, AssociateUsersGroupDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listAssociateUsersGroupDto">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<AssociateUsersGroupDto> ExecuteGetAssociateUsersGroup(PaginationDto paginationDto, List<AssociateUsersGroupDto> listAssociateUsersGroupDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listAssociateUsersGroupDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listAssociateUsersGroupDto);
            }
        }
	}
}