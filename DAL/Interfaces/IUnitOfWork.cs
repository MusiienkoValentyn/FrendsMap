using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Place> Place { get; }
        IGenericRepository<TypeOfPlace> TypeOfPlace { get; }
        IGenericRepository<Person> Person { get; }
        IGenericRepository<RankingOfFriend> RankingOfFriend { get; }
        IGenericRepository<Ranking> Ranking { get; }
        IGenericRepository<Comment> Comment { get; }
        IGenericRepository<Photo> Photo { get; }
        void Save();
    }
}
