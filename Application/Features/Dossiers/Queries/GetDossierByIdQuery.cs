using Application.DTO;
using MediatR;

namespace Application.Features.Dossiers.Queries;

public record GetDossierByIdQuery(Guid Id): IRequest<DossierDto?>;
