using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;

namespace Toy_Store_Management_Backend.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "images";

        public BlobService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
            _blobServiceClient = new BlobServiceClient(connectionString);
        }
        public async Task<UploadImageReturnDTO> UploadImageToBlob(UploadImageDTO uploadImageDTO)
        {
            var file = uploadImageDTO.File;
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            return await new DTOMapper().StringToUploadImageReturnDTO(blobClient.Uri.ToString());
        }
    }
}
