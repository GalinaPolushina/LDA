namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LDA : DbContext
    {
        public LDA()
            : base("name=LDA")
        {
        }

        public virtual DbSet<Fert_List> Fert_List { get; set; }
        public virtual DbSet<Fertilizer> Fertilizers { get; set; }
        public virtual DbSet<Flowering_Beginning> Flowering_Beginning { get; set; }
        public virtual DbSet<Flowering_Ending> Flowering_Ending { get; set; }
        public virtual DbSet<Flowering_List> Flowering_List { get; set; }
        public virtual DbSet<Life_Form> Life_Form { get; set; }
        public virtual DbSet<Lifespan> Lifespans { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<Planting> Plantings { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Soil_Type> Soil_Type { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fertilizer>()
                .Property(e => e.Fert_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Flowering_Beginning>()
                .Property(e => e.FlowBeg_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Flowering_Beginning>()
                .HasMany(e => e.Flowering_List)
                .WithRequired(e => e.Flowering_Beginning)
                .HasForeignKey(e => e.FTB_ID);

            modelBuilder.Entity<Flowering_Ending>()
                .Property(e => e.FlowEnd_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Flowering_Ending>()
                .HasMany(e => e.Flowering_List)
                .WithRequired(e => e.Flowering_Ending)
                .HasForeignKey(e => e.FTE_ID);

            modelBuilder.Entity<Life_Form>()
                .Property(e => e.LF_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Life_Form>()
                .HasMany(e => e.Plants)
                .WithRequired(e => e.Life_Form)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lifespan>()
                .Property(e => e.Lifespan1)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.Plant_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.Cutting_Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.Fert_Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.Watering_Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .HasMany(e => e.Fert_List)
                .WithRequired(e => e.Plant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plant>()
                .HasMany(e => e.Flowering_List)
                .WithRequired(e => e.Plant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plant>()
                .HasMany(e => e.Plantings)
                .WithRequired(e => e.Plant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Planting>()
                .Property(e => e.Planting_Date)
                .IsUnicode(false);

            modelBuilder.Entity<Planting>()
                .Property(e => e.Planting_Place)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Project_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Soil_Type>()
                .Property(e => e.ST_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Status_Name)
                .IsUnicode(false);
        }
    }
}
