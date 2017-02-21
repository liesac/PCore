// <copyright file="NotificationsSettingsRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the REPOSITORY from NotificationsSettings.</summary>
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
using System;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Implementation
{
	/// <summary>
	/// Gets or sets the table of the application.
	/// </summary>
	/// <value>The NotificationsSettings.</value>
	/// <author>Mauricio Suárez.</author>
	public class NotificationsSettingsRepository : INotificationsSettingsRepository //BaseRepository<SecurityManagmentEntities>, 
	{
        public List<NotificationsSettingsDto> GetUpdateNotifications(List<NotificationsSettingsDto> listFilterNotificationsSettings, bool summaryView)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                List<ObjectParameter> parameters = new List<ObjectParameter> { new ObjectParameter("StartDate", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)) };

                parameters.AddRange(ConditionalQuery.GenerateParametersConditionalQuery(listFilterNotificationsSettings));
                string filterDate = (summaryView ? "SummaryEndDate" : "DashboardEndDate");

                return context.NotificationsSettings
                .Include(ConditionalQuery.GenerateIncludes(listFilterNotificationsSettings))
                .Where("(" + ConditionalQuery.GenerateConditionalQuery(listFilterNotificationsSettings) + ") AND it." + filterDate + " >= @StartDate", parameters.ToArray()).AsParallel()
                .Select(Mapper.Map<NotificationsSettings, NotificationsSettingsDto>).ToList();
            }
        }

		/// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="listNotificationsSettingsDto">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<NotificationsSettingsDto> GetNotificationsSettings(List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {
            return this.ExecuteGetNotificationsSettings(null, listNotificationsSettingsDto);
        }

        /// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listNotificationsSettingsDto">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
        /// <author>Mauricio Suárez.</author>
        public List<NotificationsSettingsDto> GetNotificationsSettings(PaginationDto paginationDto, List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {
            return this.ExecuteGetNotificationsSettings(paginationDto, listNotificationsSettingsDto);
        }
		
		/// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="lFilterNotificationsSettings">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<NotificationsSettingsDto> GetNotificationsSettings(NotificationsSettingsDto dtoNotificationsSettings)
        {
			List<NotificationsSettingsDto> listFilterNotificationsSettings = new List<NotificationsSettingsDto>();
            listFilterNotificationsSettings.Add(dtoNotificationsSettings);
            return this.ExecuteGetNotificationsSettings(null, listFilterNotificationsSettings);
        }
		
		/// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterNotificationsSettings">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
		/// <author>Mauricio Suárez.</author>
        public List<NotificationsSettingsDto> GetNotificationsSettings(PaginationDto paginationDto, NotificationsSettingsDto dtoNotificationsSettings)
        {
			List<NotificationsSettingsDto> listFilterNotificationsSettings = new List<NotificationsSettingsDto>();
            listFilterNotificationsSettings.Add(dtoNotificationsSettings);
            return this.ExecuteGetNotificationsSettings(paginationDto, listFilterNotificationsSettings);
        }
		
		/// <summary>
        /// Number of rows affected.
        /// </summary>
        /// <param name="listNotificationsSettingsDto">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>Number of rows affected.</returns>
		/// <author>Mauricio Suárez.</author>
        public int GetNotificationsSettingsCount(List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<NotificationsSettings, NotificationsSettingsDto>(listNotificationsSettingsDto);

                return context.NotificationsSettings.AsExpandable()
                .Where(predicate).AsParallel()
                .Count();
            }
        }
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataNotificationsSettings">List of data to store NotificationsSettings.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveNotificationsSettings(NotificationsSettingsDto dtoNotificationsSettings)
        {
			List<NotificationsSettingsDto> listDataNotificationsSettings = new List<NotificationsSettingsDto>();
            listDataNotificationsSettings.Add(dtoNotificationsSettings);
			return this.SaveNotificationsSettings(listDataNotificationsSettings);
		}
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listDataNotificationsSettings">List of data to store NotificationsSettings.</param>
        /// <returns>The result of processing the list.</returns>
		/// <author>Mauricio Suárez.</author>
        public bool SaveNotificationsSettings(List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())
            {
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                ObjectSet<NotificationsSettings> set = objectContext.CreateObjectSet<NotificationsSettings>();
                string[] entityOrderDetailKeys = set.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

                bool[] resultValidateInsertOrUpdate = ConditionalQuery.ValidatePrimaryKeyValueInDto(listNotificationsSettingsDto, entityOrderDetailKeys);

                int resultValidateInsertOrUpdateCount = resultValidateInsertOrUpdate.Count();

                int i = 0;
                foreach (NotificationsSettingsDto dtoNotificationsSettings in listNotificationsSettingsDto)
                {

                    if (resultValidateInsertOrUpdateCount > 0)                    {
                        NotificationsSettings entityOrderDetail = null;
                        if (resultValidateInsertOrUpdate[i])
                        {
                            entityOrderDetail = Mapper.Map<NotificationsSettingsDto, NotificationsSettings>(dtoNotificationsSettings);
                            context.Entry(entityOrderDetail).State = System.Data.Entity.EntityState.Modified;
                            context.NotificationsSettings.Attach(entityOrderDetail);
                        }
                        else
                        {
                            context.NotificationsSettings.Add(Mapper.Map<NotificationsSettingsDto, NotificationsSettings>(dtoNotificationsSettings));
                        }
                    }
                    else
                    {
                        context.NotificationsSettings.Add(Mapper.Map<NotificationsSettingsDto, NotificationsSettings>(dtoNotificationsSettings));
                    }
                    i++;
                }

                context.SaveChanges();
            }

            return true;
        }
		
		/// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="listFilterGeneric">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<NotificationsSettingsDto> ExecuteUnPaginated(List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
				var predicate = ConditionalQuery.GeneratePredicateQuery<NotificationsSettings, NotificationsSettingsDto>(listNotificationsSettingsDto);

                return context.NotificationsSettings
                .Include(ConditionalQuery.GenerateIncludes(listNotificationsSettingsDto)).AsExpandable()
                .Where(predicate).AsParallel()
                .Select(Mapper.Map<NotificationsSettings, NotificationsSettingsDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listFilterGeneric">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<NotificationsSettingsDto> ExecutePaginated(PaginationDto paginationDto, List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {
            using (SecurityManagmentEntities context = new SecurityManagmentEntities())//GetDataBaseContext())
            {
                int skipRol = paginationDto.Skip;

                if (string.IsNullOrEmpty(paginationDto.SortExpression))
                {
                    paginationDto.SortExpression = "IdNotificationsSettings";
                    //paginationDto.SortDirection = SortDirection.Ascending.ToString();
                }

                return context.NotificationsSettings
				.Include(ConditionalQuery.GenerateIncludes(listNotificationsSettingsDto))
                .Where(ConditionalQuery.GenerateConditionalQuery(listNotificationsSettingsDto), ConditionalQuery.GenerateParametersConditionalQuery(listNotificationsSettingsDto)).AsParallel()
                .AsQueryable()
                .OrderBy(paginationDto.SortExpression + " " + paginationDto.SortDirectionAbbreviation)
                .Skip(skipRol)
                .Take(paginationDto.PageSize)
                .Select(Mapper.Map<NotificationsSettings, NotificationsSettingsDto>).ToList();
            }
        }
		
		/// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listNotificationsSettingsDto">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
		/// <author>Mauricio Suárez.</author>
        private List<NotificationsSettingsDto> ExecuteGetNotificationsSettings(PaginationDto paginationDto, List<NotificationsSettingsDto> listNotificationsSettingsDto)
        {   
            if (paginationDto != null)
            {
                return this.ExecutePaginated(paginationDto, listNotificationsSettingsDto);
            }
            else
            {
                return this.ExecuteUnPaginated(listNotificationsSettingsDto);
            }
        }
	}
}