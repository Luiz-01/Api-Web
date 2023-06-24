using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Application.ModelResponse;

namespace Weather_Station.Application.Utils
{
    public class RestExceptions : Exception
    {
        public string name { get; set; }
        public Exception innerException { get; set; }

        public RestExceptions (Exception innerException)
        {

        }

        public ResponseModels TratarErro()
        {
            ResponseModels model = new ResponseModels();

            if (innerException is DbUpdateException exception)
            {
                if (exception.InnerException != null)
                {
                    if (exception.InnerException.Message.Contains("REFERENCE Constraint"))
                    {
                        model.Message = string.Format("{0} possui vinculo e não pode ser removido ou alterado", name);
                    }
                    else if (exception.InnerException.Message.Contains("Cannot insert duplicate key"))
                    {
                        model.Message = string.Format("{0} ja existente", name);
                    }
                }
                model.Success = false;
                model.Error = false;
            }

            if (string.IsNullOrEmpty(model.Message))
            {
                if (innerException.InnerException != null)
                {
                    model.Message = innerException.InnerException.Message;
                }
                else
                {
                    model.Message = innerException.Message;
                }
                model.Success = false;
                model.Error = true;
            }

            return model;
        }
    }
}
