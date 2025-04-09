using Application.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.Dossiers.Commands;

public record CreateDossierCommand(
    string UniteProprietaire,
    List<string> NatureDossier,
    List<string> TypeDossier,
    DateTime DateDesConstatations,
    DateTime? DateDeClotureDuPv,
    DateTime DateEnregistrement
) : IRequest<DossierDto>;
