using Application.DTO;
using MediatR;

namespace Application.Features.Dossiers.Queries;

public record GetAllDossiersQuery() : IRequest<IReadOnlyList<DossierDto>>;

