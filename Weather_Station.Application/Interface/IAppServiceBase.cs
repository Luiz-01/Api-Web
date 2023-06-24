using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Application.ModelResponse;

namespace Weather_Station.Application.Interface
{
    public interface IAppServiceBase<T> where T: class
    {
        public T Add(T TabelaGenerica);
        public T GetById(Guid id);

        public List<T> GetByFilter(Expression<Func<T, bool>> filter);
        public IEnumerable<T> GetAll();
        public ResponseModels Delete(T tabelaGenerica);
        public ResponseModels Update(T tabelaGenerica);


        public ResponseModels AddRange(List<T> listaTabelaGenerica);
        public ResponseModels UpdateRange(List<T> listaTabelaGenerica);
        public ResponseModels DeleteRange(List<T> listaTabelaGenerica);
    }
}
