using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Agent
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        // Navigation
        public ICollection<AgentVerbalisateur> AgentVerbalisateurs { get; set; }
    }
}
