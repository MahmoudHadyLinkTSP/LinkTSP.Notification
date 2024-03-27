

using LinkTSP.Notification.Data.Services;

namespace LinkTSP.Notification.Data.Repositories;

public class UnitOfWork
{
    private readonly ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    private TemplateRepository templateRepository=null;
    public TemplateRepository Template => templateRepository ?? new TemplateRepository(_context);

    private NotificationRepository notificationRepository=null;
    public NotificationRepository Notification => notificationRepository ?? new NotificationRepository(_context);


    private EventRepository eventRepository=null;
    public EventRepository Event => eventRepository ?? new EventRepository(_context);

}
