using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
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
       private readonly IGrupoServicoQueryWrite _query; 

        public GrupoServicoWriteRepository(IUnitOfWork unitOfWork,IGrupoServicoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IGrupoServicoEntity GrupoServico)
        {
            var query = _query.InserirGrupoServicoQuery(GrupoServico);
        GrupoServico.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IGrupoServicoEntity GrupoServico)
        {
            var query = _query.UpdateGrupoServicoQuery(GrupoServico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IGrupoServicoEntity GrupoServico)
        {
            var query = _query.DeleteGrupoServicoQuery(GrupoServico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(IGrupoServicoEntity entity)
        {
            var query = _query.UpdateDescricao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IGrupoServicoEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IGrupoServicoEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IGrupoServicoEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IGrupoServicoEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration