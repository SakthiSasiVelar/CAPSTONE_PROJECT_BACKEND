﻿using System.Security.Cryptography;
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

        public async Task<LoginReturnDTO> UserAuthDetailstoLoginReturnDTO(UserAuthDetails userAuthDetails , string token)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO()
            {
                Email = userAuthDetails.Email,
                UserId = userAuthDetails.UserId,
                Role = userAuthDetails.Role,
                Token = token
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
    }
}
