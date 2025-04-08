using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class EtablissementService(IRepository<Etablissement> repository) /*: Service<Etablissement>(repository), IEtablissementService*/
    {
    }
}
