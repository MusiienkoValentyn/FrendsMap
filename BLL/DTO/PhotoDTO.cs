using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public System.DateTime DateTimeOfAdding { get; set; }
        //public bool IsAccepted { get; set; }

        public int? PlaceId { get; set; }
        public Place Place { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
