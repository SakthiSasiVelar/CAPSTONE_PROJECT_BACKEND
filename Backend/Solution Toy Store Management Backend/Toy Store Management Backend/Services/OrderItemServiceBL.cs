using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Enums;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class OrderItemServiceBL : IOrderItemService
    {
        private readonly IOrderItemRepository<int,OrderItem> _orderItemRepository;

        public OrderItemServiceBL(IOrderItemRepository<int, OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
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
            catch (OrderItemNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception("error in updating order item status");
            }
        }

        public async  Task<CancelOrderItemReturnDTO> CancelOrderItem(CancelOrderItemDTO cancelOrderItemDTO)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetById(cancelOrderItemDTO.OrderItemId);
                orderItem.CancelReason = cancelOrderItemDTO.CancelReason;
                orderItem.OrderStatus = EnumClass.OrderStatus.Cancelled.ToString();
                orderItem.StatusActionDateTime = await GetCurrentDateTime();
                var updatedOrderItem = await _orderItemRepository.Update(orderItem);
                return await new DTOMapper().OrderItemToCancelOrderItemReturnDTO(updatedOrderItem);
            }
            catch(OrderItemNotFoundException) { throw; }
            catch(Exception ex)
            {
                throw new Exception("error in cancelling the order item");
            }
        }


        public async Task<DateTime> GetCurrentDateTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
            return istNow;
        }

        public async Task<List<OrderItemReturnDTO>> GetAllOrderItems()
        {
            try
            {
                var result = await _orderItemRepository.GetAll();
                return await new DTOMapper().OrderItemListToOrderItemReturnDTOList(result.ToList());

            }
            catch (Exception ex)
            {
                throw new OrderItemListNotGetException();
            }
        }

        public async Task<List<OrderItemReturnDTO>> FilterByStatus(string status)
        {
            try
            {
                var orderItemList = await _orderItemRepository.GetAll();
                var filteredList = orderItemList.AsQueryable();
                filteredList = filteredList.Where(x => x.OrderStatus == status);
                return await new DTOMapper().OrderItemListToOrderItemReturnDTOList(filteredList.ToList());
            }
            catch(Exception ex)
            {
                throw new Exception($"error in getting {status} order Item list");
            }
        }

    }
}
