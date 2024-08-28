using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderService
{
    public interface IOrderService : IBaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>
    {
        Task<OrderCreateDto> CreateAsync(OrderCreateDto createDto);
        Task<OrderUpdateDto> UpdateAsync(Guid id, OrderUpdateDto updateDto);
        Task<OrderReadDto> GetByIdAsync(Guid id);
        Task<IEnumerable<OrderReadDto>> GetAllAsync();
        public Task DeleteAsync(Guid id);

    }
}