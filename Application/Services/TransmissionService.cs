using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class TransmissionService(IRepository<Transmission> repository) /*: BaseService<Transmission>(repository), ITransmissionService*/
    {
    }
}
