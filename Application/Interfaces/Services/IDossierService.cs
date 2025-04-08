using Application.DTO;

namespace Application.Interfaces.Services
{
    public interface IDossierService : IService<DossierDto, CreateDossierDto,UpdateDossierDto> { }
}
