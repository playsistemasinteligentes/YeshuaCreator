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
namespace Command.Read
{
    public struct MovimentoEstoqueReadCommand : ICommandRead
    {
        public int? Id { get; set; }
        public string ProdutoId { get; set; }
        public string OrderId { get; set; }
        public string Tipo { get; set; }
        public string TurnoId { get; set; }
        public string TurmaId { get; set; }
        public Decimal? Quantidade { get; set; }
        public Decimal? MOV_PESO_UNITARIO { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
        public DateTime? DataHoraEmissao { get; set; }
        public string DiaTurma { get; set; }
        public string Lote { get; set; }
        public string SubLote { get; set; }
        public string MaquinaId { get; set; }
        public int? USE_ID { get; set; }
        public string Observacao { get; set; }
        public string OcorrenciaId { get; set; }
        public string Armazem { get; set; }
        public string Endereco { get; set; }
        public string Estorno { get; set; }
        public int? SequenciaTransformacao { get; set; }
        public int? SequenciaRepeticao { get; set; }
        public string ObsOpParcial { get; set; }
        public string OcoIdOpParcial { get; set; }
        public string MOV_ID_INTEGRACAO { get; set; }
        public string MOV_ID_INTEGRACAO_ERP { get; set; }
        public string CAR_ID { get; set; }
        public int? MOV_ID_DESTINO { get; set; }
        public string PRO_ID_DESTINO { get; set; }
        public string MOV_LOTE_DESTINO { get; set; }
        public string MOV_SUB_LOTE_DESTINO { get; set; }
        public int? MOV_ID_ORIGEM { get; set; }
        public string PRO_ID_ORIGEM { get; set; }
        public string MOV_LOTE_ORIGEM { get; set; }
        public string MOV_SUB_LOTE_ORIGEM { get; set; }
        public int? MOV_TYPE { get; set; }
        public string MOV_DOC { get; set; }
        public string MOV_APROVEITAMENTO { get; set; }
        public string MOV_RETIDO { get; set; }
        public string MOV_VINCOS_ONDULADEIRA { get; set; }
        public string BOL_ID { get; set; }
        public string ORD_ID_ORIGEM { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? VER_ID { get; set; }
        public string MOV_TIPO_CUSTO { get; set; }
        public string MOV_GRUPO_CONTABIL { get; set; }
        public string FOR_ID { get; set; }
        public string CLI_ID { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration