using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PhotoService : BaseService<PhotoDTO, Photo>, IPhotoService
    {
        public PhotoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void DeletePhoto(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Photo.Delete(id.Value);
            UnitOfWork.Save();
        }

        public string GetLastAvatar(string nickname)
        {
            var res = from photo in UnitOfWork.Photo.GetAll()
                      join person in UnitOfWork.Person.GetAll()
                      on photo.PersonId equals person.Id
                      where photo.PlaceId == null && person.NickName == nickname
                      orderby photo.DateTimeOfAdding descending
                      select photo.URL;

            return res.FirstOrDefault();
        }

        public PhotoDTO GetPhoto(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var photo = UnitOfWork.Photo.Get(id.Value);

            if (photo == null)
                throw new ValidationException("Place not found", nameof(photo));

            return ToBllEntity(photo);
        }

        public IEnumerable<PhotoDTO> GetPhotos()
        {
            return ToBllEntity(UnitOfWork.Photo.GetAll());
        }

        public void InsertPhoto(PhotoDTO photo)
        {
            if (photo == null)
                throw new ValidationException("Argument is null", nameof(photo));

            Photo photoEntity = ToDalEntity(photo);
            photoEntity.URL= photo.PlaceId.ToString() + DateTime.UtcNow;
            UnitOfWork.Photo.Create(photoEntity);
            MemoryStream ms = new MemoryStream(photo.Image.GetBytes().Result);
            Task.Run(() => AddImage.UploadFile(ms, photoEntity.URL));
            UnitOfWork.Save();
        }

        public void UpdatePhotoe(PhotoDTO photo)
        {
            if (photo == null)
                throw new ValidationException("Argument is null", nameof(photo));
            photo.DateTimeOfAdding = DateTime.UtcNow;
            Photo photoEntity = ToDalEntity(photo);
         //   UnitOfWork.Photo.Update(photoEntity);
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

        public List<string> GetPhotosByPlaceId(int id)
        {
            return (from p in UnitOfWork.Photo.GetAll() where p.PlaceId == id orderby p.DateTimeOfAdding descending select p.URL).ToList();
        }
    }
}
