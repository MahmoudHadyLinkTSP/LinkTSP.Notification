using LinkTSP.Notification.Data.Repositories;
using LinkTSP.Notification.Data.Models;
using LinkTSP.Notification.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System;
using System.Linq.Dynamic.Core;

namespace LinkTSP.Notification.Data.Services
{
    public class NotificationRepository : GenericRepository<Models.Notification>
    {
        ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<NotificationViewModel> Get()
        {
            return AsQueryable().Where(w => w.StatusId != (int)NotificationStatus.Deleted).Select(s => new NotificationViewModel
            {
                Id = s.Id,
                //UserId = s.UserId,
                CallToAction = s.CallToAction,
                CreatedAt = s.CreatedAt,
                ImageUrl = s.ImageUrl,
                SendAt = s.SendAt,
                StatusId = (NotificationStatus)s.StatusId,
                Template = s.Template.Name,
            });
        }

        public IEnumerable<NotificationViewModel> Get(int id)
        {
            return AsQueryable().Where(w => w.Id == id).Select(s => new NotificationViewModel
            {
                Id = s.Id,
                UserId = s.UserId,
                CallToAction = s.CallToAction,
                CreatedAt = s.CreatedAt,
                ImageUrl = s.ImageUrl,
                SendAt = s.SendAt,
                StatusId = (NotificationStatus)s.StatusId,
                Template = s.Template.Name,
                Message = s.Message,
                Subject = s.Subject,
                Name = s.Name,
            });
        }

        public IEnumerable<NotificationViewModel> Get(int? pageId, int pageSize, string searchPattern, string sortColumn, ListSortDirection sortDirection)
        {
            var model = AsQueryable().Where(w => w.StatusId == (int)TemplateStatus.Live && w.Name.Contains(searchPattern) || w.Message.Contains(searchPattern));

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

            return model.Select(s => new NotificationViewModel
            {
                Id = s.Id,
                Name = s.Name,
                CreatedAt = s.CreatedAt,
            });
            ;

        }

        public void Add(NotificationViewModel model)
        {
            var data = new Models.Notification
            {
                Id = model.Id,
                Name = model.Name,
                Message = model.Message,
                StatusId = (int)TemplateStatus.Live,
                Subject = model.Subject,
                CallToAction = model.CallToAction,
                CreatedAt = DateTime.Now,
                ImageUrl = model.ImageUrl,
                SendAt = model.SendAt,
                TemplateId = model.TemplateId,
                UserId = model.UserId,
                Channels = model.Channels.Select(s => new NotificationChannel { Id = s.Id, ChannelId = s.ChannelId, NotificationId = model.Id, }).ToList(),
                Users = model.Users.Select(s => new UsersNotification { Id = s.Id, UserId = s.UserId, NotificationId = model.Id, StatusId = (int)UsersNotificationStatus.New, CreatedDate = DateTime.Now, }).ToList(),
            };
            Insert(data);
        }

        public void Edit(NotificationViewModel model)
        {
            var data = new Models.Notification
            {
                Id = model.Id,
                Name = model.Name,
                Message = model.Message,
                StatusId = (int)TemplateStatus.Live,
                Subject = model.Subject,
                CallToAction = model.CallToAction,
                CreatedAt = model.CreatedAt,
                ImageUrl = model.ImageUrl,
                SendAt = model.SendAt,
                TemplateId = model.TemplateId,
                UserId = model.UserId,
                Channels = model.Channels.Select(s => new NotificationChannel { Id = s.Id, ChannelId = s.ChannelId, NotificationId = model.Id }).ToList()
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

        protected override void Update(Models.Notification model)
        {
            var channels = _context.NotificationChannels.Where(w => w.NotificationId == model.Id);
            var channelsRemoved = channels.Where(w => !model.Channels.Select(s => s.Id).Contains(w.Id));

            _context.NotificationChannels.RemoveRange(channelsRemoved);

            var channelsModified = channels.Where(w => model.Channels.Select(s => s.Id).Contains(w.Id));

            foreach (var item in model.Channels.Where(w => w.Id != 0))
            {
                context.Entry(item).State = EntityState.Modified;
            }

            _context.NotificationChannels.AddRange(model.Channels.Where(s => s.Id == 0));
            base.Update(model);
        }
    }
}
