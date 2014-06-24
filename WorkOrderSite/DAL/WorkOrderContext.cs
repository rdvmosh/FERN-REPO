using WorkOrderSite.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WorkOrderSite.DAL
{
    public class WorkOrderContext : DbContext
    {
        public WorkOrderContext()
            : base("WorkOrderContext")
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkOrder> WorkOrderSite {get; set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<PrimaryContact> PrimaryContact { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}