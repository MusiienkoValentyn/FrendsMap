using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class RankingRepository:GenericRepository<RankingRepository>
    {
        public RankingRepository(DbContext context):base(context)
        {

        }
    }
}
