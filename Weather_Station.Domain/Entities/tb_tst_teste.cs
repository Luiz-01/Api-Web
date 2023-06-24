using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Station.Domain.Entities
{
    public class tb_tst_teste
    {
        [Key]
        public Guid tst_n_codigo { get; set; }
        public string tst_c_teste { get; set; }
    }
}
