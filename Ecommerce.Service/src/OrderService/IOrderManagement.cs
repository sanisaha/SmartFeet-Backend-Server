using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderService
{
    public interface IOrderManagement : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        Task<OrderCreateDto> CreateAsync(OrderCreateDto createDto);
        Task<OrderUpdateDto> UpdateAsync(Guid id, OrderUpdateDto updateDto);
        Task<OrderReadDto> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalPriceByOrderIdAsync(Guid orderId);

    }
}