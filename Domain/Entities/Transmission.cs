using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Transmission
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Dossier")]
        public Guid DossierId { get; set; }

        public List<string> Parquets { get; set; } = [];
        public DateTime? DateEnvoi { get; set; }
        public string DessaisissementAutreParquet { get; set; } = string.Empty;
        public DateTime? Date { get; set; }

        // Navigation
        public Dossier? Dossier { get; set; }
    }
}
