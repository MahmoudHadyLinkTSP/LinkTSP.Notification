using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkTSP.Notification.ViewModels;
using LinkTSP.Notification.Data.Repositories;
using LinkTSP.Notification.Data.Models;
using System.Linq.Dynamic.Core;

namespace LinkTSP.Notification.Data.Services
{
    internal class UsersNotificationRepository : GenericRepository<UsersNotification>
    {
        public UsersNotificationRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<UsersNotificationViewModel> Get()
        {
            return AsQueryable().Select(s => new UsersNotificationViewModel
            {
                Id = s.Id,
                CreatedDate = s.CreatedDate,
                StatusId = (UsersNotificationStatus)s.StatusId,
                NotificationId = s.NotificationId,
                ReadDate = s.ReadDate,
                NotificationSubject = s.Notification.Subject,
            });
        }

        public IEnumerable<UsersNotificationViewModel> Get(int id)
        {
            return AsQueryable().Select(s => new UsersNotificationViewModel
            {
                Id = s.Id,
                CreatedDate = s.CreatedDate,
                StatusId = (UsersNotificationStatus)s.StatusId,
                NotificationId = s.NotificationId,
                ReadDate = s.ReadDate,
                NotificationSubject = s.Notification.Subject,
            });
        }

        public IEnumerable<UsersNotificationViewModel> Get(int? pageId, int pageSize, string searchPattern, string sortColumn, ListSortDirection sortDirection)
        {
            var model = AsQueryable().Where(w => w.Notification.Name.Contains(searchPattern) || w.Notification.Message.Contains(searchPattern));

            switch (sortDirection)
            {
                case ListSortDirection.Ascending:
                    model = model.OrderBy(sortColumn);
                    break;
                case ListSortDirection.Descending:
                    model = model.OrderBy(sortColumn);
                    break;
                default:
                    model = model.OrderBy(o => o.Id);
                    break;
            }

            if (pageId.HasValue)
                model = model.Skip(pageId.Value * pageSize);

            return model.Select(s => new UsersNotificationViewModel
            {
                Id = s.Id,
                CreatedDate = s.CreatedDate,
                StatusId = (UsersNotificationStatus)s.StatusId,
                NotificationId = s.NotificationId,
                ReadDate = s.ReadDate,
                NotificationSubject = s.Notification.Subject,
            });
            ;

        }

        public void Add(UsersNotificationViewModel model)
        {
            var data = new UsersNotification
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                StatusId = (int)model.StatusId,
                NotificationId = model.NotificationId,
                ReadDate = model.ReadDate,
                UserId = model.UserId,
            };
            Insert(data);
        }

        public void Edit(UsersNotificationViewModel model)
        {
            var data = new UsersNotification
            {
                Id = model.Id,
                CreatedDate = model.CreatedDate,
                StatusId = (int)model.StatusId,
                NotificationId = model.NotificationId,
                ReadDate = model.ReadDate,
                UserId = model.UserId,
            };
            Update(data);
        }

        public int Count() { return AsQueryable().Count(); }

        public void Remove(int id)
        {
            var model = AsQueryable().Where(w => w.Id == id).FirstOrDefault();
            if (model != null)
                Delete(model);
        }
    }
}
