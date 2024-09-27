using Dapper;
using Dominio.Entitys.GrupoServico;
using Input.Querys.GrupoServico;
using Repositorio.Inputs.Repositorio.GrupoServico;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.GrupoServico
{
    public class GrupoServicoWriteRepository : IGrupoServicoWriteRepository
    {
        private readonly IDbConnection _Connection;

        public GrupoServicoWriteRepository(SqlFactory factory)
        {
            _Connection = factory.SqlConnection();
        }

        public void Insert(GrupoServicoEntity GrupoServico)
        {
            var query = new GrupoServicoWriteQuery().InserirGrupoServicoQuery(GrupoServico);
            using (var conn = _Connection) 
            {
                _Connection.Execute(query.Query, query.Parameters);
            }
        }

        public void InsertSmall(GrupoServicoEntity GrupoServico)
        {
            throw new NotImplementedException();
        }
    }
}
