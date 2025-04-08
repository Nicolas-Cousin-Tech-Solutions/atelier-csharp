using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Dossier
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Indique si le dossier est pénal (true) ou une amende administrative (false).
        /// </summary>
        public bool IsPenal { get; set; }

        // Listes de valeurs (à convertir pour le stockage)
        public List<string> NatureDossier { get; set; } = [];
        public List<string> TypeDossier { get; set; } = [];

        public DateTime DateDesConstatations { get; set; }
        public DateTime? DateDeClotureDuPv { get; set; }
        public DateTime DateEnregistrement { get; set; }
        public List<string> ReseauDeCompetences { get; set; } = [];
        public string UniteProprietaire { get; set; } = string.Empty;

        // Propriétés de navigation
        public Service? Service { get; set; }
        public ICollection<Etablissement> Etablissements { get; set; } = [];
        public Transmission? Transmission { get; set; }
        public ICollection<AgentVerbalisateur> AgentVerbalisateurs { get; set; } = [];

        // Exemple de méthode de validation (les règles métiers pourront aussi être implémentées ailleurs)
        public IEnumerable<string> Validate()
        {
            var errors = new List<string>();

            // Règle : Date de clôture du PV doit être postérieure à Date des constatations (si renseignée)
            if (DateDeClotureDuPv.HasValue && DateDeClotureDuPv.Value <= DateDesConstatations)
            {
                errors.Add("La date de clôture du PV doit être postérieure à la date des constatations.");
            }

            // Règles pour dossier pénal
            if (IsPenal)
            {
                if (NatureDossier == null || !NatureDossier.Any())
                    errors.Add("Pour un dossier pénal, un item doit être sélectionné dans la liste 'Nature du dossier'.");
                if (TypeDossier == null || !TypeDossier.Any())
                    errors.Add("Pour un dossier pénal, un item doit être sélectionné dans la liste 'Type de dossier'.");
            }

            return errors;
        }
    }
}
