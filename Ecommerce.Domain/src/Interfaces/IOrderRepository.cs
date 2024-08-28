using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.OrderAggregate;

namespace Ecommerce.Domain.src.Interface.OrderInterface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalPriceByOrderIdAsync(Guid orderId);
    }
}