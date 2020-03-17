﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class RankingOfFriend
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public System.DateTime DateTimeOfAdding { get; set; }

        public int? PersonId { get; set; }
        public Person Person { get; set; }

        public int? FriendId { get; set; }
        public Person Person1 { get; set; }
    }
}
