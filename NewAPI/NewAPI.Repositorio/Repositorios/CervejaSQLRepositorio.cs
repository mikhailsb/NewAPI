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
    public class CervejaSQLRepositorio : ICervejaRepositorio,IDisposable
    {
        private IDbConnection _conexao;
        private bool disposedValue;
        public CervejaSQLRepositorio(string stringConnection)
        {
            _conexao = new SqlConnection(stringConnection);
        }

        public IEnumerable<Cerveja> GetCervejas()
        {
            var listaCerveja = _conexao.Query<Cerveja>("SELECT * FROM CERVEJA").ToList();

            return listaCerveja;
        }
        public Cerveja GetCervejas(int Id)
        {
            var listaCerveja = _conexao.QuerySingleOrDefault<Cerveja>($"SELECT * FROM CERVEJA WHERE Id = {Id}");
                
                //<Cerveja>($"SELECT * FROM CERVEJA WHERE Id = {Id}").FirstOrDefault();

            return listaCerveja;
        }

        public bool PostCerveja(CervejaPostRequest cerveja)
        {
            var query = @"INSERT INTO CERVEJA(Nome, Estilo, Marca, Descricao) 
                        VALUES(@Nome, @Estilo, @Marca, @Descricao)";
            var retorno = _conexao.Execute(query, new
            {
                Nome = cerveja.Nome,
                Estilo = cerveja.Estilo,
                Marca = cerveja.Marca,
                Descricao = cerveja.Descricao
            });

            if (retorno == 0)
                return false;

            return true;
        }
        public bool PutCerveja(int id, CervejaPutRequest cerveja)
        {
            var query = @"UPDATE CERVEJA 
                SET Nome = @Nome, Estilo = @Estilo, Marca = @Marca, Descricao = @Descricao
                WHERE Id = @Id";
            var retorno = _conexao.Execute(query, new
            {
                Nome = cerveja.Nome,
                Estilo = cerveja.Estilo,
                Marca = cerveja.Marca,
                Descricao = cerveja.Descricao,
                Id = id
            });

            if (retorno == 0)
                return false;

            return true;
        }
        public bool DeleteCerveja(int id)
        {
            var query = @"DELETE FROM CERVEJA
                            WHERE Id = @Id";
            var retorno = _conexao.Execute(query, new
            {
                Id = id
            });

            if (retorno == 0)
                return false;

            return true;
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
