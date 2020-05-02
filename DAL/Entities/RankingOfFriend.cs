using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Entities
{
    public class RankingOfFriend : BaseEntity
    {
        [Required]
        public int Mark { get; set; }
        [Required]
        public System.DateTime DateTimeOfAdding { get; set; }

        [Required]
        public int TypeOfPlaceId { get; set; }
        public TypeOfPlace TypeOfPlace { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public int FriendId { get; set; }
        public Person Person1 { get; set; }
    }
}