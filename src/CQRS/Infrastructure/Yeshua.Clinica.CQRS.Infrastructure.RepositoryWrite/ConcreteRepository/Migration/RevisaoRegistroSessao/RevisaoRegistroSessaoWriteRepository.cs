// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

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

namespace Input.Repository.RevisaoRegistroSessao
{
    public partial class RevisaoRegistroSessaoWriteRepository : IRevisaoRegistroSessaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRevisaoRegistroSessaoQueryWrite _query; 

        public RevisaoRegistroSessaoWriteRepository(IUnitOfWork unitOfWork,IRevisaoRegistroSessaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRevisaoRegistroSessaoEntity RevisaoRegistroSessao)
        {
            var query = _query.InserirRevisaoRegistroSessaoQuery(RevisaoRegistroSessao);
        RevisaoRegistroSessao.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRevisaoRegistroSessaoEntity RevisaoRegistroSessao)
        {
            var query = _query.UpdateRevisaoRegistroSessaoQuery(RevisaoRegistroSessao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRevisaoRegistroSessaoEntity RevisaoRegistroSessao)
        {
            var query = _query.DeleteRevisaoRegistroSessaoQuery(RevisaoRegistroSessao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSessaoId(int id, int value)
        {
            var query = _query.UpdateSessaoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVersao(int id, int value)
        {
            var query = _query.UpdateVersao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAutorUserId(int id, int value)
        {
            var query = _query.UpdateAutorUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRevisadoEm(int id, DateTime value)
        {
            var query = _query.UpdateRevisadoEm(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMotivo(int id, string value)
        {
            var query = _query.UpdateMotivo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRegistro(int id, string value)
        {
            var query = _query.UpdateRegistro(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperationalEntityId(int id, string value)
        {
            var query = _query.UpdateOperationalEntityId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration