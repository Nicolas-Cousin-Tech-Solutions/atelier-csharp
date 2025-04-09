namespace Application.Interfaces.Services
{
    public interface IService<TDto, TCreateDto, TUpdateDto>
    {
        Task<List<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TDto> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken = default);
        Task<TDto?> UpdateAsync(Guid id, TUpdateDto updateDto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
