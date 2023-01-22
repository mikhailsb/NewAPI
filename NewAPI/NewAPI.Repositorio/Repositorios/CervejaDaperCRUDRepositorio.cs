using Dapper;
using NewAPI.Dominio.Interfaces;
using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAPI.Repositorio.Repositorios
{
    public class CervejaDaperCRUDRepositorio : ICervejaRepositorio
    {
        private IDbConnection _conexao;
        private bool disposedValue;
        public CervejaDaperCRUDRepositorio(string stringConnection)
        {
            _conexao = new SqlConnection(stringConnection);
        }

        public IEnumerable<Cerveja> GetCervejas()
        {
            return _conexao.GetList<Cerveja>().ToList();
        }

        public Cerveja GetCervejas(int Id)
        {
            return _conexao.Get<Cerveja>(Id);
        }

        public bool PostCerveja(CervejaPostRequest cerveja)
        {
            var objeto = new Cerveja()
            {
                Nome = cerveja.Nome,
                Estilo = cerveja.Estilo,
                Marca = cerveja.Marca,
                Descricao = cerveja.Descricao
            };

            var retorno = _conexao.Insert(objeto);
            if (retorno != 0)
                return true;

            return false;
        }

        public bool PutCerveja(int id, CervejaPutRequest cerveja)
        {
            var objeto = new Cerveja()
            {
                Id = id,
                Nome = cerveja.Nome,
                Estilo = cerveja.Estilo,
                Marca = cerveja.Marca,
                Descricao = cerveja.Descricao
            };

            var retorno = _conexao.Update(objeto);
            if (retorno != 0)
                return true;

            return false;
        }
        public bool DeleteCerveja(int id)
        {
            var retorno = _conexao.Delete<Cerveja>(id);
            if (retorno != 0)
                return true;

            return false;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_conexao != null)
                    {
                        _conexao.Dispose();
                    }
                }
                disposedValue = true;
            }
        }
        public virtual void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
