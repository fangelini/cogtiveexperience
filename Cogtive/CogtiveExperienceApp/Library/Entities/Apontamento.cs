using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Apontamento
    {
        public int IdApontamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int? NumeroLote { get; set; }
        public int IdEvento { get; set; }
        public int Quantidade { get; set; }
    }
}
