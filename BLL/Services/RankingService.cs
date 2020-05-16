using BLL.DTO;
using BLL.Exceptions;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BLL.Services
{
    public class RankingService : BaseService<RankingDTO, Ranking>, IRankingService
    {
        public RankingService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }
        public void DeleteRanking(int? id)
        {
            if (id == null)
                throw new ValidationException("Argument is null", nameof(id));

            UnitOfWork.Ranking.Delete(id.Value);
            UnitOfWork.Save();
        }

        public RankingDTO GetRanking(int? id)
        {
            if (id == null)
                throw new ValidationException("Argmunet is null", nameof(id));

            var ranking = UnitOfWork.Ranking.Get(id.Value);

            if (ranking == null)
                throw new ValidationException("Place not found", nameof(ranking));

            return ToBllEntity(ranking);
        }

        public IEnumerable<RankingDTO> GetRankings()
        {
            return ToBllEntity(UnitOfWork.Ranking.GetAll());
        }

        public void InsertRanking(RankingDTO ranking)
        {
            if (ranking == null)
                throw new ValidationException("Argument is null", nameof(ranking));

            Ranking rankingEntity = ToDalEntity(ranking);
            UnitOfWork.Ranking.Create(rankingEntity);
            UnitOfWork.Save();
        }

        public void UpdateRanking(RankingDTO ranking)
        {
            if (ranking == null)
                throw new ValidationException("Argument is null", nameof(ranking));

            var rank = (from r in UnitOfWork.Ranking.GetAll() where r.PersonId == ranking.PersonId && r.PlaceId == ranking.PlaceId  select r).FirstOrDefault();
            if(rank==null)
                throw new ValidationException("Argument is null", nameof(ranking));

            Ranking rankingEntity = ToDalEntity(ranking);
            rankingEntity.Id = rank.Id;
            rankingEntity.DateTimeOfAdding = DateTime.UtcNow;
            UnitOfWork.Ranking.Update(rankingEntity);
            UnitOfWork.Save();
        }
    }
}
