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
    public class VinhoDapperCRUDRepositorio : IVinhoRepositorio
    {
        private IDbConnection _conexao;
        private bool disposedValue;
        public VinhoDapperCRUDRepositorio(string stringConnection)
        {
            _conexao = new SqlConnection(stringConnection);
        }
        public IEnumerable<Vinho> GetVinho()
        {
            return _conexao.GetList<Vinho>().ToList();
        }

        public Vinho GetVinho(int Id)
        {
            return _conexao.Get<Vinho>(Id);
        }

        public bool PostVinho(VinhoPostRequest vinho)
        {
            var objeto = new Vinho()
            {
                Nome = vinho.Nome,
                Uva = vinho.Uva,
                Marca = vinho.Marca,
                Descricao = vinho.Descricao
            };
            var retorno = _conexao.Insert(objeto);
            if (retorno != 0)
                return true;

            return false;
        }

        public bool PutVinho(int id, VinhoPutRequest vinho)
        {
            var objeto = new Vinho()
            {
                Id = id,
                Nome = vinho.Nome,
                Uva = vinho.Uva,
                Marca = vinho.Marca,
                Descricao = vinho.Descricao
            };
            var retorno = _conexao.Update(objeto);
            if (retorno != 0)
                return true;

            return false;
        }
        public bool DeleteVinho(int id)
        {
            var retorno = _conexao.Delete<Vinho>(id);
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
