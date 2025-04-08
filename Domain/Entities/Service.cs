using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        // Navigation
        public ICollection<Dossier> Dossiers { get; set; } = [];
        public ICollection<AgentVerbalisateur> AgentVerbalisateurs { get; set; } = [];
    }
}
