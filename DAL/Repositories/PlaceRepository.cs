using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class PlaceRepository : GenericRepository<PlaceRepository>
    {
        public PlaceRepository(DbContext context) : base(context)
        {
        }
    }
}
