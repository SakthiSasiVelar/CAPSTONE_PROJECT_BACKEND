using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;
using Toy_Store_Management_Backend.Repositories;

namespace Toy_Store_Management_Backend.Services
{
    public class OrderServiceBL : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepository;
        private readonly IOrderItemRepository<int, OrderItem> _orderItemRepository;

        public OrderServiceBL(IRepository<int, Order> orderRepository , IOrderItemRepository<int , OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderReturnDTO> GetOrderById(int id)
        {
            try
            {
                var result = await _orderRepository.GetById(id);
                return await new DTOMapper().OrderToOrderReturnDTO(result);
            }
            catch (OrderNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new OrderNotGetException(id);
            }
        }

        public async  Task<PlaceOrderReturnDTO> PlaceOrder(PlaceOrderDTO placeOrderDTO)
        {
            try
            {
                AddOrderDTO addOrderDTO = new AddOrderDTO()
                {
                    UserId = placeOrderDTO.UserId,
                    Address = placeOrderDTO.Address,
                    TotalAmount = placeOrderDTO.TotalAmount,
                    DeliveryCharge = placeOrderDTO.DeliveryCharge,
                    ContactNumber = placeOrderDTO.ContactNumber,
                    Pincode = placeOrderDTO.Pincode,
                    SuccessFulPaymentId = placeOrderDTO.SuccessFulPaymentId,
                    Name = placeOrderDTO.Name,
                };
                var order = await new DTOMapper().AddOrderDtoToOrder(addOrderDTO);
                var orderResult = await _orderRepository.Add(order);
                var orderItemList = await new DTOMapper().AddOrderItemListToOrderItemList(placeOrderDTO.OrderItems, orderResult.Id);
                var orderItemResult = await _orderItemRepository.AddRange(orderItemList);
                return await new DTOMapper().OrderItemToPlaceOrderItemDTO(orderResult, orderItemResult);
            }
            catch(Exception ex)
            {
                throw new Exception("Error in placing the order");
            }
            
        }
    }
}
