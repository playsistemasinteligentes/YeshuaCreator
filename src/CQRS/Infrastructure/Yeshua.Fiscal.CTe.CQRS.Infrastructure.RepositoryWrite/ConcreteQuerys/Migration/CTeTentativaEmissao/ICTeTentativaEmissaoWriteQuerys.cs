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

    public interface ICTeTentativaEmissaoQueryWrite 
     {
        public QueryModel InserirCTeTentativaEmissaoQuery(ICTeTentativaEmissaoEntity CTeTentativaEmissao);
        public QueryModel UpdateCTeTentativaEmissaoQuery(ICTeTentativaEmissaoEntity CTeTentativaEmissao);
        QueryModel UpdateCTeSolicitacaoFiscalId(int id, int value);
        QueryModel UpdateChaveAcesso(int id, string value);
        QueryModel UpdateNumero(int id, int value);
        QueryModel UpdateSerie(int id, int value);
        QueryModel UpdateTentativa(int id, int value);
        QueryModel UpdateXmlAssinadoStorageKey(int id, string value);
        QueryModel UpdateXmlProcStorageKey(int id, string value);
        QueryModel UpdateXmlHash(int id, string value);
        QueryModel UpdateCodigoRetorno(int id, string value);
        QueryModel UpdateMensagemRetorno(int id, string value);
        QueryModel UpdateProtocoloAutorizacao(int id, string value);
        QueryModel UpdateEnviadoEmUtc(int id, DateTime value);
        QueryModel UpdateAutorizadoEmUtc(int id, DateTime value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeTentativaEmissaoQuery(ICTeTentativaEmissaoEntity CTeTentativaEmissao);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration