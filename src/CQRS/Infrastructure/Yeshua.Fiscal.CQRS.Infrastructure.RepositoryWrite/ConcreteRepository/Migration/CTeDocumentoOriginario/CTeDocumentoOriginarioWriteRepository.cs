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

namespace Input.Repository.CTeDocumentoOriginario
{
    public partial class CTeDocumentoOriginarioWriteRepository : ICTeDocumentoOriginarioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeDocumentoOriginarioQueryWrite _query; 

        public CTeDocumentoOriginarioWriteRepository(IUnitOfWork unitOfWork,ICTeDocumentoOriginarioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario)
        {
            var query = _query.InserirCTeDocumentoOriginarioQuery(CTeDocumentoOriginario);
        CTeDocumentoOriginario.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario)
        {
            var query = _query.UpdateCTeDocumentoOriginarioQuery(CTeDocumentoOriginario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeDocumentoOriginarioEntity CTeDocumentoOriginario)
        {
            var query = _query.DeleteCTeDocumentoOriginarioQuery(CTeDocumentoOriginario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            var query = _query.UpdateCTeSolicitacaoFiscalId(id, value);
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
        public void UpdateNumero(int id, string value)
        {
            var query = _query.UpdateNumero(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSerie(int id, string value)
        {
            var query = _query.UpdateSerie(id, value);
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
        public void UpdateValorDocumento(int id, Decimal value)
        {
            var query = _query.UpdateValorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePesoBruto(int id, Decimal value)
        {
            var query = _query.UpdatePesoBruto(id, value);
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