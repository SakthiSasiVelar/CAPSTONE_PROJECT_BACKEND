using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Enums;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Mapper
{
    public class DTOMapper
    {
        public async Task<User> UserRegisterDtoToUser(UserRegisterDTO userRegisterDTO)
        {
            User user = new User()
            {
                Name = userRegisterDTO.Name,
                Email = userRegisterDTO.Email,
            };
            return user;
        }

        public async Task<UserAuthDetails> UserRegisterDtoToUserAuthDetails(UserRegisterDTO userRegisterDTO , int userId)
        {
            UserAuthDetails userAuthDetails = new UserAuthDetails()
            {
                Email = userRegisterDTO.Email,
                UserId = userId,
                Role = EnumClass.Role.User.ToString(),
            };
            HMACSHA512 hMACSHA = new HMACSHA512();
            userAuthDetails.PasswordHashKey = hMACSHA.Key;
            userAuthDetails.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password));
            return userAuthDetails;
        }

        public async Task<UserRegisterReturnDTO> UserToUserRegisterReturnDTO(User user)
        {
            UserRegisterReturnDTO userRegisterReturnDTO = new UserRegisterReturnDTO()
            {
                UserId = user.Id,
                UserName = user.Name,
                Email = user.Email,
            };

            return userRegisterReturnDTO;
        }

        public async Task<LoginReturnDTO> UserAuthDetailstoLoginReturnDTO(UserAuthDetails userAuthDetails , string token , string name)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO()
            {
                Email = userAuthDetails.Email,
                UserId = userAuthDetails.UserId,
                Role = userAuthDetails.Role,
                Token = token,
                Name = name,
            };
            return loginReturnDTO;
        }

        public async Task<Brand> AddBrandDtoToBrand(AddBrandDTO addBrandDTO)
        {
            Brand brand = new Brand()
            {
                Name = addBrandDTO.Name,
            };
            return brand;
        }

        public async Task<AddBrandReturnDTO> BrandToAddBrandReturnDto(Brand brand)
        {
            AddBrandReturnDTO addBrandReturnDTO = new AddBrandReturnDTO()
            {
                BrandId = brand.Id,
                BrandName = brand.Name,
            };
            return addBrandReturnDTO;
        }

        public async Task<Category> AddCategoryDtoToCategory(AddCategoryDTO addCategoryDTO)
        {
            Category category = new Category()
            {
                Name = addCategoryDTO.Name,
            };
            return category;
        }

        public async Task<AddCategoryReturnDTO> CategoryToAddCategoryReturnDTO(Category category)
        {
            AddCategoryReturnDTO addCategoryReturnDTO = new AddCategoryReturnDTO()
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
            };
            return addCategoryReturnDTO;
        }

        public async Task<UploadImageReturnDTO> StringToUploadImageReturnDTO(string imageUrl)
        {
            UploadImageReturnDTO uploadImageReturnDTO = new UploadImageReturnDTO()
            {
                ImageUrl = imageUrl,
            };
            return uploadImageReturnDTO;
        }

        public async Task<AddToyReturnDTO> ToyToAddToyReturnDTO(Toy toy)
        {
            AddToyReturnDTO addToyReturnDTO = new AddToyReturnDTO()
            {
                ToyId = toy.Id,
                Name = toy.Name,
                Description = toy.Description,
                Price = toy.Price,
                Discount = toy.Discount,
                CategoryId = toy.CategoryId,
                BrandId = toy.BrandId,
                AgeRange = toy.AgeRange,
                ImageUrl = toy.ImageUrl, 
                ArrivalDateTime = toy.ArrivalDate,
                Quantity = toy.Quantity,
            };
            return addToyReturnDTO;
        }

        public async Task<Toy> AddToyDtoToToy(AddToyDTO addToyDTO)
        {
            Toy toy = new Toy()
            {
                Name = addToyDTO.Name,
                Description = addToyDTO.Description,
                Price = addToyDTO.Price,
                Discount = addToyDTO.Discount,
                CategoryId = addToyDTO.CategoryId,
                BrandId = addToyDTO.BrandId,
                AgeRange = addToyDTO.AgeRange,
                ImageUrl = addToyDTO.ImageUrl,
                Quantity = addToyDTO.Quantity,
            };
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
            toy.ArrivalDate = istNow;
            return toy;
        }

        public async Task<List<ToyFilterReturnDTO>> ToyListToToyFilterReturnDTOList(List<Toy> toyList)
        {
            List<ToyFilterReturnDTO> toyFilterReturnDTOList = new List<ToyFilterReturnDTO>();
            foreach (Toy toy in toyList)
            {
                ToyFilterReturnDTO toyFilterReturnDTO = new ToyFilterReturnDTO()
                {
                    ToyId = toy.Id,
                    Name = toy.Name,
                    Description = toy.Description,
                    Price = toy.Price,
                    Discount = toy.Discount,
                    CategoryId = toy.CategoryId,
                    BrandId = toy.BrandId,
                    AgeRange = toy.AgeRange,
                    ImageUrl = toy.ImageUrl,
                    ArrivalDateTime = toy.ArrivalDate,
                    Quantity = toy.Quantity,
                };
                toyFilterReturnDTOList.Add(toyFilterReturnDTO);
            }
            return toyFilterReturnDTOList;
        }

        public async Task<AddCartItemReturnDTO> CartItemToAddCartItemReturnDTO(CartItem cartItem)
        {
            AddCartItemReturnDTO addCartItemReturnDTO = new AddCartItemReturnDTO()
            {
                CartItemId = cartItem.Id,
                UserId = cartItem.UserId,
                ToyId = cartItem.ToyId,
                Quantity = cartItem.Quantity,
            };
            return addCartItemReturnDTO;
        }

        public async Task<CartItem> AddCartItemDtoToCartItem(AddCartItemDTO addCartItemDTO)
        {
            CartItem cartItem = new CartItem()
            {
                UserId = addCartItemDTO.UserId,
                ToyId = addCartItemDTO.ToyId,
                Quantity = addCartItemDTO.Quantity,
            };
            return cartItem;
        }

        public async Task<CartItem> UpdateCartItemDtoToCartItem(UpdateCartItemDTO updateCartItemDTO)
        {
            CartItem cartItem = new CartItem()
            {
                UserId = updateCartItemDTO.UserId,
                Id = updateCartItemDTO.CartItemId,
                ToyId = updateCartItemDTO.ToyId,
                Quantity = updateCartItemDTO.Quantity,
            };
            return cartItem;
        }

        public async Task<UpdateCartItemReturnDTO> CartItemToUpdateCartItemReturnDTO(CartItem cartItem)
        {
            UpdateCartItemReturnDTO updateCartItemReturnDTO = new UpdateCartItemReturnDTO()
            {
                CartItemId = cartItem.Id,
                UserId = cartItem.UserId,
                ToyId = cartItem.ToyId,
                Quantity = cartItem.Quantity,
            };
            return updateCartItemReturnDTO;
        }

        public async Task<DeleteCartItemReturnDTO> CartItemToDeleteCartItemReturnDTO(CartItem cartItem)
        {
            DeleteCartItemReturnDTO deleteCartItemReturnDTO = new DeleteCartItemReturnDTO()
            {
                CartItemId = cartItem.Id,
            };
            return deleteCartItemReturnDTO;
        }

        public async Task<List<CartItemReturnDTO>> CartItemListToCartItemReturnDTOList(List<CartItem> cartItemList)
        {
            List<CartItemReturnDTO> cartItemReturnDTOList = new List<CartItemReturnDTO>();
            foreach(var cartItem in cartItemList)
            {
                CartItemReturnDTO cartItemReturnDTO = new CartItemReturnDTO()
                {
                    CartItemId = cartItem.Id,
                    UserId = cartItem.UserId,
                    ToyId = cartItem.ToyId,
                    Quantity = cartItem.Quantity,
                };
                cartItemReturnDTOList.Add(cartItemReturnDTO);
            }
            return cartItemReturnDTOList;
        }

        public async Task<CheckCouponCodeReturnDTO> CouponToCheckCouponCodeReturnDTO(Coupon coupon)
        {
            CheckCouponCodeReturnDTO checkCouponCodeReturnDTO = new CheckCouponCodeReturnDTO()
            {
                DiscountPrice = coupon.DiscountPrice,
            };
            return checkCouponCodeReturnDTO;
        }

        public async Task<Order> AddOrderDtoToOrder(AddOrderDTO addOrderDTO)
        {
            Order order = new Order()
            {
                Name = addOrderDTO.Name,
                UserId = addOrderDTO.UserId,
                ContactNumber = addOrderDTO.ContactNumber,
                TotalAmount = addOrderDTO.TotalAmount,
                DeliveryCharge = addOrderDTO.DeliveryCharge,
                SuccessFulPaymentId = addOrderDTO.SuccessFulPaymentId,
                Pincode = addOrderDTO.Pincode,
                Address = addOrderDTO.Address,
            };
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
            order.OrderDateTime = istNow;
            return order;

        }

        public async Task<AddOrderReturnDTO> OrderToAddOrderReturnDto(Order order)
        {
            AddOrderReturnDTO addOrderReturnDTO = new AddOrderReturnDTO()
            {
                Name = order.Name,
                OrderId = order.Id,
                ContactNumber = order.ContactNumber,
                Address = order.Address,
                Pincode = order.Pincode,
                TotalAmount = order.TotalAmount,
                SuccessFulPaymentId = order.SuccessFulPaymentId,
                OrderDateTime = order.OrderDateTime,
                DeliveryCharge = order.DeliveryCharge,
                UserId = order.UserId,
            };
            return addOrderReturnDTO;
        }

        public async Task<OrderItem> AddOrderItemDtoToOrderItem(AddOrderItemDTO addOrderItemDTO)
        {
            OrderItem orderItem = new OrderItem()
            {
                OrderId = addOrderItemDTO.OrderId,
                ToyId = addOrderItemDTO.ToyId,
                Quantity = addOrderItemDTO.Quantity,
                Price = addOrderItemDTO.Price,
                OrderStatus = EnumClass.OrderStatus.Confirmed.ToString()
            };
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
            orderItem.StatusActionDateTime = istNow;
            return orderItem;
        }

        public async Task<AddOrderItemReturnDTO> OrderItemToAddOrderItemReturnDto(OrderItem orderItem)
        {
            AddOrderItemReturnDTO addOrderItemReturnDTO = new AddOrderItemReturnDTO()
            {
                OrderItemId = orderItem.Id,
                OrderId = orderItem.OrderId,
                ToyId = orderItem.ToyId,
                Price = orderItem.Price,
                Quantity = orderItem.Quantity,
                OrderStatus = orderItem.OrderStatus,
                StatusActionDateTime = orderItem.StatusActionDateTime
            };
            return addOrderItemReturnDTO;
        }

        public async Task<UpdateOrderItemStatusReturnDTO> OrderItemToUpdateOrderItemStatusReturnDTO(OrderItem orderItem)
        {
            UpdateOrderItemStatusReturnDTO updateOrderItemStatusReturnDTO = new UpdateOrderItemStatusReturnDTO()
            {
                OrderItemId = orderItem.Id,
                OrderId = orderItem.OrderId,
                OrderItemStatus = orderItem.OrderStatus,
                ToyId = orderItem.ToyId,
                Price = orderItem.Price,
                Quantity = orderItem.Quantity,
                StatusActionDateTime = orderItem.StatusActionDateTime
            };
            return updateOrderItemStatusReturnDTO;
        }

        public async Task<CancelOrderItemReturnDTO> OrderItemToCancelOrderItemReturnDTO(OrderItem orderItem)
        {
            CancelOrderItemReturnDTO cancelOrderItemReturnDTO = new CancelOrderItemReturnDTO()
            {
                OrderItemId = orderItem.Id,
                OrderId = orderItem.OrderId,
                OrderItemStatus = orderItem.OrderStatus,
                ToyId = orderItem.ToyId,
                Price = orderItem.Price,
                Quantity = orderItem.Quantity,
                StatusActionDateTime = orderItem.StatusActionDateTime
            };
            return cancelOrderItemReturnDTO;
        }

        public async Task<List<OrderItemReturnDTO>> OrderItemListToOrderItemReturnDTOList(List<OrderItem> orderItemList)
        {
            List<OrderItemReturnDTO> orderItemReturnDTOList = new List<OrderItemReturnDTO>();
            foreach(var orderItem in orderItemList)
            {
                OrderItemReturnDTO orderItemReturnDTO = new OrderItemReturnDTO()
                {
                    OrderItemId = orderItem.Id,
                    OrderId = orderItem.OrderId,
                    OrderItemStatus = orderItem.OrderStatus,
                    ToyId = orderItem.ToyId,
                    Price = orderItem.Price,
                    Quantity = orderItem.Quantity,
                    StatusActionDateTime = orderItem.StatusActionDateTime
                };
                orderItemReturnDTOList.Add(orderItemReturnDTO);
            }
            return orderItemReturnDTOList;
        }

        public async Task<Review> AddReviewDtoToReview(AddReviewDTO addReviewDTO)
        {
            Review review = new Review()
            {
                UserId = addReviewDTO.UserId,
                ToyId = addReviewDTO.ToyId,
                Ratings = addReviewDTO.Ratings,
                ReviewText = addReviewDTO.ReviewText
            };
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo istTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime istNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, istTimeZone);
            review.ReviewDateTime = istNow;
            return review;

        }

        public async Task<AddReviewReturnDTO> ReviewToAddReviewReturnDTO(Review review)
        {
            AddReviewReturnDTO addReviewReturnDTO = new AddReviewReturnDTO()
            {
                ReviewId = review.Id,
                ReviewText = review.ReviewText,
                ToyId = review.ToyId,
                UserId = review.UserId,
                Ratings = review.Ratings,
                ReviewDateTime = review.ReviewDateTime,

            };
            return addReviewReturnDTO;
        }

        public async Task<List<ReviewReturnDTO>> ReviewListToReviewReturnDtoList(List<Review> reviewList)
        {
            List<ReviewReturnDTO>  reviewReturnDTOList = new List<ReviewReturnDTO>();

            foreach(var review in reviewList)
            {
                ReviewReturnDTO reviewReturnDTO = new ReviewReturnDTO()
                {
                    ReviewId = review.Id,
                    ReviewText = review.ReviewText,
                    ToyId = review.ToyId,
                    UserId = review.UserId,
                    Ratings = review.Ratings,
                    ReviewDateTime = review.ReviewDateTime,
                };
                reviewReturnDTOList.Add(reviewReturnDTO);
            }
            return reviewReturnDTOList;
        }

        public async Task<List<CategoryReturnDTO>> CategoryListToCategoryReturnDTOList(List<Category> categoryList)
        {
            List<CategoryReturnDTO> categoryReturnDTOList = new List<CategoryReturnDTO>();
            foreach (var category in categoryList)
            {
                CategoryReturnDTO categoryReturnDTO = new CategoryReturnDTO()
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    ImageUrl = category.ImageUrl,
                };
                categoryReturnDTOList.Add(categoryReturnDTO);
            }
            return categoryReturnDTOList;
        }

        public async Task<List<BrandReturnDTO>> BrandListToBrandReturnDTOList(List<Brand> brandList)
        {
            List<BrandReturnDTO> brandReturnDTOList = new List<BrandReturnDTO>();
            foreach(var brand in brandList)
            {
                BrandReturnDTO brandReturnDTO = new BrandReturnDTO()
                {
                    BrandId = brand.Id,
                    BrandName = brand.Name,
                    ImageUrl = brand.ImageUrl,
                };
                brandReturnDTOList.Add(brandReturnDTO);
            }
            return brandReturnDTOList;
        }
    }
}
