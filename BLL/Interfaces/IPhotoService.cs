using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPhotoService
    {
        IEnumerable<PhotoDTO> GetPhotos();
        PhotoDTO GetPhoto(int? id);
        string GetLastAvatar(string nickname);
        void InsertPhoto(PhotoDTO place);
        void UpdatePhotoe(PhotoDTO place);
        void DeletePhoto(int? id);
        List<string> GetPhotosByPlaceId(int id);
    }
}
