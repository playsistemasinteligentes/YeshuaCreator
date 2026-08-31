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

    public interface ICTeSolicitacaoFiscalQueryWrite 
     {
        public QueryModel InserirCTeSolicitacaoFiscalQuery(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal);
        public QueryModel UpdateCTeSolicitacaoFiscalQuery(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal);
        QueryModel UpdateEntradaOficialId(int id, int value);
        QueryModel UpdateRomaneioConsolidadoId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateAmbiente(int id, int value);
        QueryModel UpdateUFEmitente(int id, string value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateProdutoFiscal(int id, int value);
        QueryModel UpdateTipoCTe(int id, int value);
        QueryModel UpdateTipoServico(int id, int value);
        QueryModel UpdateModal(int id, int value);
        QueryModel UpdateGlobalizado(int id, int value);
        QueryModel UpdateUFInicio(int id, string value);
        QueryModel UpdateUFFim(int id, string value);
        QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value);
        QueryModel UpdateMunicipioFimCodigoIbge(int id, string value);
        QueryModel UpdateValorServico(int id, Decimal value);
        QueryModel UpdateValorCarga(int id, Decimal value);
        QueryModel UpdatePreferenciasManifestoJson(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeSolicitacaoFiscalQuery(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration