using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Station.Application.ModelResponse
{
    public class ResponseModels
    {
        public ResponseModels()
        {

        }

        public ResponseModels(ResponseModels parametro)
        {

            Success = parametro.Success;
            Error = parametro.Error;
            Message = parametro.Message;

        }

        public bool Success { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
