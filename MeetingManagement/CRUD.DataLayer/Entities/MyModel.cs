namespace CRUD.DataLayer.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyModel : DbContext, IDisposable
    {
        public MyModel()
            : base("name=MyModel")
        {
        }

        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.PostelCode)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInfo>()
                .Property(e => e.EmailId)
                .IsUnicode(false);
        }
    }
}
