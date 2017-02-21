// <copyright file="NotificationsRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from Notifications.</summary>
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
	/// <value>The Notifications.</value>
	/// <author>Mauricio Suárez.</author>
	public class NotificationsRepository : INotificationsRepository //BaseRepository<SecurityManagmentEntities>, 
	{
		/// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="listNotificationsDto">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<NotificationsDto> GetNotifications(List<NotificationsDto> listNotificationsDto)
        {
            return this.ExecuteGetNotifications(null, listNotificationsDto);
        }

        /// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listNotificationsDto">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<NotificationsDto> GetNotifications(PaginationDto paginationDto, List<NotificationsDto> listNotificationsDto)
        {
            return this.ExecuteGetNotifications(paginationDto, listNotificationsDto);
        }
		
		/// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="lFilterNotifications">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<NotificationsDto> GetNotifications(NotificationsDto dtoNotifications)
        {
			List<NotificationsDto> listFilterNotifications = new List<NotificationsDto>();
            listFilterNotifications.Add(dtoNotifications);
            return this.ExecuteGetNotifications(null, listFilterNotifications);
        }
		
		/// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterNotifications">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<NotificationsDto> GetNotifications(PaginationDto paginationDto, NotificationsDto dtoNotifications)
        {
			List<NotificationsDto> listFilterNotifications = new List<NotificationsDto>();
            listFilterNotifications.Add(dtoNotifications);
            return this.ExecuteGetNotifications(paginationDto, listFilterNotifications);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listNotificationsDto">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetNotificationsCount(List<NotificationsDto> listNotificationsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<Notifications, NotificationsDto>(listNotificationsDto);

                return context.Notifications.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataNotifications">List of data to store Notifications.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveNotifications(NotificationsDto dtoNotifications)
        {
			List<NotificationsDto> listDataNotifications = new List<NotificationsDto>();
            listDataNotifications.Add(dtoNotifications);
			return this.SaveNotifications(listDataNotifications);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataNotifications">List of data to store Notifications.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveNotifications(List<NotificationsDto> listNotificationsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<Notifications> set = objectContext.CreateObjectSet<Notifications>();
                string[] entityOrderDetailKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listNotificationsDto, entityOrderDetailKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (NotificationsDto dtoNotifications in listNotificationsDto)
                {

                    if (resultValidateInsertOrUpdateCount > 0)                    {
                        Notifications entityOrderDetail = null;
                        if (resultValidateInsertOrUpdate[i])
                        {
                            entityOrderDetail = Mapper.Map<NotificationsDto, Notifications>(dtoNotifications);
                            context.Entry(entityOrderDetail).State = System.Data.Entity.EntityState.Modified;
                            context.Notifications.Attach(entityOrderDetail);
                        }
                        else
                        {
                            context.Notifications.Add(Mapper.Map<NotificationsDto, Notifications>(dtoNotifications));
                        }
                    }
                    else
                    {
                        context.Notifications.Add(Mapper.Map<NotificationsDto, Notifications>(dtoNotifications));
                    }
                    i++;
                }

                context.SaveChanges();
            }

            return true;
        }
		
		/// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<NotificationsDto> ExecuteUnPaginated(List<NotificationsDto> listNotificationsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<Notifications, NotificationsDto>(listNotificationsDto);

                return context.Notifications
                .Include(ConditionalQuery.GenerateIncludes(listNotificationsDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<Notifications, NotificationsDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<NotificationsDto> ExecutePaginated(PaginationDto paginationDto, List<NotificationsDto> listNotificationsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdNotification";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.Notifications
				.Include(ConditionalQuery.GenerateIncludes(listNotificationsDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listNotificationsDto), ConditionalQuery.GenerateParametersConditionalQuery(listNotificationsDto)).AsParallel()
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<Notifications, NotificationsDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listNotificationsDto">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<NotificationsDto> ExecuteGetNotifications(PaginationDto paginationDto, List<NotificationsDto> listNotificationsDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listNotificationsDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listNotificationsDto);
            }
        }
	}
}