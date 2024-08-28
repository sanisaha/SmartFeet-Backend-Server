using Ecommerce.Domain.src.Interface;
using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Service.src.Shared
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
        where T : BaseEntity
        where TReadDto : IReadDto<T>
        where TCreateDto : ICreateDto<T>
        where TUpdateDto : IUpdateDto<T>
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<TReadDto> CreateAsync(TCreateDto createDto)
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