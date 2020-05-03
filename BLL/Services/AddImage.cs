using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class AddImage
    {
        public static async Task UploadFile(Stream stream, string name)
        {
            var path = "DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(path);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("images");

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(name);
            blockBlob.Properties.ContentType = "image/jpeg";

            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = stream)
            {
                fileStream.Position = 0;
                await blockBlob.UploadFromStreamAsync(fileStream);
            }

        }
    }

    public static class FormFileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

    }
}
