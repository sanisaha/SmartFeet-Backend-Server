using Ecommerce.Domain.Enums;
using Ecommerce.Domain.src.Entities.OrderAggregate;
using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Domain.src.Model;
using Ecommerce.Domain.src.Shared;
using Ecommerce.Service.src.Shared;

namespace Ecommerce.Service.src.OrderService
{
    public class OrderManagement : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto>, IOrderManagement
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        public OrderManagement(IOrderRepository orderRepository, IUserRepository userRepository, IAddressRepository addressRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }

        public override async Task<PaginatedResult<OrderReadDto>> GetAllAsync(PaginationOptions paginationOptions)
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync(paginationOptions);
                var orderDtos = orders.Items.Select(order =>
                {
                    var dto = Activator.CreateInstance<OrderReadDto>();
                    dto.FromEntity(order);
                    return dto;
                });

                return new PaginatedResult<OrderReadDto>
                {
                    Items = orderDtos,
                    TotalPages = orders.TotalPages,
                    CurrentPage = orders.CurrentPage,
                };
            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            try
            {
                var user = await _userRepository.GetAsync(userId);
                if (user == null)
                    throw new ArgumentException("Invalid user.");

                var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
                var orderDtos = orders.Select(order =>
                {
                    var dto = new OrderReadDto();
                    dto.FromEntity(order);
                    return dto;
                });

                return orderDtos;
            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByStatusAsync(OrderStatus status)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByStatusAsync(status);
                var orderDtos = orders.Select(order =>
                {
                    var dto = new OrderReadDto();
                    dto.FromEntity(order);
                    return dto;
                });
                return orderDtos;
            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");
            }
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByDateRangeAsync(startDate, endDate);
                var orderDtos = orders.Select(order =>
                {
                    var dto = new OrderReadDto();
                    dto.FromEntity(order);
                    return dto;
                });
                return orderDtos;

            }
            catch
            {
                throw new Exception("Error Retrieving Orders!.");

            }
        }

        public async Task<decimal> GetTotalPriceByOrderIdAsync(Guid orderId)
        {
            try
            {
                var order = await _orderRepository.GetAsync(orderId);
                if (order == null)
                    throw new ArgumentException("Order not found.");

                return await _orderRepository.GetTotalPriceByOrderIdAsync(orderId);
            }
            catch
            {
                throw new Exception("Error Retrieving Total price!.");

            }
        }
    }
}