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

    public interface IContingenciaFiscalQueryWrite 
     {
        public QueryModel InserirContingenciaFiscalQuery(IContingenciaFiscalEntity ContingenciaFiscal);
        public QueryModel UpdateContingenciaFiscalQuery(IContingenciaFiscalEntity ContingenciaFiscal);
        QueryModel UpdateEmissaoFiscalTransporteId(int id, int value);
        QueryModel UpdateEntradaFiscalContingenciaId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateCargaId(int id, string value);
        QueryModel UpdateTipoSolicitante(int id, int value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateTomadorDocumento(int id, string value);
        QueryModel UpdateTransportadorDocumento(int id, string value);
        QueryModel UpdateQuantidadeDocumentos(int id, int value);
        QueryModel UpdateQuantidadeCTe(int id, int value);
        QueryModel UpdateQuantidadeMDFe(int id, int value);
        QueryModel UpdateValorCarga(int id, Decimal value);
        QueryModel UpdatePesoBruto(int id, Decimal value);
        QueryModel UpdateUltimaMensagem(int id, string value);
        QueryModel UpdateCriadoEmUtc(int id, DateTime value);
        QueryModel UpdateAtualizadoEmUtc(int id, DateTime value);
        QueryModel UpdateConcluidoEmUtc(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteContingenciaFiscalQuery(IContingenciaFiscalEntity ContingenciaFiscal);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration