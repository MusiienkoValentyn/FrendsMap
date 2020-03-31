using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class RankingOfFriendRepository:GenericRepository<RankingOfFriendRepository>
    {
        public RankingOfFriendRepository(DbContext context):base(context) { }

        //public RankingOfFriend GetAllFriends(int id)
        //{
        //         //return _dbSet.Where(s => s.PersonId == id));
        //        var res = from person in _dbSet where person.PersonId == id select person;
        //    //  //  var res = ToBllEntity(UnitOfWork.RankingOfFriend.FromSql(""));

        //        return res;
        //}

    }
}
