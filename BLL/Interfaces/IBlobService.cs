using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBlobService
    {
        // Task<BlobInfo> GetBlobAsync(string name);

         Task<IEnumerable<string>> ListBlobAsync(string name);

         Task UploadBlobAsync(string filePath,string fileName);

         Task UploadContentBlobAsync(string content, string fileName);

        Task DeleteBlobAsync(string blobName);


    }
}
