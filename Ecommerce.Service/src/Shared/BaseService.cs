namespace Ecommerce.Service.src.Shared
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
        where T : BaseEntity
        where TReadDto : IReadDto<T>
        where TCreateDto : ICreateDto<T>
        where TUpdateDto : IUpdateDto<T>
    {
        public Task<TReadDto> CreateAsync(TCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TReadDto> UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}