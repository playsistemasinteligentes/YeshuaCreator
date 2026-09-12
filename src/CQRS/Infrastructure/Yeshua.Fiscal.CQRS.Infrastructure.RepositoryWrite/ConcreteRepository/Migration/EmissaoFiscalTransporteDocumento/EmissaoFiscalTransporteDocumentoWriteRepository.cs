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

namespace Input.Repository.EmissaoFiscalTransporteDocumento
{
    public partial class EmissaoFiscalTransporteDocumentoWriteRepository : IEmissaoFiscalTransporteDocumentoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEmissaoFiscalTransporteDocumentoQueryWrite _query; 

        public EmissaoFiscalTransporteDocumentoWriteRepository(IUnitOfWork unitOfWork,IEmissaoFiscalTransporteDocumentoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento)
        {
            var query = _query.InserirEmissaoFiscalTransporteDocumentoQuery(EmissaoFiscalTransporteDocumento);
        EmissaoFiscalTransporteDocumento.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento)
        {
            var query = _query.UpdateEmissaoFiscalTransporteDocumentoQuery(EmissaoFiscalTransporteDocumento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento)
        {
            var query = _query.DeleteEmissaoFiscalTransporteDocumentoQuery(EmissaoFiscalTransporteDocumento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmissaoFiscalTransporteId(int id, int value)
        {
            var query = _query.UpdateEmissaoFiscalTransporteId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumentoFiscalId(int id, int value)
        {
            var query = _query.UpdateDocumentoFiscalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumentoFiscalOriginarioId(int id, int value)
        {
            var query = _query.UpdateDocumentoFiscalOriginarioId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNFeProdutoSnapshotId(int id, int value)
        {
            var query = _query.UpdateNFeProdutoSnapshotId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoFiscal(int id, int value)
        {
            var query = _query.UpdateProdutoFiscal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePapel(int id, int value)
        {
            var query = _query.UpdatePapel(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoEvento(int id, string value)
        {
            var query = _query.UpdateTipoEvento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlStorageKey(int id, string value)
        {
            var query = _query.UpdateXmlStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePdfStorageKey(int id, string value)
        {
            var query = _query.UpdatePdfStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProtocolo(int id, string value)
        {
            var query = _query.UpdateProtocolo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCodigoRetorno(int id, string value)
        {
            var query = _query.UpdateCodigoRetorno(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMensagemRetorno(int id, string value)
        {
            var query = _query.UpdateMensagemRetorno(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCriadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateCriadoEmUtc(id, value);
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