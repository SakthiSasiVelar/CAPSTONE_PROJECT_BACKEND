using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class OrderItemServiceBL : IOrderItemService
    {
        private readonly IRepository<int,OrderItem> _orderItemRepository;

        public OrderItemServiceBL(IRepository<int, OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<AddOrderItemReturnDTO> AddOrderItem(AddOrderItemDTO addOrderItemDTO)
        {
            try
            {
                var orderItem = await new DTOMapper().AddOrderItemDtoToOrderItem(addOrderItemDTO);
                var result = await _orderItemRepository.Add(orderItem);
                return await new DTOMapper().OrderItemToAddOrderItemReturnDto(orderItem);
            }
            catch(Exception ex)
            {
                throw new OrderItemNotAddException();
            }
        }

        public async Task<UpdateOrderItemStatusReturnDTO> UpdateOrderItemStatus(UpdateOrderItemStatusDTO updateOrderItemStatusDTO)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetById(updateOrderItemStatusDTO.OrderItemId);
                orderItem.OrderStatus = updateOrderItemStatusDTO.OrderItemStatus;    
                orderItem.StatusActionDateTime = await GetCurrentDateTime();
                var updatedOrderItem = await _orderItemRepository.Update(orderItem);
                return await new DTOMapper().OrderItemToUpdateOrderItemStatusReturnDTO(updatedOrderItem);

            }
            catch (OrderItemNotAddException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception("error in updating order item status");
            }
        }


        public async Task<DateTime> GetCurrentDateTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
            return istNow;
        }
    }
}
