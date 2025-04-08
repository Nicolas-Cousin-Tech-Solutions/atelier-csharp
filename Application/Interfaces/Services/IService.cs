namespace Application.Interfaces.Services
{
    public interface IService<TDto, TCreateDto, TUpdateDto>
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task<TDto?> UpdateAsync(Guid id, TUpdateDto updateDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
