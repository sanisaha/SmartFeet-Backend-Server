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
        private readonly IBaseRepository<T> _repo;

        public BaseService(IBaseRepository<T> repo)
        {
            _repo = repo;
        }
        public virtual async Task<TReadDto> CreateAsync(TCreateDto createDto)
        {
            var entity = createDto.CreateEntity();
            await _repo.CreateAsync(entity);
            var readDto = Activator.CreateInstance<TReadDto>();
            readDto.FromEntity(entity);
            return readDto;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteByIdAsync(id);
        }

        public virtual async Task<IEnumerable<TReadDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return entities.Select(entity =>
            {
                var readDto = Activator.CreateInstance<TReadDto>();
                readDto.FromEntity(entity);
                return readDto;
            });
        }

        public virtual async Task<TReadDto> GetByIdAsync(Guid id)
        {
            var entity = await _repo.GetAsync(e => e.Id == id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            var readDto = Activator.CreateInstance<TReadDto>();
            readDto.FromEntity(entity);
            return readDto;
        }

        public virtual async Task<TReadDto> UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            var entity = await _repo.GetAsync(e => e.Id == id);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            entity = updateDto.UpdateEntity(entity);
            await _repo.UpdateByIdAsync(entity);
            var readDto = Activator.CreateInstance<TReadDto>();
            readDto.FromEntity(entity);
            return readDto;
        }
    }
}