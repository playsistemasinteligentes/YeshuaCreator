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

namespace Input.Repository.Mensagem
{
    public partial class MensagemWriteRepository : IMensagemWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMensagemQueryWrite _query; 

        public MensagemWriteRepository(IUnitOfWork unitOfWork,IMensagemQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMensagemEntity Mensagem)
        {
            var query = _query.InserirMensagemQuery(Mensagem);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IMensagemEntity Mensagem)
        {
            var query = _query.UpdateMensagemQuery(Mensagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMensagemEntity Mensagem)
        {
            var query = _query.DeleteMensagemQuery(Mensagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_SEND(string men_id, string value)
        {
            var query = _query.UpdateMEN_SEND(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_EMISSION(string men_id, DateTime value)
        {
            var query = _query.UpdateMEN_EMISSION(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_STATUS(string men_id, string value)
        {
            var query = _query.UpdateMEN_STATUS(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_RECEIVE(string men_id, string value)
        {
            var query = _query.UpdateMEN_RECEIVE(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_TYPE(string men_id, string value)
        {
            var query = _query.UpdateMEN_TYPE(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_QTD_TRY_SEND(string men_id, Decimal value)
        {
            var query = _query.UpdateMEN_QTD_TRY_SEND(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMEN_DATE_TRY_SEND(string men_id, DateTime value)
        {
            var query = _query.UpdateMEN_DATE_TRY_SEND(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string men_id, int value)
        {
            var query = _query.UpdateTenantID(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string men_id, bool value)
        {
            var query = _query.UpdateDeleted(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string men_id, DateTime value)
        {
            var query = _query.UpdateChanged(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string men_id, int value)
        {
            var query = _query.UpdateUserId(men_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration