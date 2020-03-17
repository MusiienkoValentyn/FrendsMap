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
    public class PlaceService :BaseService<PlaceDTO,Place>, IPlaceService
    {
        private static readonly IMapper placeMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Place, PlaceDTO>()
            .ForMember(p => p.Comments, o => o.MapFrom(s => CommentService.ToBllEntity(s.Comments)));
        }).CreateMapper();

        //IUnitOfWork Database { get; set; }
        public PlaceService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }
        public IEnumerable<PlaceDTO> GetPlaces()
        {
            return ToBllEntity(UnitOfWork.Place.GetAll());
        }

        public PlaceDTO GetPlace(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var place = UnitOfWork.Place.Get(id.Value);

            if (place == null)
                throw new ValidationException("Place not found", nameof(place));

            return ToBllEntity(place);
        }

        public void InsertPlace(PlaceDTO place)
        {
            if (place == null)
                throw new ValidationException("Argument is null", nameof(place));

            Place placeEntity = ToDalEntity(place);
            UnitOfWork.Place.Create(placeEntity);
            UnitOfWork.Save();
        }

        public void UpdatePlace(PlaceDTO place)
        {
            if (place == null)
                throw new ValidationException("Argument is null", nameof(place));

            Place placeEntity = ToDalEntity(place);
            UnitOfWork.Place.Update(placeEntity);
            UnitOfWork.Save();
        }

        public void DeletePlace(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Place.Delete(id.Value);
            UnitOfWork.Save();
        }
    }
}
