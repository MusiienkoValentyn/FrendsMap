using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
   public class PersonDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        //public string Photo { get; set; }
        public IFormFile Image { get; set; }
        public string Gmail { get; set; }
        //public int Rating { ge/t; set; }

        public IEnumerable<Place> Places { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Ranking> Rankings { get; set; }
        public IEnumerable<RankingOfFriendDTO> RankingOfFriends { get; set; }
        public IEnumerable<RankingOfFriendDTO> RankingOfFriends1 { get; set; }
    }
}
