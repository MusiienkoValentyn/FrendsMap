using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Ranking : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public System.DateTime DateTimeOfAdding { get; set; }

        //[Required]
        public int? PlaceId { get; set; }
        public Place Place { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}