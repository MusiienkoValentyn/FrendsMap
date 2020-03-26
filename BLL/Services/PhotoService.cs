using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            UnitOfWork.Photo.Create(photoEntity);
            UnitOfWork.Save();
        }

        public void UpdatePhotoe(PhotoDTO photo)
        {
            if (photo == null)
                throw new ValidationException("Argument is null", nameof(photo));

            Photo photoEntity = ToDalEntity(photo);
            UnitOfWork.Photo.Update(photoEntity);
            UnitOfWork.Save();
        }
    }
}
