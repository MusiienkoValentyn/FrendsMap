using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BlobService : IBlobService
    {
       // public readonly BlobServiceClient _blobServiceClient { get; set; }
        public Task DeleteBlobAsync(string blobName)
        {
            throw new NotImplementedException();
        }

        //public Task<BlobInfo> GetBlobAsync(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<IEnumerable<string>> ListBlobAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UploadBlobAsync(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task UploadContentBlobAsync(string content, string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
