using NewAPI.Dominio.Execoes;
using NewAPI.Dominio.Interfaces;
using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System.Collections.Generic;

namespace NewAPI.Dominio.Servicos
{
    public class VinhoServicos : IVinhoServico
    {
        private IVinhoRepositorio _vinhoRepositorio;
        public VinhoServicos(IVinhoRepositorio vinhoRepositorio)
        {
            _vinhoRepositorio = vinhoRepositorio;
        }

        public IEnumerable<Vinho> Get()
        {
            return _vinhoRepositorio.GetVinho();
        }

        public Vinho Get(int Id)
        {
            return _vinhoRepositorio.GetVinho(Id);
        }

        public void Post(VinhoPostRequest vinho)
        {
            var retorno = _vinhoRepositorio.PostVinho(vinho);
            if (retorno == false)
                throw new DBExceptions();
        }

        public void Put(int id, VinhoPutRequest vinho)
        {
            var retorno = _vinhoRepositorio.PutVinho(id, vinho);

            if (retorno == false)
                throw new DBExceptions();
        }
        public void Delete(int id)
        {
            var retorno = _vinhoRepositorio.DeleteVinho(id);
            if (retorno == false)
                throw new DBExceptions();
        }
    }
}
