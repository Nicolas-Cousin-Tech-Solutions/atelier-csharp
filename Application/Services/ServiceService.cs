using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ServiceService(IRepository<Service> repository) /*: Service<Service>(repository), IServiceService*/
    {
    }
}
