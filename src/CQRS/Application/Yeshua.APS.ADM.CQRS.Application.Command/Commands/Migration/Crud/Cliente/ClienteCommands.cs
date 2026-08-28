// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration
// </yeshua>

using RepositoryInterfaces.Patterns.Command;
namespace Command.Write
{
    public struct ClienteCrudCommand : ICommand
    {
        public string CLI_ID { get; set; }
        public string CLI_NOME { get; set; }
        public string CLI_FONE { get; set; }
        public string CLI_OBS { get; set; }
        public string CLI_ENDERECO_ENTREGA { get; set; }
        public string CLI_CPF_CNPJ { get; set; }
        public string CLI_BAIRRO_ENTREGA { get; set; }
        public string CLI_CEP_ENTREGA { get; set; }
        public string CLI_EMAIL { get; set; }
        public string CLI_INTEGRACAO { get; set; }
        public string MUN_ID_ENTREGA { get; set; }
        public Decimal? CLI_TRANSLADO { get; set; }
        public string CLI_REGIAO_ENTREGA { get; set; }
        public int? CLI_EXIGENTE_NA_IMPRESSAO { get; set; }
        public Decimal? CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO { get; set; }
        public Decimal? CLI_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
        public Decimal? CLI_PERCENTUAL_JANELA_EMBARQUE { get; set; }
        public string REP_ID { get; set; }
        public string CLI_RAZAO_SOCIAL { get; set; }
        public string CLI_EMAIL_MONITORAMENTO_TRANSPORTE { get; set; }
        public string CLI_CONTATO { get; set; }
        public string CLI_SETOR { get; set; }
        public string SEG_ID { get; set; }
        public string CLI_TIPO { get; set; }
        public string CLI_INTEGRACAO_ERP { get; set; }
        public Decimal? CLI_LATITUDE_ENTREGA { get; set; }
        public Decimal? CLI_LONGITUDE_ENTREGA { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration