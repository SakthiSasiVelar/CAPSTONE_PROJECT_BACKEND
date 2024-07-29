using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IReviewService
    {
        public Task<AddReviewReturnDTO>  AddReview(AddReviewDTO addReviewDTO);

        public Task<List<ReviewReturnDTO>> GetAllReviewByToyId(int  toyId);
    }
}
