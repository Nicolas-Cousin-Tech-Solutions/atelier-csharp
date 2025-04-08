using Application.DTO;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class DossierService : BaseService<Dossier, DossierDto, CreateDossierDto, UpdateDossierDto>, IDossierService
    {
        public DossierService(IDossierRepository repository)
            : base(
                repository,
                dossier => new DossierDto(
                    dossier.Id, dossier.UniteProprietaire, dossier.NatureDossier,
                    dossier.TypeDossier, dossier.DateDesConstatations, dossier.DateDeClotureDuPv,
                    dossier.DateEnregistrement
                ),
                dto => new Dossier
                {
                    Id = Guid.NewGuid(),
                    UniteProprietaire = dto.UniteProprietaire,
                    NatureDossier = dto.NatureDossier,
                    TypeDossier = dto.TypeDossier,
                    DateDesConstatations = dto.DateDesConstatations,
                    DateDeClotureDuPv = dto.DateDeClotureDuPv,
                    DateEnregistrement = dto.DateEnregistrement
                },
                (dossier, dto) =>
                {
                    dossier.UniteProprietaire = dto.UniteProprietaire;
                    dossier.NatureDossier = dto.NatureDossier;
                    dossier.TypeDossier = dto.TypeDossier;
                    dossier.DateDesConstatations = dto.DateDesConstatations;
                    dossier.DateDeClotureDuPv = dto.DateDeClotureDuPv;
                    dossier.DateEnregistrement = dto.DateEnregistrement;
                })
        { }
    }

}
