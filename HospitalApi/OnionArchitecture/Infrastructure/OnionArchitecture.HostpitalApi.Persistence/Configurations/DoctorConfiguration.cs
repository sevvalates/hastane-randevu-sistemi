using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.HospitalApi.Domain.Entities;

namespace OnionArchitecture.HostpitalApi.Persistence.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasOne(x => x.Service).WithMany(x => x.Doctors).HasForeignKey(x => x.ServiceId);
        }
    }
}
