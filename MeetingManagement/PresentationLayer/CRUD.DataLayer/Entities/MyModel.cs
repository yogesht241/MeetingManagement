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

        //public virtual DbSet<AttendeeInfo> AttendeeInfos { get; set; }
        public virtual DbSet<MeetingInfo> MeetingInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<MeetingInfo>()
               .Property(e => e.Subject)
               .IsUnicode(false);

            modelBuilder.Entity<MeetingInfo>()
                .Property(e => e.Agenda)
                .IsUnicode(false);

            modelBuilder.Entity<MeetingInfo>()
                .Property(e => e.Attendees)
                .IsUnicode(false);

            modelBuilder.Entity<MeetingInfo>()
                .Property(e => e.DateTime);

            //modelBuilder.Entity<AttendeeInfo>()
            //  .Property(e => e.Name)
            //  .IsUnicode(false);

        }
    }
}
