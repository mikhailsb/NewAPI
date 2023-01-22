using NewAPI.Dominio.Execoes;
using NewAPI.Dominio.Interfaces;
using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System.Collections.Generic;

namespace NewAPI.Dominio.Servicos
{
    public class CervejaServico : ICervejaServico
    {
        private ICervejaRepositorio _cervejaRepositorio;
        public CervejaServico(ICervejaRepositorio cervejaRepositorio)
        {
            _cervejaRepositorio = cervejaRepositorio;
        }
        public IEnumerable<Cerveja> Get()
        {
            return _cervejaRepositorio.GetCervejas();
        }

        public Cerveja Get(int id)
        {
            return _cervejaRepositorio.GetCervejas(id);
        }

        public void Post(CervejaPostRequest cerveja)
        {
            var retorno = _cervejaRepositorio.PostCerveja(cerveja);

            if (retorno == false)
            {
                throw new DBExceptions();
            }
        }

        public void Put(int id, CervejaPutRequest cerveja)
        {
            var retorno = _cervejaRepositorio.PutCerveja(id, cerveja);

            if (retorno == false)
            {
                throw new DBExceptions();
            }
        }


        public void Delete(int id)
        {
            var retorno = _cervejaRepositorio.DeleteCerveja(id);

            if (retorno == false)
            {
                throw new DBExceptions();
            }
        }
    }

}
