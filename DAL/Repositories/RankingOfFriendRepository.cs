using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class RankingOfFriendRepository:GenericRepository<RankingOfFriendRepository>
    {
        public RankingOfFriendRepository(DbContext context):base(context)
        {

        }
    }
}
