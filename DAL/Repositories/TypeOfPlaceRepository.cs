using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class TypeOfPlaceRepository : GenericRepository<TypeOfPlaceRepository>
    {
        public TypeOfPlaceRepository(DbContext context) : base(context)
        {
        }
    }
}
