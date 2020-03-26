using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
   public class RankingOfFriendService : BaseService<RankingOfFriendDTO, RankingOfFriend>, IRankingOfFriendService
    {
        public RankingOfFriendService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void DeleteRankingOfFriend(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.RankingOfFriend.Delete(id.Value);
            UnitOfWork.Save();
        }

        public RankingOfFriendDTO GetRankingOfFriend(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var rankingOfFriend = UnitOfWork.RankingOfFriend.Get(id.Value);

            if (rankingOfFriend == null)
                throw new ValidationException("Place not found", nameof(rankingOfFriend));

            return ToBllEntity(rankingOfFriend);
        }

        public IEnumerable<RankingOfFriendDTO> GetRankingOfFriends()
        {
            return ToBllEntity(UnitOfWork.RankingOfFriend.GetAll());
        }

        public void InsertRankingOfFriend(RankingOfFriendDTO ranking)
        {
            if (ranking == null)
                throw new ValidationException("Argument is null", nameof(ranking));

            RankingOfFriend rankingOfFriendEntity = ToDalEntity(ranking);
            UnitOfWork.RankingOfFriend.Create(rankingOfFriendEntity);
            UnitOfWork.Save();
        }

        public void UpdateRankingOfFriend(RankingOfFriendDTO ranking)
        {
            if (ranking == null)
                throw new ValidationException("Argument is null", nameof(ranking));

            RankingOfFriend placeEntity = ToDalEntity(ranking);
            UnitOfWork.RankingOfFriend.Update(placeEntity);
            UnitOfWork.Save();
        }
    }
}
