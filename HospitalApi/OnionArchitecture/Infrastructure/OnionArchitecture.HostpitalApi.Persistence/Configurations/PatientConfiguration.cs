using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.HospitalApi.Domain.Entities;


namespace OnionArchitecture.HostpitalApi.Persistence.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasOne(x => x.Corporation).WithMany(x => x.Patients).HasForeignKey(x => x.CorporationId);
        }
    }
}
