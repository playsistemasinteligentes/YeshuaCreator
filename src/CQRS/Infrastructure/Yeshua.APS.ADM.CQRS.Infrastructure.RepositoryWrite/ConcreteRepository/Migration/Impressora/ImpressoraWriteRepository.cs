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

namespace Input.Repository.Impressora
{
    public partial class ImpressoraWriteRepository : IImpressoraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IImpressoraQueryWrite _query; 

        public ImpressoraWriteRepository(IUnitOfWork unitOfWork,IImpressoraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IImpressoraEntity Impressora)
        {
            var query = _query.InserirImpressoraQuery(Impressora);
        Impressora.IMP_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IImpressoraEntity Impressora)
        {
            var query = _query.UpdateImpressoraQuery(Impressora);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IImpressoraEntity Impressora)
        {
            var query = _query.DeleteImpressoraQuery(Impressora);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIMP_IP(int imp_id, string value)
        {
            var query = _query.UpdateIMP_IP(imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIMP_NOME(int imp_id, string value)
        {
            var query = _query.UpdateIMP_NOME(imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int imp_id, int value)
        {
            var query = _query.UpdateTenantID(imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int imp_id, bool value)
        {
            var query = _query.UpdateDeleted(imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int imp_id, DateTime value)
        {
            var query = _query.UpdateChanged(imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int imp_id, int value)
        {
            var query = _query.UpdateUserId(imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration