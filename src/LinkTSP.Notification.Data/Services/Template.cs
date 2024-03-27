using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LinkTSP.Notification.Data.Models;
using LinkTSP.Notification.Data.Repositories;
using LinkTSP.Notification.ViewModels;
using System.Linq.Dynamic.Core;

namespace LinkTSP.Notification.Data.Services
{
    public class TemplateRepository : GenericRepository<Template>
    {
        public TemplateRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<TemplateViewModel> Get()
        {
            return AsQueryable().Where(w => w.StatusId == (int)TemplateStatus.Live).Select(s => new TemplateViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Subject = s.Subject,
                Message = s.Message,
            });
        }

        public IEnumerable<TemplateViewModel> Get(int id)
        {
            return AsQueryable().Where(w => w.Id == id && w.StatusId == (int)TemplateStatus.Live).Select(s => new TemplateViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Subject = s.Subject,
                Message = s.Message,
            });
        }

        public IEnumerable<TemplateViewModel> Get(int? pageId, int pageSize, string searchPattern, string sortColumn, ListSortDirection sortDirection)
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

            return model.Select(s => new TemplateViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Subject = s.Subject,
                Message = s.Message,
            });

        }

        public void Add(TemplateViewModel model)
        {
            var data = new Template
            {
                Id = model.Id,
                Name = model.Name,
                Message = model.Message,
                StatusId = (int)TemplateStatus.Live,
                Subject = model.Subject
            };
            Insert(data);
        }

        public void Edit(TemplateViewModel model)
        {
            var data = new Template
            {
                Id = model.Id,
                Name = model.Name,
                Message = model.Message,
                StatusId = (int)TemplateStatus.Live,
                Subject = model.Subject
            };
            Update(data);
        }

        public int Count() { return AsQueryable().Count(); }

        public void Remove(int id)
        {
            var model = AsQueryable().Where(w => w.Id == id);
            //if (model != null)
            Delete(model);
        }
    }
}
