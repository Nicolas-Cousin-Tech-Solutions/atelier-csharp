using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AgentVerbalisateurRepository(AppDbContext context) : Repository<AgentVerbalisateur>(context), IAgentVerbalisateurRepository
    {
    }
}
