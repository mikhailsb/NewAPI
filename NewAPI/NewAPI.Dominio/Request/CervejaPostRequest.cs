using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Dominio.Request
{
    public class CervejaPostRequest
    {
        public string Nome { get; set; }
        public string Estilo { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
    }
}
