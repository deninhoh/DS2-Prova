using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaYagoDS2.Models
{
    public class Alimento
    {
        public int AlimentoId { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
    }
}
