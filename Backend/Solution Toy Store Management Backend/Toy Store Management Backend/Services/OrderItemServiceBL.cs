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
        private readonly IRepository<int , Order> _orderRepository;

        public OrderItemServiceBL(IOrderItemRepository<int, OrderItem> orderItemRepository , IRepository<int, Order> orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
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

        public async Task<List<OrderItemReturnDTO>> GetAllOrderItems(int userId)
        {
            try
            {
                var orderList = await _orderRepository.GetAll();
                var userOrderList = orderList.Where((order) =>  order.UserId == userId).ToList();
                var orderItemList = await _orderItemRepository.GetAll();
                var userOrderItemList = orderItemList
                    .Where(orderItem => userOrderList.Any(order => order.Id == orderItem.OrderId))
                    .OrderByDescending(orderItem => userOrderList.First(order => order.Id == orderItem.OrderId).OrderDateTime)
                    .ToList();
                return await new DTOMapper().OrderItemListToOrderItemReturnDTOList(userOrderItemList);
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

        public async Task<OrderItemReturnDTO> GetCartItemById(int id)
        {
            try
            {
                var orderItem = await _orderItemRepository.GetById(id);
                OrderItemReturnDTO orderItemReturnDTO = new OrderItemReturnDTO() {
                    OrderId = orderItem.OrderId,
                    ToyId = orderItem.ToyId,
                    OrderItemId = orderItem.Id,
                    Quantity = orderItem.Quantity,
                    Price = orderItem.Price,
                    OrderItemStatus = orderItem.OrderStatus,
                    StatusActionDateTime = orderItem.StatusActionDateTime,
                };
                return orderItemReturnDTO;
            }
            catch (OrderItemNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new OrderItemNotGetException(id);
            }
        }
    }
}
