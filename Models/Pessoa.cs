using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaYagoDS2.Models
{
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        [Required]
        public String Nome { get; set; }
        public String Profissao { get; set; }
        [Required]
        public int Idade { get; set; }
    }
}
