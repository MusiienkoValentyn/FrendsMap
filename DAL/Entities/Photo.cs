using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Photo : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public System.DateTime DateTimeOfAdding { get; set; }
        [Required]
        public bool IsAccepted { get; set; }

        public int? PlaceId { get; set; }
        public Place Place { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}