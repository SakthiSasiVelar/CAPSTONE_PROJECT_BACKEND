using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IBlobService
    {
        public Task<UploadImageReturnDTO>  UploadImageToBlob(UploadImageDTO uploadImageDTO);
    }
}
