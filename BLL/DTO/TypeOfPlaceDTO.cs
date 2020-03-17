using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
   public class TypeOfPlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Place> Places { get; set; }
    }
}
