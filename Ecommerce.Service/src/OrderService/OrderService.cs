using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderService
{
    public class OrderService : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>, IOrderService
    {
        public async Task<OrderCreateDto> CreateAsync(OrderCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderReadDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderUpdateDto> UpdateAsync(Guid id, OrderUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOrderStatusAsync(Guid id, OrderStatus status)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrderItemAsync(Guid orderId, OrderItemCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveOrderItemAsync(Guid orderId, Guid orderItemId)
        {
            throw new NotImplementedException();
        }
    }
}