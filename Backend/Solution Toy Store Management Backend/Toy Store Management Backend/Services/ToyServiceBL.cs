using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class ToyServiceBL : IToyService
    {
        private readonly IRepository<int, Toy> _toyRepository;
        private readonly IRepository<int, Category> _categoryRepository;
        private readonly IRepository<int, Brand> _brandRepository;

        public ToyServiceBL(IRepository<int, Toy> toyRepository , IRepository<int, Category> categoryRepository, IRepository<int, Brand> brandRepository)
        {
            _toyRepository = toyRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<AddToyReturnDTO> AddToy(AddToyDTO addToyDTO)
        {
            try
            {
                var toy = await new DTOMapper().AddToyDtoToToy(addToyDTO);
                var result = await _toyRepository.Add(toy);
                return await new DTOMapper().ToyToAddToyReturnDTO(result);
            }
            catch(Exception ex)
            {
                throw new ToyNotAddException();
            }
        }

        public async Task<List<ToyFilterReturnDTO>> FilterByBrand(string brandName)
        {
            try
            {
                var brandId = await GetBrandId(brandName);
                var toyList = await _toyRepository.GetAll();
                List<Toy> filteredList = new List<Toy>();
                foreach (var toy in toyList)
                {
                    if (toy.BrandId == brandId)
                    {
                        filteredList.Add(toy);
                    }
                }
                return await new DTOMapper().ToyListToToyFilterReturnDTOList(filteredList);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting filtered toy list by brand");
            }
        }

        public async Task<List<ToyFilterReturnDTO>> FilterByCategory(string categoryName)
        {
            try
            {
                var categoryId = await GetCategoryId(categoryName);
                var toyList = await _toyRepository.GetAll();
                List<Toy> filteredList = new List<Toy>();
                foreach(var toy in toyList)
                {
                    if(toy.CategoryId == categoryId)
                    {
                        filteredList.Add(toy);
                    }
                }
                return await new DTOMapper().ToyListToToyFilterReturnDTOList(filteredList);
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting filtered toy list by category");
            }
        }

        public async Task<List<ToyFilterReturnDTO>> FilterByAgeRange(string ageRange)
        {
            try
            {
                var toyList = await _toyRepository.GetAll();
                List<Toy> filteredList = new List<Toy>();
                foreach (var toy in toyList)
                {
                    if (toy.AgeRange == ageRange)
                    {
                        filteredList.Add(toy);
                    }
                }
                return await new DTOMapper().ToyListToToyFilterReturnDTOList(filteredList);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting filtered toy list by ageRange");
            }
        }

        public async  Task<List<ToyFilterReturnDTO>> FilterByArrivalDate()
        {
            try
            {
                var toyList = await _toyRepository.GetAll();
                var filteredToys = toyList
                    .OrderByDescending(t => t.ArrivalDate)
                    .Take(10)
                    .ToList();
                return await new DTOMapper().ToyListToToyFilterReturnDTOList(filteredToys);
                  
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting filtered toy list by ageRange");
            }
        }

        public async  Task<List<ToyFilterReturnDTO>> FilterByMultipleValues(ToyMultipleFilterDTO toyMultipleFilterDTO)
        {
            try
            {
                var toyList = await _toyRepository.GetAll();
                var filteredToys = toyList.AsQueryable();

                if (toyMultipleFilterDTO.CategoryId.HasValue)
                {
                    filteredToys = filteredToys.Where(t => t.CategoryId == toyMultipleFilterDTO.CategoryId.Value);
                }

                if (toyMultipleFilterDTO.BrandId.HasValue)
                {
                    filteredToys = filteredToys.Where(t => t.BrandId == toyMultipleFilterDTO.BrandId.Value);
                }

                if (!string.IsNullOrEmpty(toyMultipleFilterDTO.AgeRange))
                {
                    filteredToys = filteredToys.Where(t => t.AgeRange == toyMultipleFilterDTO.AgeRange);
                }

                if (!string.IsNullOrEmpty(toyMultipleFilterDTO.MinPrice))
                {
                    var minPrice = decimal.Parse(toyMultipleFilterDTO.MinPrice);
                    filteredToys = filteredToys.Where(t => decimal.Parse(t.Price) >= minPrice);
                }

                if (!string.IsNullOrEmpty(toyMultipleFilterDTO.MaxPrice))
                {
                    var maxPrice = decimal.Parse(toyMultipleFilterDTO.MaxPrice);
                    filteredToys = filteredToys.Where(t => decimal.Parse(t.Price) <= maxPrice);
                }

                return await new DTOMapper().ToyListToToyFilterReturnDTOList(filteredToys.ToList());

            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting filtered toy list ");
            }
        }

        public async Task<int> GetCategoryId(string categoryName)
        {
            try
            {
                var categoryList = await _categoryRepository.GetAll();
                foreach( var category in categoryList)
                {
                    if (category.Name == categoryName) return category.Id;
                }
                throw new Exception("Error in getting category id by name");
            }
            catch(Exception ex)
            {
                throw new Exception("Error in getting category id by name");
            }
        }

        public async Task<int> GetBrandId(string brandName)
        {
            try
            {
                var brandList = await _brandRepository.GetAll();
                foreach(var brand in brandList)
                {
                    if (brand.Name == brandName) return brand.Id;
                }
                throw new Exception("Error in getting category id by name");
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting category id by name");
            }
        }

        
    }
}
