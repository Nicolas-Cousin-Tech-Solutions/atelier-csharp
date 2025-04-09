using Application.DTO;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Features.Dossiers.Queries;

public class GetAllDossiersQueryHandler(IDossierService dossierService) : IRequestHandler<GetAllDossiersQuery, IReadOnlyList<DossierDto>>
{
    public async Task<IReadOnlyList<DossierDto>> Handle(GetAllDossiersQuery request, CancellationToken cancellationToken)
        => await dossierService.GetAllAsync() ?? [];
}