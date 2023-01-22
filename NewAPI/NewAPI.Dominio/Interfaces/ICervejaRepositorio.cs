using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Dominio.Interfaces
{
    public interface ICervejaRepositorio
    {
        IEnumerable<Cerveja> GetCervejas();
        Cerveja GetCervejas(int Id);
        bool PostCerveja(CervejaPostRequest cerveja);
        bool PutCerveja(int id, CervejaPutRequest cerveja);
        bool DeleteCerveja(int id);
    }
}
