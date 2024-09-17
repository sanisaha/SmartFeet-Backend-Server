using Ecommerce.Domain.src.Shared;

namespace Ecommerce.Service.src.Shared
{
    public interface IReadDto<T> where T : BaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }

        public void FromEntity(T entity);
    }

    public interface ICreateDto<T>
    {
        public T CreateEntity();
    }

    public interface IUpdateDto<T>
    {
        public Guid Id { get; set; }
        public T UpdateEntity(T entity);
    }

    public class BaseReadDto<T> : IReadDto<T> where T : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual void FromEntity(T entity)
        {
            Id = entity.Id;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
        }
    }
}