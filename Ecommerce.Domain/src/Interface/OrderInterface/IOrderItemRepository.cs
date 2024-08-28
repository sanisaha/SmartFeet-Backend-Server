using Ecommerce.Domain.src.Entities.OrderAggregate;

namespace Ecommerce.Domain.src.Interface.OrderInterface
{
    public interface IOrderDetailRepository : IBaseRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(Guid orderId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByProductIdAsync(Guid productId);
        Task<int> GetTotalQuantityByOrderIdAsync(Guid orderId);
    }
}