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

namespace Input.Repository.Transportadora
{
    public partial class TransportadoraWriteRepository : ITransportadoraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITransportadoraQueryWrite _query; 

        public TransportadoraWriteRepository(IUnitOfWork unitOfWork,ITransportadoraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITransportadoraEntity Transportadora)
        {
            var query = _query.InserirTransportadoraQuery(Transportadora);
        Transportadora.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITransportadoraEntity Transportadora)
        {
            var query = _query.UpdateTransportadoraQuery(Transportadora);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITransportadoraEntity Transportadora)
        {
            var query = _query.DeleteTransportadoraQuery(Transportadora);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_ID(int id, string value)
        {
            var query = _query.UpdateTRA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_NOME(int id, string value)
        {
            var query = _query.UpdateTRA_NOME(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_EMAIL(int id, string value)
        {
            var query = _query.UpdateTRA_EMAIL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_RESPONSAVEL(int id, string value)
        {
            var query = _query.UpdateTRA_RESPONSAVEL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_FONE(int id, string value)
        {
            var query = _query.UpdateTRA_FONE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_ID_INTEGRACAO(int id, string value)
        {
            var query = _query.UpdateTRA_ID_INTEGRACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTRA_ID_INTEGRACAO_ERP(int id, string value)
        {
            var query = _query.UpdateTRA_ID_INTEGRACAO_ERP(id, value);
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