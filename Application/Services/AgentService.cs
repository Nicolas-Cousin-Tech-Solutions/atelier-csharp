using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class AgentService(IRepository<Agent> repository) /*: Service<Agent>(repository), IAgentService*/
    {

    }
}
