using Ecommerce.Service.src.OrderService;

namespace Ecommerce.Service.src.OrderItemService
{
    public interface IOrderItemManagement
    {
        Task<OrderCreateDto> CreateAsync(OrderCreateDto createDto);
        Task<bool> UpdateAsync(Guid id, OrderUpdateDto updateDto);
        Task<OrderReadDto> GetByIdAsync(Guid id);
        public Task DeleteAsync(Guid id);
        Task<IEnumerable<OrderReadDto>> GetOrderItemsByOrderIdAsync(Guid orderId);
        Task<IEnumerable<OrderReadDto>> GetOrderItemsByProductIdAsync(Guid productId);
        Task<int> GetTotalQuantityByOrderIdAsync(Guid orderId);
    }
}