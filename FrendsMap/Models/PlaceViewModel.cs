using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrendsMap.Models
{
    public class PlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Geolocation { get; set; }
        public string DateTimeOfAdding { get; set; }
        public int TypeOfPlaceId { get; set; }
        public int PersonId { get; set; }
    }
}
