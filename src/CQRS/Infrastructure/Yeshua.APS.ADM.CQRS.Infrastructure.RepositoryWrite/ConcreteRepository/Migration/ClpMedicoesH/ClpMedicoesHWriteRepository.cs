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

namespace Input.Repository.ClpMedicoesH
{
    public partial class ClpMedicoesHWriteRepository : IClpMedicoesHWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IClpMedicoesHQueryWrite _query; 

        public ClpMedicoesHWriteRepository(IUnitOfWork unitOfWork,IClpMedicoesHQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IClpMedicoesHEntity ClpMedicoesH)
        {
            var query = _query.InserirClpMedicoesHQuery(ClpMedicoesH);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IClpMedicoesHEntity ClpMedicoesH)
        {
            var query = _query.UpdateClpMedicoesHQuery(ClpMedicoesH);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IClpMedicoesHEntity ClpMedicoesH)
        {
            var query = _query.DeleteClpMedicoesHQuery(ClpMedicoesH);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQUINA_ID(int id, string value)
        {
            var query = _query.UpdateMAQUINA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDATA_INI(int id, DateTime value)
        {
            var query = _query.UpdateDATA_INI(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDATA_FIM(int id, DateTime value)
        {
            var query = _query.UpdateDATA_FIM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLP_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateCLP_EMISSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQTD(int id, Decimal value)
        {
            var query = _query.UpdateQTD(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRUPO(int id, Decimal value)
        {
            var query = _query.UpdateGRUPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSTATUS(int id, int value)
        {
            var query = _query.UpdateSTATUS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateURN_ID(int id, string value)
        {
            var query = _query.UpdateURN_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateURM_ID(int id, string value)
        {
            var query = _query.UpdateURM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateID_LOTE_CLP(int id, int value)
        {
            var query = _query.UpdateID_LOTE_CLP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID(int id, string value)
        {
            var query = _query.UpdateOCO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFASE(int id, int value)
        {
            var query = _query.UpdateFASE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLP_ORIGEM(int id, string value)
        {
            var query = _query.UpdateCLP_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLP_LOTE(int id, int value)
        {
            var query = _query.UpdateCLP_LOTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOMPACTA(int id, int value)
        {
            var query = _query.UpdateCOMPACTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int id, string value)
        {
            var query = _query.UpdateBOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA(int id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA(id, value);
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