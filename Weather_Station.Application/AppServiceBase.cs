using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Application.Interface;
using Weather_Station.Application.ModelResponse;
using Weather_Station.Application.Utils;
using Weather_Station.Domain.Interfaces.Services;

namespace Weather_Station.Application
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T: class
    {
        private readonly IServiceBase<T> _serviceBase;
        public AppServiceBase(IServiceBase<T> serviceBase) 
        {
            _serviceBase = serviceBase;
        }

        public T Add(T TabelaGenerica)
        {
            try
            {
                return _serviceBase.Add(TabelaGenerica);
            }
            catch(Exception) 
            {
                throw;
            }
        }

        public T GetById(Guid id)
        {
            try
            {
                return _serviceBase.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            return _serviceBase.GetByFilter(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public ResponseModels Delete(T tabelaGenerica)
        {
            ResponseModels resposta = new ResponseModels();
            try
            {
                _serviceBase.Delete(tabelaGenerica);
                resposta.Success = true;
                resposta.Error = false;
                resposta.Message = "Deletado com Sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                return new RestExceptions(e).TratarErro();
            }
        }

        public ResponseModels Update(T tabelaGenerica)
        {
            ResponseModels resposta = new ResponseModels();
            try
            {
                _serviceBase.Update(tabelaGenerica);
                resposta.Success = true;
                resposta.Error = false;
                resposta.Message = "Atualizado com Sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                return new RestExceptions(e).TratarErro();
            }
        }

        public ResponseModels AddRange(List<T> listaTabelaGenerica)
        {
            ResponseModels resposta = new ResponseModels();
            try
            {
                _serviceBase.AddRange(listaTabelaGenerica);
                resposta.Success = true;
                resposta.Error = false;
                resposta.Message = "Adcionado com Sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                return new RestExceptions(e).TratarErro();
            }
        }

        public ResponseModels UpdateRange(List<T> listaTabelaGenerica)
        {
            ResponseModels resposta = new ResponseModels();
            try
            {
                _serviceBase.UpdateRange(listaTabelaGenerica);
                resposta.Success = true;
                resposta.Error = false;
                resposta.Message = "Atualizado com Sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                return new RestExceptions(e).TratarErro();
            }
        }

        public ResponseModels DeleteRange(List<T> listaTabelaGenerica)
        {
            ResponseModels resposta = new ResponseModels();
            try
            {
                _serviceBase.DeleteRange(listaTabelaGenerica);
                resposta.Success = true;
                resposta.Error = false;
                resposta.Message = "Deletado com Sucesso";
                return resposta;
            }
            catch (Exception e)
            {
                return new RestExceptions(e).TratarErro();
            }
        }

    }
}
