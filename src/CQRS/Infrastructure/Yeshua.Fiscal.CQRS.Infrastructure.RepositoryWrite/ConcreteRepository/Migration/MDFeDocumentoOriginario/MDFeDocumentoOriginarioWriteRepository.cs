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

namespace Input.Repository.MDFeDocumentoOriginario
{
    public partial class MDFeDocumentoOriginarioWriteRepository : IMDFeDocumentoOriginarioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMDFeDocumentoOriginarioQueryWrite _query; 

        public MDFeDocumentoOriginarioWriteRepository(IUnitOfWork unitOfWork,IMDFeDocumentoOriginarioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMDFeDocumentoOriginarioEntity MDFeDocumentoOriginario)
        {
            var query = _query.InserirMDFeDocumentoOriginarioQuery(MDFeDocumentoOriginario);
        MDFeDocumentoOriginario.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMDFeDocumentoOriginarioEntity MDFeDocumentoOriginario)
        {
            var query = _query.UpdateMDFeDocumentoOriginarioQuery(MDFeDocumentoOriginario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMDFeDocumentoOriginarioEntity MDFeDocumentoOriginario)
        {
            var query = _query.DeleteMDFeDocumentoOriginarioQuery(MDFeDocumentoOriginario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            var query = _query.UpdateMDFeSolicitacaoFiscalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumentoFiscalOriginarioId(int id, int value)
        {
            var query = _query.UpdateDocumentoFiscalOriginarioId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTipoDocumento(int id, string value)
        {
            var query = _query.UpdateTipoDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSnapshotJson(int id, string value)
        {
            var query = _query.UpdateSnapshotJson(id, value);
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