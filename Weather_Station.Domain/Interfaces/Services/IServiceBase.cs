using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Station.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T :  class
    {

        public T Add(T TabelaGenerica);
        public T GetById(Guid id);

        public List<T> GetByFilter(Expression<Func<T, bool>> filter);
        public IEnumerable<T> GetAll();
        public  void Delete(T tabelaGenerica);
        public bool Update(T tabelaGenerica);


        public bool AddRange(List<T> listaTabelaGenerica);
        public bool UpdateRange(List<T> listaTabelaGenerica);
        public bool DeleteRange(List<T> listaTabelaGenerica);

    }
}
