using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class AgentVerbalisateur
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Dossier")]
        public Guid DossierId { get; set; }

        [ForeignKey("Agent")]
        public Guid AgentId { get; set; }

        /// <summary>
        /// True si cet agent est le verbalisateur principal.
        /// </summary>
        public bool IsPrincipal { get; set; }

        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }

        public List<string> AgentsExterieurs { get; set; } = [];

        // Propriétés de navigation
        public Dossier Dossier { get; set; }
        public Agent Agent { get; set; }
        public Service Service { get; set; }
    }
}
