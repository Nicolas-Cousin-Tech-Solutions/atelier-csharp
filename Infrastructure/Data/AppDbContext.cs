using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<Etablissement> Etablissements { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<AgentVerbalisateur> AgentVerbalisateurs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // stocké en chaîne séparée par des points-virgules
            var splitStringConverter = new ValueConverter<List<string>, string>(
                v => string.Join(";", v),
                v => v.Split(new[] { ';' }, StringSplitOptions.None).ToList());

            // Configuration pour l'entité Dossier
            modelBuilder.Entity<Dossier>()
                .Property(d => d.NatureDossier)
                .HasConversion(splitStringConverter);

            modelBuilder.Entity<Dossier>()
                .Property(d => d.TypeDossier)
                .HasConversion(splitStringConverter);

            modelBuilder.Entity<Dossier>()
                .Property(d => d.ReseauDeCompetences)
                .HasConversion(splitStringConverter);

            // Pour Transmission
            modelBuilder.Entity<Transmission>()
                .Property(t => t.Parquets)
                .HasConversion(splitStringConverter);

            // Pour AgentVerbalisateur
            modelBuilder.Entity<AgentVerbalisateur>()
                .Property(a => a.AgentsExterieurs)
                .HasConversion(splitStringConverter);
        }
    }
}
