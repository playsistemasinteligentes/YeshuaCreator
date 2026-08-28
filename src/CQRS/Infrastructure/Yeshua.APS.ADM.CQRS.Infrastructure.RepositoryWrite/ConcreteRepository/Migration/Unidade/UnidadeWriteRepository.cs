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

namespace Input.Repository.Unidade
{
    public partial class UnidadeWriteRepository : IUnidadeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IUnidadeQueryWrite _query; 

        public UnidadeWriteRepository(IUnitOfWork unitOfWork,IUnidadeQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IUnidadeEntity Unidade)
        {
            var query = _query.InserirUnidadeQuery(Unidade);
        Unidade.UNI_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IUnidadeEntity Unidade)
        {
            var query = _query.UpdateUnidadeQuery(Unidade);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IUnidadeEntity Unidade)
        {
            var query = _query.DeleteUnidadeQuery(Unidade);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDEESCRICAO(int uni_id, string value)
        {
            var query = _query.UpdateDEESCRICAO(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUN(int uni_id, string value)
        {
            var query = _query.UpdateUN(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int uni_id, int value)
        {
            var query = _query.UpdateTenantID(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int uni_id, bool value)
        {
            var query = _query.UpdateDeleted(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int uni_id, DateTime value)
        {
            var query = _query.UpdateChanged(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int uni_id, int value)
        {
            var query = _query.UpdateUserId(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration