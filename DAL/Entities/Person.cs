﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Person : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Gmail { get; set; }
        public string Avatar { get; set; }
        public int Rating { get; set; }
        [Required]
        public string IDUserOfGoogle { get; set; }


        public ICollection<Place> Places { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Ranking> Rankings { get; set; }

        public ICollection<RankingOfFriend> RankingOfFriends { get; set; }

        public ICollection<RankingOfFriend> RankingOfFriends1 { get; set; }
        public Person()
        {
            Places = new List<Place>();
            Photos = new List<Photo>();
            Comments = new List<Comment>();
            Rankings = new List<Ranking>();
            RankingOfFriends = new List<RankingOfFriend>();
            RankingOfFriends1 = new List<RankingOfFriend>();
        }
    }
}
