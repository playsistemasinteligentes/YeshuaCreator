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

namespace Input.Repository.ProtocoloOnduladeira
{
    public partial class ProtocoloOnduladeiraWriteRepository : IProtocoloOnduladeiraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IProtocoloOnduladeiraQueryWrite _query; 

        public ProtocoloOnduladeiraWriteRepository(IUnitOfWork unitOfWork,IProtocoloOnduladeiraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IProtocoloOnduladeiraEntity ProtocoloOnduladeira)
        {
            var query = _query.InserirProtocoloOnduladeiraQuery(ProtocoloOnduladeira);
        ProtocoloOnduladeira.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IProtocoloOnduladeiraEntity ProtocoloOnduladeira)
        {
            var query = _query.UpdateProtocoloOnduladeiraQuery(ProtocoloOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IProtocoloOnduladeiraEntity ProtocoloOnduladeira)
        {
            var query = _query.DeleteProtocoloOnduladeiraQuery(ProtocoloOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePTO_ID(int id, string value)
        {
            var query = _query.UpdatePTO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePTO_CHAVE(int id, string value)
        {
            var query = _query.UpdatePTO_CHAVE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int id, string value)
        {
            var query = _query.UpdateMAQ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePTO_COMANDO(int id, string value)
        {
            var query = _query.UpdatePTO_COMANDO(id, value);
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