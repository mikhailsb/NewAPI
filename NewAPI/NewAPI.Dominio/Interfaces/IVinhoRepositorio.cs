using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Dominio.Interfaces
{
    public interface IVinhoRepositorio
    {
        IEnumerable<Vinho> GetVinho();
        Vinho GetVinho(int Id);
        bool PostVinho(VinhoPostRequest vinho);
        bool PutVinho(int id, VinhoPutRequest vinho);
        bool DeleteVinho(int id);
    }
}
