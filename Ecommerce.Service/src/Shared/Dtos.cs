using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Service.src.Shared
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateTimestamps()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
    // public class BaseEntity mainly stay in the domain layer, need to remove
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