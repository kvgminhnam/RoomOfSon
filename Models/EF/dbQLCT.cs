namespace RoomOfSon.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbQLCT : DbContext
    {
        public dbQLCT()
            : base("name=dbQLCT2")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAction> tblActions { get; set; }
        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblConfirm> tblConfirms { get; set; }
        public virtual DbSet<tblHistory> tblHistories { get; set; }
        public virtual DbSet<tblMeal> tblMeals { get; set; }
        public virtual DbSet<tblPayment> tblPayments { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUser_Meal> tblUser_Meal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAction>()
                .HasMany(e => e.tblHistories)
                .WithOptional(e => e.tblAction)
                .HasForeignKey(e => e.IDAction);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<tblAdmin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblMeal>()
                .HasMany(e => e.tblUser_Meal)
                .WithOptional(e => e.tblMeal)
                .HasForeignKey(e => e.IDMeal);

            modelBuilder.Entity<tblPayment>()
                .HasMany(e => e.tblConfirms)
                .WithOptional(e => e.tblPayment)
                .HasForeignKey(e => e.IDPayment);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblConfirms)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.IDResponsible);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblHistories)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.IDUser);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblHistories1)
                .WithOptional(e => e.tblUser1)
                .HasForeignKey(e => e.IDActor);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblMeals)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.IDActor);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblPayments)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.IDUser);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblPayments1)
                .WithOptional(e => e.tblUser1)
                .HasForeignKey(e => e.IDActor);

            modelBuilder.Entity<tblUser>()
                .HasMany(e => e.tblUser_Meal)
                .WithOptional(e => e.tblUser)
                .HasForeignKey(e => e.IDUser);
        }
    }
}
