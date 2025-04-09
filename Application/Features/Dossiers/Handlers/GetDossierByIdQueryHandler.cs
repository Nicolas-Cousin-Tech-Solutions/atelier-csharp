using Application.DTO;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Features.Dossiers.Queries;

public class GetDossierByIdQueryHandler(IDossierService dossierService) : IRequestHandler<GetDossierByIdQuery, DossierDto?>
{
    public Task<DossierDto?> Handle(GetDossierByIdQuery request, CancellationToken cancellationToken)
        => dossierService.GetByIdAsync(request.Id);
}