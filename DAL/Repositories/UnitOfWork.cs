using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private FrendsMapContext db;

        private GenericRepository<Place> placeRepository;
        private GenericRepository<TypeOfPlace> typeOfPlaceRepository;
        private GenericRepository<Person> personRepository;
        private GenericRepository<Ranking> rankingRepository;
        private GenericRepository<RankingOfFriend> rankingOfFreindRepository;
        private GenericRepository<Comment> commentRepository;
        private GenericRepository<Photo> photoRepository;

        public UnitOfWork(DbContextOptions<FrendsMapContext> connectionString)
        {
            db = new FrendsMapContext(connectionString);
        }

        public IGenericRepository<TypeOfPlace> TypeOfPlace
        {
            get
            {
                if (typeOfPlaceRepository == null)
                    typeOfPlaceRepository = new GenericRepository<TypeOfPlace>(db);
                return typeOfPlaceRepository;
            }
        }

        public IGenericRepository<Person> Person
        {
            get
            {
                if (personRepository == null)
                    personRepository = new GenericRepository<Person>(db);
                return personRepository;
            }
        }

        public IGenericRepository<RankingOfFriend> RankingOfFriend
        {
            get
            {
                if (rankingOfFreindRepository == null)
                    rankingOfFreindRepository = new GenericRepository<RankingOfFriend>(db);
                return rankingOfFreindRepository;
            }
        }

        public IGenericRepository<Ranking> Ranking
        {
            get
            {
                if (rankingRepository == null)
                    rankingRepository = new GenericRepository<Ranking>(db);
                return rankingRepository;
            }
        }

        public IGenericRepository<Comment> Comment
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new GenericRepository<Comment>(db);
                return commentRepository;
            }
        }

        public IGenericRepository<Photo> Photo
        {
            get
            {
                if (photoRepository == null)
                    photoRepository = new GenericRepository<Photo>(db);
                return photoRepository;
            }
        }

        public IGenericRepository<Place> Place
        {
            get
            {
                if (placeRepository == null)
                    placeRepository = new GenericRepository<Place>(db);
                return placeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~UnitOfWork()
        // {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
