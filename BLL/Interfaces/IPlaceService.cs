using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPlaceService
    {
        IEnumerable<PlaceDTO> GetPlaces();
        PlaceDTO GetPlace(int? id);
        void InsertPlace(PlaceDTO place);
        void UpdatePlace(PlaceDTO place);
        void DeletePlace(int? id);
        int IsPlaceConsist(PlaceDTO place);
        int IsPlaceConsist(string name);

    }
}
