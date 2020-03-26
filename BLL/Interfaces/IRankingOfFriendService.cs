using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRankingOfFriendService
    {
        IEnumerable<RankingOfFriendDTO> GetRankingOfFriends();
        RankingOfFriendDTO GetRankingOfFriend(int? id);
        void InsertRankingOfFriend(RankingOfFriendDTO place);
        void UpdateRankingOfFriend(RankingOfFriendDTO place);
        void DeleteRankingOfFriend(int? id);
    }
}
