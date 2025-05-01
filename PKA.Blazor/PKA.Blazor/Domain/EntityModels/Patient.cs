using PKA.Blazor.Domain.EntityModels.Base;
using PKA.Blazor.Enumerations;

namespace PKA.Blazor.Domain.EntityModels
{
    public class Patient : BaseEntity<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ReasonForVisit { get; set; } = null!;
        public string PreMedicalHistory { get; set; }
    }
}
