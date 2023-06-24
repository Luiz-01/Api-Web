using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Domain.Interfaces.Interfaces;
using Weather_Station.Infra.Context;

namespace Weather_Station.Infra.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        ContextDb db = new ContextDb(null);

        public T Add(T TabelaGenerica)
        {
            try
            {
                db.Set<T>().Add(TabelaGenerica);
                db.SaveChanges();
                return TabelaGenerica;
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
                var buscaId = db.Set<T>().Find(id);
                db.Entry(buscaId).State = EntityState.Detached;
                return buscaId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().Where(filter).AsNoTracking().ToList();
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return db.Set<T>().ToList();
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
                db.Set<T>().Remove(tabelaGenerica);
                db.SaveChanges();
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
                db.Entry(tabelaGenerica).State = EntityState.Modified;
                db.SaveChanges();
                return true;
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
                db.Set<T>().AddRange(listaTabelaGenerica);
                db.SaveChanges();
                return true;
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
                db.Set<T>().UpdateRange(listaTabelaGenerica);
                db.SaveChanges();
                return true;
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
                db.Set<T>().RemoveRange(listaTabelaGenerica);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
