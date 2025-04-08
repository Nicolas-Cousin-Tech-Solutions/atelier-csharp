using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class DossierRepository(AppDbContext context) : Repository<Dossier>(context), IDossierRepository
    {
    }
}
