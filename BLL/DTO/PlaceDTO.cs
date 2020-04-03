using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
   public class PlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Geolocation { get; set; }
        public System.DateTime DateTimeOfAdding { get; set; }
        //public bool IsAccepted { get; set; }

        public int TypeOfPlaceId { get; set; }
        public TypeOfPlace TypeOfPlace { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
        public IEnumerable<PhotoDTO> Photos { get; set; }
        public IEnumerable<RankingDTO> Rankings { get; set; }
    }
}
