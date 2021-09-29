using BlazorScheduler.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BlazorScheduler.Server.Data
{
    public class SchedulerContext : DbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options) { }

        public virtual DbSet<EventModel> EventModels { get; set; }
        public virtual DbSet<ResourceModel> ResourceModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory().Replace("Server", "Shared") + "\\App_Data\\ScheduleData.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventModel>().ToTable("EventData");
            modelBuilder.Entity<ResourceModel>().ToTable("ResourceData");
        }

    }

}
