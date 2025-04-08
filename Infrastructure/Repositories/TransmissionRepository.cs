using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TransmissionRepository(AppDbContext context) : Repository<Transmission>(context), ITransmissionRepository
    {
    }
}
