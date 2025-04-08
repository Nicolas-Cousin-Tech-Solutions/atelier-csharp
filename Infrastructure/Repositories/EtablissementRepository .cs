using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EtablissementRepository(AppDbContext context) : Repository<Etablissement>(context), IEtablissementRepository
    {
    }
}
