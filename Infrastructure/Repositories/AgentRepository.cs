using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AgentRepository(AppDbContext context) : Repository<Agent>(context), IAgentRepository
    {
    }
}
