using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Dominio.Interfaces
{
    public interface IVinhoServico
    {
        IEnumerable<Vinho> Get();
        Vinho Get(int Id);
        void Post(VinhoPostRequest vinho);
        void Put(int id, VinhoPutRequest vinho);
        void Delete(int id);
    }
}
