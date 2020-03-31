using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Entities
{
    public class RankingOfFriend : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Mark { get; set; }
        [Required]
        public System.DateTime DateTimeOfAdding { get; set; }


        public int? TypeOfPlaceId { get; set; }
        public TypeOfPlace TypeOfPlace { get; set; }

        public int? PersonId { get; set; }
        public Person Person { get; set; }

       
        public int? FriendId { get; set; }
        public Person Person1 { get; set; }
    }
}