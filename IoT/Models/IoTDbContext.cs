namespace IoT.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IoTDbContext : DbContext
    {
        public IoTDbContext()
            : base("name=IoTDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Arduino> Arduinoes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CycleTime> CycleTimes { get; set; }
        public virtual DbSet<MaxCycleTime> MaxCycleTimes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DisplayData> DisplayDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaxCycleTime>()
                .Property(e => e.Station)
                .IsUnicode(false);
        }
    }
}
