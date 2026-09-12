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

    public interface IEmissaoFiscalTransporteQueryWrite 
     {
        public QueryModel InserirEmissaoFiscalTransporteQuery(IEmissaoFiscalTransporteEntity EmissaoFiscalTransporte);
        public QueryModel UpdateEmissaoFiscalTransporteQuery(IEmissaoFiscalTransporteEntity EmissaoFiscalTransporte);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateOrigemFluxo(int id, int value);
        QueryModel UpdateCargaId(int id, string value);
        QueryModel UpdateRomaneioId(int id, string value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateTomadorDocumento(int id, string value);
        QueryModel UpdateTransportadorDocumento(int id, string value);
        QueryModel UpdateUFInicio(int id, string value);
        QueryModel UpdateUFFim(int id, string value);
        QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value);
        QueryModel UpdateMunicipioFimCodigoIbge(int id, string value);
        QueryModel UpdateQuantidadeNFe(int id, int value);
        QueryModel UpdateQuantidadeCTe(int id, int value);
        QueryModel UpdateQuantidadeMDFe(int id, int value);
        QueryModel UpdateValorCarga(int id, Decimal value);
        QueryModel UpdatePesoBruto(int id, Decimal value);
        QueryModel UpdateVolume(int id, Decimal value);
        QueryModel UpdateUltimaMensagem(int id, string value);
        QueryModel UpdateCriadoEmUtc(int id, DateTime value);
        QueryModel UpdateAtualizadoEmUtc(int id, DateTime value);
        QueryModel UpdateConcluidoEmUtc(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteEmissaoFiscalTransporteQuery(IEmissaoFiscalTransporteEntity EmissaoFiscalTransporte);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration