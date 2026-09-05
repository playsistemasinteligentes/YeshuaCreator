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

namespace Input.Repository.MDFeSolicitacaoFiscal
{
    public partial class MDFeSolicitacaoFiscalWriteRepository : IMDFeSolicitacaoFiscalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMDFeSolicitacaoFiscalQueryWrite _query; 

        public MDFeSolicitacaoFiscalWriteRepository(IUnitOfWork unitOfWork,IMDFeSolicitacaoFiscalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal)
        {
            var query = _query.InserirMDFeSolicitacaoFiscalQuery(MDFeSolicitacaoFiscal);
        MDFeSolicitacaoFiscal.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal)
        {
            var query = _query.UpdateMDFeSolicitacaoFiscalQuery(MDFeSolicitacaoFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal)
        {
            var query = _query.DeleteMDFeSolicitacaoFiscalQuery(MDFeSolicitacaoFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCargaId(int id, string value)
        {
            var query = _query.UpdateCargaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAmbiente(int id, int value)
        {
            var query = _query.UpdateAmbiente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFCarregamento(int id, string value)
        {
            var query = _query.UpdateUFCarregamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFDescarregamento(int id, string value)
        {
            var query = _query.UpdateUFDescarregamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePlacaVeiculo(int id, string value)
        {
            var query = _query.UpdatePlacaVeiculo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCondutorDocumento(int id, string value)
        {
            var query = _query.UpdateCondutorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumentosOriginariosJson(int id, string value)
        {
            var query = _query.UpdateDocumentosOriginariosJson(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransporteSnapshotJson(int id, string value)
        {
            var query = _query.UpdateTransporteSnapshotJson(id, value);
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