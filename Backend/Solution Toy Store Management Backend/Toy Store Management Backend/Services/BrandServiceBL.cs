using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class BrandServiceBL : IBrandService
    {
        private readonly IRepository<int,Brand> _brandRepository;

        public BrandServiceBL(IRepository<int, Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<AddBrandReturnDTO> AddBrand(AddBrandDTO addBrandDTO)
        {
            try
            {
                var brand = await new DTOMapper().AddBrandDtoToBrand(addBrandDTO);
                var newBrand = await _brandRepository.Add(brand);
                return await new DTOMapper().BrandToAddBrandReturnDto(newBrand);
            }
            catch(Exception ex)
            {
                throw new BrandNotAddException();
            }
        }
    }
}
