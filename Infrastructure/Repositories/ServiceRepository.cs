using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ServiceRepository(AppDbContext context) : Repository<Service>(context), IServiceRepository
    {
    }
}
