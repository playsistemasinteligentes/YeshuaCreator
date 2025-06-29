using Dapper;
using Dominio.Entitys;
using Input.Querys.GrupoServico;
using Repositorio.Inputs.Repositorio.GrupoServico;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
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
        private readonly IUnitOfWork _UnitOfWork;

        public GrupoServicoWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IGrupoServicoEntity GrupoServico)
        {
            var query = new GrupoServicoWriteQuery().InserirGrupoServicoQuery(GrupoServico);
        GrupoServico.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IGrupoServicoEntity GrupoServico)
        {
            var query = new GrupoServicoWriteQuery().UpdateGrupoServicoQuery(GrupoServico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IGrupoServicoEntity GrupoServico)
        {
            var query = new GrupoServicoWriteQuery().DeleteGrupoServicoQuery(GrupoServico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration