using Microsoft.EntityFrameworkCore;
using OnionArchitecture.HospitalApi.Domain.Entities;
using OnionArchitecture.HostpitalApi.Persistence.Configurations;

namespace OnionArchitecture.HostpitalApi.Persistence.Context
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());


            base.OnModelCreating(modelBuilder);
        }
        /*
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Doctor>().HasData(new Doctor[]{

                        new() { Id=1, Name="aslı",Surname="as" },
                        new() { Id=2, Name="ayse",Surname="se" },
                        new() { Id=3, Name="veli",Surname="li" }

                    });

                    base.OnModelCreating(modelBuilder);
                }
        */
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Corporation> Corporations { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Patient> Patients { get; set; }
    }
}
