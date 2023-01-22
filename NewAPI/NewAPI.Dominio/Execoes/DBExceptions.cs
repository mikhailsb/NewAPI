using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Dominio.Execoes
{
    public class DBExceptions:ApplicationException
    {
        public DBExceptions():base("Erro ao executar o bagulho no banco")
        {

        }
    }
}
