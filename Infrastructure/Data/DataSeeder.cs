using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Appliquer les migrations au cas ou elle pas encore faite
            await context.Database.MigrateAsync();

            // Vérifier si les données existent déjà
            if (!context.Services.Any()) await SeedServices(context);
            if (!context.Agents.Any()) await SeedAgents(context);
            if (!context.Dossiers.Any()) await SeedDossiers(context);
            if (!context.Etablissements.Any()) await SeedEtablissements(context);
            if (!context.Transmissions.Any()) await SeedTransmissions(context);
            if (!context.AgentVerbalisateurs.Any()) await SeedAgentsVerbalisateurs(context);
        }

        private static async Task SeedServices(AppDbContext context)
        {
            var services = new List<Service>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nom = "Service A"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Nom = "Service B"
                }
            };
            await context.Services.AddRangeAsync(services);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAgents(AppDbContext context)
        {
            var agents = new List<Agent>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Nom = "Agent A"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Nom = "Agent B"
                }
            };
            await context.Agents.AddRangeAsync(agents);
            await context.SaveChangesAsync();
        }

        private static async Task SeedDossiers(AppDbContext context)
        {
            var dossier = new Dossier
            {
                Id = Guid.NewGuid(),
                ServiceId = context.Services.First().Id,
                NatureDossier = ["Pénal", "Amende"],
                TypeDossier = ["Type1", "Type2"],
                DateDesConstatations = DateTime.UtcNow.AddDays(-30),
                DateDeClotureDuPv = DateTime.UtcNow.AddDays(-10),
                DateEnregistrement = DateTime.UtcNow,
                ReseauDeCompetences = ["Comp1", "Comp2"],
                UniteProprietaire = "Unité A"
            };
            await context.Dossiers.AddAsync(dossier);
            await context.SaveChangesAsync();
        }

        private static async Task SeedEtablissements(AppDbContext context)
        {
            var etablissement = new Etablissement
            {
                Id = Guid.NewGuid(),
                DossierId = context.Dossiers.First().Id,
                Siret = "12345678901234",
                RaisonSociale = "Artza",
                Adresse = "1 rue des tests"
            };
            await context.Etablissements.AddAsync(etablissement);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTransmissions(AppDbContext context)
        {
            var transmission = new Transmission
            {
                Id = Guid.NewGuid(),
                DossierId = context.Dossiers.First().Id,
                Parquets = ["Parquet A", "Parquet B"],
                DateEnvoi = DateTime.UtcNow,
                DessaisissementAutreParquet = "Autre parquet",
                Date = DateTime.UtcNow
            };
            await context.Transmissions.AddAsync(transmission);
            await context.SaveChangesAsync();
        }

        private static async Task SeedAgentsVerbalisateurs(AppDbContext context)
        {
            var agentVerbalisateur = new AgentVerbalisateur
            {
                Id = Guid.NewGuid(),
                DossierId = context.Dossiers.First().Id,
                ServiceId = context.Services.First().Id,
                AgentsExterieurs = ["Ext 1", "Ext 2"]
            };
            await context.AgentVerbalisateurs.AddAsync(agentVerbalisateur);
            //await context.SaveChangesAsync();
        }
    }
}
