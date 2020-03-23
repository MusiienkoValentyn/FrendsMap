using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TypeOfPlaceService: BaseService<TypeOfPlaceDTO, TypeOfPlace>, ITypeOfPlaceService
    {
        //private static readonly IMapper placeMapper = new MapperConfiguration(cfg =>
        //{
        //    cfg.CreateMap<TypeOfPlaceService, TypeOfPlaceDTO>()
        //    .ForMember(p => p., o => o.MapFrom(s => CommentService.ToBllEntity(s.Comments)));
        //}).CreateMapper();

        public TypeOfPlaceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<TypeOfPlaceDTO> GetTypeOfPlaces()
        {
            return ToBllEntity(UnitOfWork.TypeOfPlace.GetAll());
        }

        public TypeOfPlaceDTO GetTypeOfPlace(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var typeOfPlace = UnitOfWork.TypeOfPlace.Get(id.Value);

            if (typeOfPlace == null)
                throw new ValidationException("Place not found", nameof(typeOfPlace));

            return ToBllEntity(typeOfPlace);
        }

        public void InsertTypeOfPlace(TypeOfPlaceDTO typeOfPlace)
        {
            if (typeOfPlace == null)
                throw new ValidationException("Argument is null", nameof(typeOfPlace));

            TypeOfPlace typeOfPlaceEntity = ToDalEntity(typeOfPlace);
            UnitOfWork.TypeOfPlace.Create(typeOfPlaceEntity);
            UnitOfWork.Save();
        }

        public void UpdateTypeOfPlace(TypeOfPlaceDTO typeOfPlace)
        {
            if (typeOfPlace == null)
                throw new ValidationException("Argument is null", nameof(typeOfPlace));

            TypeOfPlace typeOfPlaceEntity = ToDalEntity(typeOfPlace);
            UnitOfWork.TypeOfPlace.Update(typeOfPlaceEntity);
            UnitOfWork.Save();
        }

        public void DeleteTypeOfPlace(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.TypeOfPlace.Delete(id.Value);
            UnitOfWork.Save();
        }
    }
}
