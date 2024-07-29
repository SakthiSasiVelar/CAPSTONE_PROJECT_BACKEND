using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;
using Toy_Store_Management_Backend.Repositories;

namespace Toy_Store_Management_Backend.Services
{
    public class ReviewServiceBL : IReviewService
    {

        private readonly IRepository<int, Review> _reviewRepository;
        private readonly ToyReviewRepository _toyReviewRepository;

        public ReviewServiceBL(IRepository<int, Review> reviewRepository  , ToyReviewRepository toyReviewRepository)
        {
             _reviewRepository = reviewRepository;
             _toyReviewRepository = toyReviewRepository;
        }

        public async Task<AddReviewReturnDTO> AddReview(AddReviewDTO addReviewDTO)
        {
            try
            {
                var review = await new DTOMapper().AddReviewDtoToReview(addReviewDTO);
                var result = await _reviewRepository.Add(review);
                return await new DTOMapper().ReviewToAddReviewReturnDTO(result);
            }
            catch(Exception ex)
            {
                throw new ReviewNotAddException();
            }
        }

        public async Task<List<ReviewReturnDTO>> GetAllReviewByToyId(int toyId)
        {
            try
            {
                var toy = await _toyReviewRepository.GetById(toyId);
                return await new DTOMapper().ReviewListToReviewReturnDtoList(toy.Reviews.ToList());
            }
            catch (ToyNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ToyNotGetException(toyId);
            }
        }
    }
}
