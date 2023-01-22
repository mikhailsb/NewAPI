using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Dominio.Request
{
    public class VinhoPostRequest
    {
        public string Nome { get; set; }
        public string Uva { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
    }
}
