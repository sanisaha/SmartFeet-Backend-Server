namespace Ecommerce.Service.src.Shared
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    where T : BaseEntity
    where TReadDto : IReadDto<T>
    where TCreateDto : ICreateDto<T>
    where TUpdateDto : IUpdateDto<T>
    {
        Task<IEnumerable<TReadDto>> GetAllAsync();
        Task<TReadDto> GetByIdAsync(Guid id);
        Task<TReadDto> CreateAsync(TCreateDto createDto);
        Task<TReadDto> UpdateAsync(Guid id, TUpdateDto updateDto);
        Task DeleteAsync(Guid id);
    }
}