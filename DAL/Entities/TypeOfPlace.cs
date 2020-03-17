using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TypeOfPlace : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Place> Places { get; set; }
        public TypeOfPlace()
        {
            Places = new List<Place>();
        }
    }
}
