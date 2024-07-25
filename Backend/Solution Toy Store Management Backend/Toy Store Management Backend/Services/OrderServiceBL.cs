using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class OrderServiceBL : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepository;

        public OrderServiceBL(IRepository<int, Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<AddOrderReturnDTO> AddOrder(AddOrderDTO addOrderDTO)
        {
            try
            {
                var order = await new DTOMapper().AddOrderDtoToOrder(addOrderDTO);
                var result = await _orderRepository.Add(order);
                return await new DTOMapper().OrderToAddOrderReturnDto(result);
            }
            catch(Exception ex)
            {
                throw new OrderNotAddException();
            }
        }
    }
}
