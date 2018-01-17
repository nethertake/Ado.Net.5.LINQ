namespace Module05LINQ
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Timer> Timer { get; set; }
        public virtual DbSet<TimerArchive> TimerArchive { get; set; }
        public virtual DbSet<TimerInactivity> TimerInactivity { get; set; }
        public virtual DbSet<TimerInactivityArchive> TimerInactivityArchive { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .Property(e => e.HoursMachines)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Document>()
                .Property(e => e.PartsCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .Property(e => e.WorkCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .Property(e => e.ConsumablesCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Document>()
                .Property(e => e.ComponentHours)
                .HasPrecision(19, 4);
        }
    }
}
