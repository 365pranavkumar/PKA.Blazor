using PKA.Blazor.Domain.EntityModels;
using PKA.Blazor.Domain.Interfaces;

namespace PKA.Blazor.Domain.Repositories
{
    public class PatientRepository(BlazorDbContext context) : GenericRepository<Patient>(context), IPatientRepository
    {
    }
}
