using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System.Collections.Generic;

namespace NewAPI.Dominio.Interfaces
{
    public interface ICervejaServico
    {
        IEnumerable<Cerveja> Get();

        Cerveja Get(int id);

        void Post(CervejaPostRequest cerveja);

        void Put(int id, CervejaPutRequest cerveja);

        void Delete(int id);
    }
}
