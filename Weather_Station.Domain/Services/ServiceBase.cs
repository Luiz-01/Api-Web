using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Domain.Interfaces.Interfaces;
using Weather_Station.Domain.Interfaces.Services;

namespace Weather_Station.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public T Add(T TabelaGenerica)
        {
            try
            {
                return _repositoryBase.Add(TabelaGenerica);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetById(Guid id)
        {
            try
            {
                return _repositoryBase.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            try
            {
                return _repositoryBase.GetByFilter(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _repositoryBase.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(T tabelaGenerica)
        {
            try
            {
                 _repositoryBase.Delete(tabelaGenerica);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(T tabelaGenerica)
        {
            try
            {
              return _repositoryBase.Update(tabelaGenerica);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool AddRange(List<T> listaTabelaGenerica)
        {
            try
            {
                return _repositoryBase.AddRange(listaTabelaGenerica);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateRange(List<T> listaTabelaGenerica)
        {
            try
            {
                return _repositoryBase.UpdateRange(listaTabelaGenerica);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteRange(List<T> listaTabelaGenerica)
        {
            try
            {
                return _repositoryBase.DeleteRange(listaTabelaGenerica);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
