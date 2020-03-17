using AutoMapper;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BaseService<TBllEntity, TDalEntity>: IDisposable where TBllEntity:class where TDalEntity:BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; protected set; }

        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TDalEntity, TBllEntity>();
            cfg.CreateMap<TBllEntity, TDalEntity>();
        }).CreateMapper();

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public static TDalEntity ToDalEntity(TBllEntity bllEntity)
        {
            return _mapper.Map<TBllEntity, TDalEntity>(bllEntity);
        }

        public static IEnumerable<TDalEntity> ToDalEntity(IEnumerable<TBllEntity> bllEntity)
        {
            return _mapper.Map<IEnumerable<TBllEntity>, List<TDalEntity>>(bllEntity);
        }

        public static TBllEntity ToBllEntity(TDalEntity dalEntity)
        {
            return _mapper.Map<TDalEntity, TBllEntity>(dalEntity);
        }

        public static IEnumerable<TBllEntity> ToBllEntity(IEnumerable<TDalEntity> dalEntity)
        {
            return _mapper.Map<IEnumerable<TDalEntity>, List<TBllEntity>>(dalEntity);
        }


        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UnitOfWork.Dispose();
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~BaseService()
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
