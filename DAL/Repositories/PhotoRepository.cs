using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class PhotoRepository:GenericRepository<PhotoRepository>
    {
        public PhotoRepository(DbContext context):base(context)
        {

        }
    }
}
