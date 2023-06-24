using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Weather_Station.Api.Models
{
    public class UsarioModel
    {
        [Key]
        public Guid usu_n_codigo { get; set; }

        [DisplayName("Usuário")]
        [Required(ErrorMessage = "{0}: É obrigatorio")]
        [MaxLength(100, ErrorMessage = "{0}: Máximo {1} caracteres")]
        public string usu_c_usuario { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "{0}: É obrigatorio")]
        [MaxLength(100, ErrorMessage = "{0}: Máximo {1} caracteres")]
        public string usu_c_senha { get; set; }

        public bool Admin { get; set; }
    }
}
