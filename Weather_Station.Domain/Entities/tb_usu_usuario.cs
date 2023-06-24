using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Station.Domain.Entities
{
    public class tb_usu_usuario
    {
        public Guid usu_n_codigo { get; set; }
        public string usu_c_usuario { get; set; }
        public string usu_c_senha { get; set; }
    }
}
