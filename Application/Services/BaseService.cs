using Application.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class BaseService<TEntity, TDto, TCreateDto, TUpdateDto>(
        IRepository<TEntity> repository,
        Func<TEntity, TDto> mapToDto,
        Func<TCreateDto, TEntity> mapToEntity,
        Action<TEntity, TUpdateDto> mapUpdateDto) : IService<TDto, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        public async Task<List<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(mapToDto).ToList();
        }

        public async Task<TDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await repository.GetByIdAsync(id);
            return entity is null ? default : mapToDto(entity);
        }

        public async Task<TDto> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken = default)
        {
            var entity = mapToEntity(createDto);
            await repository.AddAsync(entity);
            return mapToDto(entity);
        }

        public async Task<TDto?> UpdateAsync(Guid id, TUpdateDto updateDto, CancellationToken cancellationToken = default)
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "L'entité avec l'ID spécifié est introuvable.");

            mapUpdateDto(entity, updateDto);
            await repository.UpdateAsync(entity);

            return mapToDto(entity);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
