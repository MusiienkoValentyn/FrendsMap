using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrendsMap.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public System.DateTime DateTimeOfAdding { get; set; }

        public int? PlaceId { get; set; }
        public int PersonId { get; set; }
    }
}
