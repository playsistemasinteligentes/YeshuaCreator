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

namespace Input.Repository.CTeEntradaOficial
{
    public partial class CTeEntradaOficialWriteRepository : ICTeEntradaOficialWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeEntradaOficialQueryWrite _query; 

        public CTeEntradaOficialWriteRepository(IUnitOfWork unitOfWork,ICTeEntradaOficialQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeEntradaOficialEntity CTeEntradaOficial)
        {
            var query = _query.InserirCTeEntradaOficialQuery(CTeEntradaOficial);
        CTeEntradaOficial.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeEntradaOficialEntity CTeEntradaOficial)
        {
            var query = _query.UpdateCTeEntradaOficialQuery(CTeEntradaOficial);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeEntradaOficialEntity CTeEntradaOficial)
        {
            var query = _query.DeleteCTeEntradaOficialQuery(CTeEntradaOficial);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSourceApplication(int id, string value)
        {
            var query = _query.UpdateSourceApplication(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSourceModule(int id, string value)
        {
            var query = _query.UpdateSourceModule(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSourceMessageId(int id, string value)
        {
            var query = _query.UpdateSourceMessageId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMessageType(int id, string value)
        {
            var query = _query.UpdateMessageType(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMessageVersion(int id, string value)
        {
            var query = _query.UpdateMessageVersion(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateReceivedAtUtc(int id, DateTime value)
        {
            var query = _query.UpdateReceivedAtUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayloadHash(int id, string value)
        {
            var query = _query.UpdatePayloadHash(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePayloadStorageKey(int id, string value)
        {
            var query = _query.UpdatePayloadStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
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