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

namespace Input.Repository.EntradaFiscalContingencia
{
    public partial class EntradaFiscalContingenciaWriteRepository : IEntradaFiscalContingenciaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEntradaFiscalContingenciaQueryWrite _query; 

        public EntradaFiscalContingenciaWriteRepository(IUnitOfWork unitOfWork,IEntradaFiscalContingenciaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia)
        {
            var query = _query.InserirEntradaFiscalContingenciaQuery(EntradaFiscalContingencia);
        EntradaFiscalContingencia.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia)
        {
            var query = _query.UpdateEntradaFiscalContingenciaQuery(EntradaFiscalContingencia);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia)
        {
            var query = _query.DeleteEntradaFiscalContingenciaQuery(EntradaFiscalContingencia);
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
        public void UpdateTipoSolicitante(int id, int value)
        {
            var query = _query.UpdateTipoSolicitante(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAmbiente(int id, int value)
        {
            var query = _query.UpdateAmbiente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSourceApplication(int id, string value)
        {
            var query = _query.UpdateSourceApplication(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSourceModule(int id, string value)
        {
            var query = _query.UpdateSourceModule(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSourceMessageId(int id, string value)
        {
            var query = _query.UpdateSourceMessageId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmitenteFiscalDocumento(int id, string value)
        {
            var query = _query.UpdateEmitenteFiscalDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTomadorDocumento(int id, string value)
        {
            var query = _query.UpdateTomadorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTransportadorDocumento(int id, string value)
        {
            var query = _query.UpdateTransportadorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRemetenteDocumento(int id, string value)
        {
            var query = _query.UpdateRemetenteDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDestinatarioDocumento(int id, string value)
        {
            var query = _query.UpdateDestinatarioDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFInicio(int id, string value)
        {
            var query = _query.UpdateUFInicio(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFFim(int id, string value)
        {
            var query = _query.UpdateUFFim(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioInicioCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioInicioCodigoIbge(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMunicipioFimCodigoIbge(int id, string value)
        {
            var query = _query.UpdateMunicipioFimCodigoIbge(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRNTRC(int id, string value)
        {
            var query = _query.UpdateRNTRC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePlacaVeiculo(int id, string value)
        {
            var query = _query.UpdatePlacaVeiculo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUFVeiculo(int id, string value)
        {
            var query = _query.UpdateUFVeiculo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCondutorDocumento(int id, string value)
        {
            var query = _query.UpdateCondutorDocumento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCondutorNome(int id, string value)
        {
            var query = _query.UpdateCondutorNome(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuantidadeDocumentos(int id, int value)
        {
            var query = _query.UpdateQuantidadeDocumentos(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorCarga(int id, Decimal value)
        {
            var query = _query.UpdateValorCarga(id, value);
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
        public void UpdatePendenciasJson(int id, string value)
        {
            var query = _query.UpdatePendenciasJson(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSnapshotJson(int id, string value)
        {
            var query = _query.UpdateSnapshotJson(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmissaoFiscalCorrelationId(int id, string value)
        {
            var query = _query.UpdateEmissaoFiscalCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEmissaoFiscalSagaId(int id, int value)
        {
            var query = _query.UpdateEmissaoFiscalSagaId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCriadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateCriadoEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAtualizadoEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateAtualizadoEmUtc(id, value);
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