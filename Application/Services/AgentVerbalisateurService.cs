using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class AgentVerbalisateurService(IRepository<AgentVerbalisateur> repository) /*: Service<AgentVerbalisateur>(repository), IAgentVerbalisateurService*/
    {
    }
}
