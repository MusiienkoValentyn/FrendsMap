﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrendsMap.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string  Gmail{ get; set; }
        public string Avatar { get; set; }
        public int Rating { get; set; }
        public string IDUserOfGoogle { get; set; }

        public IFormFile Image  { get; set; }
    }
}
