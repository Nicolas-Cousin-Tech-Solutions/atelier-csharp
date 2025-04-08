using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Etablissement
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Dossier")]
        public Guid DossierId { get; set; }

        [Required]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Le SIRET doit être composé de 14 chiffres.")]
        public string Siret { get; set; } = string.Empty;

        public string RaisonSociale { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;

        // Navigation
        public Dossier Dossier { get; set; }
    }
}
