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

namespace LinkTSP.Notification.Data.Services;

public class EventRepository : GenericRepository<Event>
{
    public EventRepository(ApplicationDbContext context) : base(context) { }

    public IEnumerable<EventViewModel> Get()
    {
        return AsQueryable().Where(w => w.StatusId == (int)EventStatus.Live).Select(s => new EventViewModel
        {
            Id = s.Id,
            Name = s.Name,
        });
    }

    public IEnumerable<EventViewModel> Get(int id)
    {
        return AsQueryable().Where(w => w.Id == id && w.StatusId == (int)EventStatus.Live).Select(s => new EventViewModel
        {
            Id = s.Id,
            Name = s.Name,
        });
    }

    public IEnumerable<EventViewModel> Get(int? pageId, int pageSize, string searchPattern, string sortColumn, ListSortDirection sortDirection)
    {
        var model = AsQueryable().Where(w => w.StatusId == (int)EventStatus.Live && w.Name.Contains(searchPattern)).Select(s => new EventViewModel
        {
            Id = s.Id,
            Name = s.Name,
        });

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

        return model;

    }

    public void Add(EventViewModel model)
    {
        var data = new Event
        {
            Id = model.Id,
            Name = model.Name,
            StatusId = (int)EventStatus.Live,
        };
        Insert(data);
    }

    public void Edit(EventViewModel model)
    {
        var data = new Event
        {
            Id = model.Id,
            Name = model.Name,
            StatusId = (int)EventStatus.Live,
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
