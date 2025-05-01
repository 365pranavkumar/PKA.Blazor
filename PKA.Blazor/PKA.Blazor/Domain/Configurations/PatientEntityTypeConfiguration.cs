using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PKA.Blazor.Domain.EntityModels;

namespace PKA.Blazor.Domain.Configurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.Gender)
                .IsRequired();

            builder.Property(p => p.ReasonForVisit)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.PreMedicalHistory)
                .HasMaxLength(150);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
