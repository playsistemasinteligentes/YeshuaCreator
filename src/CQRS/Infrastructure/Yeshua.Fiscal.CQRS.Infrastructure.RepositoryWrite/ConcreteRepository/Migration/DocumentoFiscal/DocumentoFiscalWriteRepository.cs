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

namespace Input.Repository.DocumentoFiscal
{
    public partial class DocumentoFiscalWriteRepository : IDocumentoFiscalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IDocumentoFiscalQueryWrite _query; 

        public DocumentoFiscalWriteRepository(IUnitOfWork unitOfWork,IDocumentoFiscalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IDocumentoFiscalEntity DocumentoFiscal)
        {
            var query = _query.InserirDocumentoFiscalQuery(DocumentoFiscal);
        DocumentoFiscal.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IDocumentoFiscalEntity DocumentoFiscal)
        {
            var query = _query.UpdateDocumentoFiscalQuery(DocumentoFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IDocumentoFiscalEntity DocumentoFiscal)
        {
            var query = _query.DeleteDocumentoFiscalQuery(DocumentoFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoFiscal(int id, int value)
        {
            var query = _query.UpdateProdutoFiscal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSerie(int id, int value)
        {
            var query = _query.UpdateSerie(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNumero(int id, int value)
        {
            var query = _query.UpdateNumero(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAmbiente(int id, int value)
        {
            var query = _query.UpdateAmbiente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFEmitente(int id, string value)
        {
            var query = _query.UpdateUFEmitente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmitenteDocumento(int id, string value)
        {
            var query = _query.UpdateEmitenteDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDestinatarioDocumento(int id, string value)
        {
            var query = _query.UpdateDestinatarioDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlStorageKey(int id, string value)
        {
            var query = _query.UpdateXmlStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlHash(int id, string value)
        {
            var query = _query.UpdateXmlHash(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProtocoloAutorizacao(int id, string value)
        {
            var query = _query.UpdateProtocoloAutorizacao(id, value);
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