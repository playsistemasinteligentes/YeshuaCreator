// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface IEntradaFiscalContingenciaQueryWrite 
     {
        public QueryModel InserirEntradaFiscalContingenciaQuery(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia);
        public QueryModel UpdateEntradaFiscalContingenciaQuery(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateCargaId(int id, string value);
        QueryModel UpdateTipoSolicitante(int id, int value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateSourceApplication(int id, string value);
        QueryModel UpdateSourceModule(int id, string value);
        QueryModel UpdateSourceMessageId(int id, string value);
        QueryModel UpdateEmitenteFiscalDocumento(int id, string value);
        QueryModel UpdateTomadorDocumento(int id, string value);
        QueryModel UpdateTransportadorDocumento(int id, string value);
        QueryModel UpdateRemetenteDocumento(int id, string value);
        QueryModel UpdateDestinatarioDocumento(int id, string value);
        QueryModel UpdateUFInicio(int id, string value);
        QueryModel UpdateUFFim(int id, string value);
        QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value);
        QueryModel UpdateMunicipioFimCodigoIbge(int id, string value);
        QueryModel UpdateRNTRC(int id, string value);
        QueryModel UpdatePlacaVeiculo(int id, string value);
        QueryModel UpdateUFVeiculo(int id, string value);
        QueryModel UpdateCondutorDocumento(int id, string value);
        QueryModel UpdateCondutorNome(int id, string value);
        QueryModel UpdateQuantidadeDocumentos(int id, int value);
        QueryModel UpdateValorCarga(int id, Decimal value);
        QueryModel UpdatePesoBruto(int id, Decimal value);
        QueryModel UpdateVolume(int id, Decimal value);
        QueryModel UpdatePendenciasJson(int id, string value);
        QueryModel UpdateSnapshotJson(int id, string value);
        QueryModel UpdateEmissaoFiscalCorrelationId(int id, string value);
        QueryModel UpdateEmissaoFiscalSagaId(int id, int value);
        QueryModel UpdateCriadoEmUtc(int id, DateTime value);
        QueryModel UpdateAtualizadoEmUtc(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEntradaFiscalContingenciaQuery(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration