using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FreeImageAPI;
using System.Collections;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using NLog.Internal;
using System.Configuration;

namespace BLL.Services
{
    public class PersonService : BaseService<PersonDTO, Person>, IPersonService
    {
        private IUnitOfWork _unitOfWork;
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeletePerson(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Person.Delete(id.Value);
            UnitOfWork.Save();
        }


        public IEnumerable<PersonDTO> GetPeople()
        {
            return ToBllEntity(UnitOfWork.Person.GetAll());
        }

        public PersonDTO GetPerson(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var person = UnitOfWork.Person.Get(id.Value);

            if (person == null)
                throw new ValidationException("Person not found", nameof(person));

            return ToBllEntity(person);
        }

        public bool GetPerson(string nickname)
        {
            if (nickname == null)
                throw new ValidationException("Argmunet is null", nameof(nickname));

            var res = (from person in UnitOfWork.Person.GetAll()
                       where person.NickName == nickname
                       select person.NickName).ToList();

            if (res.Count > 0)
                return true;
            else
                return false;
        }

        public void InsertPerson(PersonDTO person)
        {
            if (person == null)
                throw new ValidationException("Argument is null", nameof(person));

            
            Person personEntity = ToDalEntity(person);
            personEntity.Avatar = $"{personEntity.NickName}Avatar";
            //var pNick = person.NickName;
            UnitOfWork.Person.Create(personEntity);

            var bytes = person.Image.GetBytes();
            MemoryStream ms = new MemoryStream(bytes.Result);

            var path = "DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net";
            Task.Run(() => UploadFile(path, ms,  personEntity.Avatar));
            UnitOfWork.Save();



            ///////////////////////////////////////////////////////////////////////////////////////////


           // var personIdAndImageCount = GetPersonIdAndAmountOfImagesByNickname(pNick);

           // if(person.Image==null)
           //     throw new ValidationException("Argument is null", nameof(person.Image));

           // var bytes = person.Image.GetBytes();
           // MemoryStream ms = new MemoryStream(bytes.Result);
           // var b = FreeImageBitmap.FromStream(ms);

           // var path = "DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net";

           // var pathToDb = $"{pNick}_{personIdAndImageCount[1] + 1}.jpg";

           //Task.Run(() => UploadFile(path, ms, pathToDb));

           // PhotoDTO photo = new PhotoDTO();
           // photo.DateTimeOfAdding = DateTime.Now;
           // photo.PersonId = personIdAndImageCount[0];
           // photo.URL = "https://frendsmapimagestorage1.blob.core.windows.net/images/"+pathToDb;

           // PhotoService photoService = new PhotoService(_unitOfWork);
           // photoService.InsertPhoto(photo);

        }

        private async Task UploadFile(string path,Stream stream,string name)
        {

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
                fileStream.Position=0;
                await blockBlob.UploadFromStreamAsync(fileStream);
            }

        }


        private Stream DownloadFile()
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net");

            CloudBlockBlob blob = new CloudBlockBlob(new Uri("https://frendsmapimagestorage1.blob.core.windows.net/images"), storageAccount.Credentials);

            Stream mem = new MemoryStream();
            if (blob != null)
            {
                blob.DownloadToStreamAsync(mem);
            }

            return mem;







            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net");

            //CloudBlockBlob blob = new CloudBlockBlob(new Uri("https://frendsmapimagestorage1.blob.core.windows.net/images/img.jpg"), storageAccount.Credentials);


            //using (var stream = blob.OpenReadAsync())
            //{
            //    using (StreamReader reader = new StreamReader(stream.Result))
            //    {
            //        return reader.ReadToEnd();
            //    }
            //}







            // var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net"));
            // var myClient = storageAccount.CreateCloudBlobClient();
            // var container = myClient.GetContainerReference("images");
            //// container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob);

            // //lines modified
            // var blockBlob = container.GetBlockBlobReference("img.jpg");
            // using (var fileStream = System.IO.File.OpenWrite(@"D:\Desktop\mikepic-backup.png"))
            // {
            //    await blockBlob.DownloadToStreamAsync(fileStream);
            // }






















            //var containerName = "images";

            //string storageConnection = CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net");
            //CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(storageConnection); 
            //CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();



            //CloudBlobContainer cloudBlobContainer = blobClient.GetContainerReference(containerName); 
            //CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference("uploadedfilename.ext");



            //MemoryStream memStream = new MemoryStream();

            //await blockBlob.DownloadToStreamAsync(memStream);


            ////////CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=frendsmapimagestorage1;AccountKey=w9SZUCuKSTiZAw6clAbZbyA/LsgQI/3JEpEMBNCpDyj2rGPJ6OIBTYaFoROqByRTNESVDtgGelxNIk8UOO9IrQ==;EndpointSuffix=core.windows.net");

            ////////// Create the blob client.
            ////////CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            ////////CloudBlobContainer container = blobClient.GetContainerReference("images");


            ////////var blockBlob = container.GetBlockBlobReference("");

            ////////var downloadsPathOnServer = Path.Combine(HostingEnvironment.MapPath(DOWNLOAD_PATH), blockBlob.Name);

            ////////using (var fileStream = File.OpenWrite(downloadsPathOnServer))
            ////////{
            ////////    await blockBlob.DownloadToStreamAsync(fileStream);
            ////////}
        }

        public void UpdatePerson(PersonDTO person)
        {
            if (person == null)
                throw new ValidationException("Argument is null", nameof(person));

            Person personEntity = ToDalEntity(person);
            UnitOfWork.Person.Update(personEntity);
            UnitOfWork.Save();
        }


        private List<int> GetPersonIdAndAmountOfImagesByNickname(string nick)
        {
            if (nick == null)
                throw new ValidationException("Argmunet is null", nameof(nick));

            var person = from pers in UnitOfWork.Person.GetAll()
                         where pers.NickName == nick
                         select pers;

            int personId = 0;
            foreach (var p in person)
            {
                personId = p.Id;
            };

            var AmountImages = from photo in UnitOfWork.Photo.GetAll()
                               where photo.PersonId == personId
                               select photo.Id;

            List<int> list = new List<int>();
            list.Add(personId);
            list.Add(AmountImages.Count());

            if (list == null)
                throw new ValidationException("Person not found", nameof(list));

            return list;
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
