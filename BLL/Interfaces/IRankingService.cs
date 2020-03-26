using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRankingService
    {
        IEnumerable<RankingDTO> GetRankings();
        RankingDTO GetRanking(int? id);
        void InsertRanking(RankingDTO place);
        void UpdateRanking(RankingDTO place);
        void DeleteRanking(int? id);
    }
}
