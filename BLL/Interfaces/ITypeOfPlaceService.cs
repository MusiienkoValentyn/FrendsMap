using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
   public interface ITypeOfPlaceService
    {
        IEnumerable<TypeOfPlaceDTO> GetTypeOfPlaces();
        TypeOfPlaceDTO GetTypeOfPlace(int? id);
        void InsertTypeOfPlace(TypeOfPlaceDTO typeOfPlace);
        void UpdateTypeOfPlace(TypeOfPlaceDTO typeOfPlace);
        void DeleteTypeOfPlace(int? id);
    }
}
