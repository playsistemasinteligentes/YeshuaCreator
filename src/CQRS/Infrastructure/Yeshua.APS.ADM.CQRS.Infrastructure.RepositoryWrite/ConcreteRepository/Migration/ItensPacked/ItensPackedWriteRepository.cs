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

namespace Input.Repository.ItensPacked
{
    public partial class ItensPackedWriteRepository : IItensPackedWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItensPackedQueryWrite _query; 

        public ItensPackedWriteRepository(IUnitOfWork unitOfWork,IItensPackedQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItensPackedEntity ItensPacked)
        {
            var query = _query.InserirItensPackedQuery(ItensPacked);
        ItensPacked.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItensPackedEntity ItensPacked)
        {
            var query = _query.UpdateItensPackedQuery(ItensPacked);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItensPackedEntity ItensPacked)
        {
            var query = _query.DeleteItensPackedQuery(ItensPacked);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_ID(int id, int value)
        {
            var query = _query.UpdateIPA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID(int id, string value)
        {
            var query = _query.UpdateCAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int id, string value)
        {
            var query = _query.UpdatePRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_COORDC(int id, Decimal value)
        {
            var query = _query.UpdateIPA_COORDC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_COORDL(int id, Decimal value)
        {
            var query = _query.UpdateIPA_COORDL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_COORDA(int id, Decimal value)
        {
            var query = _query.UpdateIPA_COORDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_DIMC(int id, Decimal value)
        {
            var query = _query.UpdateIPA_DIMC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_DIML(int id, Decimal value)
        {
            var query = _query.UpdateIPA_DIML(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_DIMA(int id, Decimal value)
        {
            var query = _query.UpdateIPA_DIMA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIPA_QTD_POR_PALETE(int id, Decimal value)
        {
            var query = _query.UpdateIPA_QTD_POR_PALETE(id, value);
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