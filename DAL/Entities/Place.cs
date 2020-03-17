using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Place : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Geolocation { get; set; }
        [Required]
        public System.DateTime DateTimeOfAdding { get; set; }



        ///////



        [Required]
        public int TypeOfPlaceId { get; set; }
        public TypeOfPlace TypeOfPlace { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Ranking> Rankings { get; set; }
        public Place()
        {
            Comments = new List<Comment>();
            Photos = new List<Photo>();
            Rankings = new List<Ranking>();
        }

    }
}