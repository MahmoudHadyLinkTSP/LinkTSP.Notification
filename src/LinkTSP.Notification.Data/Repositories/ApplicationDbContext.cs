using EntityFrameworkCore.Triggers;
using LinkTSP.Notification.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkTSP.Notification.Data.Repositories;
    
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }    

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Models.Notification> Notifications { get; set; }

    public virtual DbSet<NotificationChannel> NotificationChannels { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<UsersNotification> UsersNotifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
        });

        modelBuilder.Entity<Models.Notification>(entity =>
        {
            entity.HasIndex(e => e.TemplateId, "IX_Notifications_TemplateId");

            entity.HasIndex(e => e.UserId, "IX_Notifications_UserId");

            entity.Property(e => e.CallToAction).HasMaxLength(2048);
            entity.Property(e => e.ImageUrl).HasMaxLength(256);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Subject).HasMaxLength(256);

            entity.HasOne(d => d.Template).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                       
        });

        modelBuilder.Entity<NotificationChannel>(entity =>
        {
            entity.HasIndex(e => e.NotificationId, "IX_NotificationChannels_NotificationId");

            entity.HasOne(d => d.Notification).WithMany(p => p.Channels).HasForeignKey(d => d.NotificationId);
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.Subject).HasMaxLength(256);
        });

        modelBuilder.Entity<UsersNotification>(entity =>
        {
            entity.HasIndex(e => e.NotificationId, "IX_UsersNotifications_NotificationId");

            entity.HasIndex(e => e.UserId, "IX_UsersNotifications_UserId");

            entity.HasOne(d => d.Notification).WithMany(p => p.Users).HasForeignKey(d => d.NotificationId);
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

