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

    public interface IClienteQueryWrite 
     {
        public QueryModel InserirClienteQuery(IClienteEntity Cliente);
        public QueryModel UpdateClienteQuery(IClienteEntity Cliente);
        QueryModel UpdateCLI_NOME(string cli_id, string value);
        QueryModel UpdateCLI_FONE(string cli_id, string value);
        QueryModel UpdateCLI_OBS(string cli_id, string value);
        QueryModel UpdateCLI_ENDERECO_ENTREGA(string cli_id, string value);
        QueryModel UpdateCLI_CPF_CNPJ(string cli_id, string value);
        QueryModel UpdateCLI_BAIRRO_ENTREGA(string cli_id, string value);
        QueryModel UpdateCLI_CEP_ENTREGA(string cli_id, string value);
        QueryModel UpdateCLI_EMAIL(string cli_id, string value);
        QueryModel UpdateCLI_INTEGRACAO(string cli_id, string value);
        QueryModel UpdateMUN_ID_ENTREGA(string cli_id, string value);
        QueryModel UpdateCLI_TRANSLADO(string cli_id, Decimal value);
        QueryModel UpdateCLI_REGIAO_ENTREGA(string cli_id, string value);
        QueryModel UpdateCLI_EXIGENTE_NA_IMPRESSAO(string cli_id, int value);
        QueryModel UpdateCLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO(string cli_id, Decimal value);
        QueryModel UpdateCLI_TEMPO_DESCARREGAMENTO_UNITARIO(string cli_id, Decimal value);
        QueryModel UpdateCLI_PERCENTUAL_JANELA_EMBARQUE(string cli_id, Decimal value);
        QueryModel UpdateREP_ID(string cli_id, string value);
        QueryModel UpdateCLI_RAZAO_SOCIAL(string cli_id, string value);
        QueryModel UpdateCLI_EMAIL_MONITORAMENTO_TRANSPORTE(string cli_id, string value);
        QueryModel UpdateCLI_CONTATO(string cli_id, string value);
        QueryModel UpdateCLI_SETOR(string cli_id, string value);
        QueryModel UpdateSEG_ID(string cli_id, string value);
        QueryModel UpdateCLI_TIPO(string cli_id, string value);
        QueryModel UpdateCLI_INTEGRACAO_ERP(string cli_id, string value);
        QueryModel UpdateCLI_LATITUDE_ENTREGA(string cli_id, Decimal value);
        QueryModel UpdateCLI_LONGITUDE_ENTREGA(string cli_id, Decimal value);
        QueryModel UpdateTenantID(string cli_id, int value);
        QueryModel UpdateDeleted(string cli_id, bool value);
        QueryModel UpdateChanged(string cli_id, DateTime value);
        QueryModel UpdateUserId(string cli_id, int value);
        public QueryModel DeleteClienteQuery(IClienteEntity Cliente);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration