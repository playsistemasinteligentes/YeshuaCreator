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

namespace Input.Repository.Rodovias
{
    public partial class RodoviasWriteRepository : IRodoviasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRodoviasQueryWrite _query; 

        public RodoviasWriteRepository(IUnitOfWork unitOfWork,IRodoviasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRodoviasEntity Rodovias)
        {
            var query = _query.InserirRodoviasQuery(Rodovias);
        Rodovias.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRodoviasEntity Rodovias)
        {
            var query = _query.UpdateRodoviasQuery(Rodovias);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRodoviasEntity Rodovias)
        {
            var query = _query.DeleteRodoviasQuery(Rodovias);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROD_ID(int id, int value)
        {
            var query = _query.UpdateROD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROD_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateROD_DESCRICAO(id, value);
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
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration