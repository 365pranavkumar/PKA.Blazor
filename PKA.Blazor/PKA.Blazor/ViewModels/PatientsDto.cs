using PKA.Blazor.Enumerations;

namespace PKA.Blazor.ViewModels
{
    public class PatientsDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string ReasonForVisit { get; set; }
        public string PreMedicalHistory { get; set; }
    }
}
