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

namespace Input.Repository.NFeProdutoSnapshot
{
    public partial class NFeProdutoSnapshotWriteRepository : INFeProdutoSnapshotWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly INFeProdutoSnapshotQueryWrite _query; 

        public NFeProdutoSnapshotWriteRepository(IUnitOfWork unitOfWork,INFeProdutoSnapshotQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(INFeProdutoSnapshotEntity NFeProdutoSnapshot)
        {
            var query = _query.InserirNFeProdutoSnapshotQuery(NFeProdutoSnapshot);
        NFeProdutoSnapshot.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(INFeProdutoSnapshotEntity NFeProdutoSnapshot)
        {
            var query = _query.UpdateNFeProdutoSnapshotQuery(NFeProdutoSnapshot);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(INFeProdutoSnapshotEntity NFeProdutoSnapshot)
        {
            var query = _query.DeleteNFeProdutoSnapshotQuery(NFeProdutoSnapshot);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDocumentoFiscalOriginarioId(int id, int value)
        {
            var query = _query.UpdateDocumentoFiscalOriginarioId(id, value);
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
        public void UpdatePedidoId(int id, string value)
        {
            var query = _query.UpdatePedidoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChaveAcesso(int id, string value)
        {
            var query = _query.UpdateChaveAcesso(id, value);
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
        public void UpdateUFOrigem(int id, string value)
        {
            var query = _query.UpdateUFOrigem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFDestino(int id, string value)
        {
            var query = _query.UpdateUFDestino(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioOrigemCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioOrigemCodigoIbge(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioDestinoCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioDestinoCodigoIbge(id, value);
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
        public void UpdateVolume(int id, Decimal value)
        {
            var query = _query.UpdateVolume(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateXmlStorageKey(int id, string value)
        {
            var query = _query.UpdateXmlStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSnapshotJson(int id, string value)
        {
            var query = _query.UpdateSnapshotJson(id, value);
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