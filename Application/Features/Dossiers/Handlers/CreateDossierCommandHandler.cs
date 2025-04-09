using Application.DTO;
using Application.Features.Dossiers.Commands;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Features.Dossiers.Handlers;

public class CreateDossierCommandHandler(IDossierService dossierService)
    : IRequestHandler<CreateDossierCommand, DossierDto>
{
    public async Task<DossierDto> Handle(CreateDossierCommand request, CancellationToken cancellationToken)
    {
        return await dossierService.CreateAsync(new CreateDossierDto(
                    request.UniteProprietaire,
                    request.NatureDossier,
                    request.TypeDossier,
                    request.DateDesConstatations,
                    request.DateDeClotureDuPv,
                    request.DateEnregistrement
                ));
    }
}