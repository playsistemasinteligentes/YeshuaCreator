// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityInternalMigration
// </yeshua>

using System;

namespace MyApp.Domain.Entities
{
    public class Produto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public Decimal? PRO_ESTOQUE_ATUAL { get; set; }
        public string UNI_ID { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public Decimal? PRO_FARDOS_POR_CAMADA { get; set; }
        public Decimal? PRO_CAMADAS_POR_PALETE { get; set; }
        public int? PRO_TIPO_IDENTIFICACAO { get; set; }
        public string PRO_GRUPO_PALETIZACAO { get; set; }
        public Decimal? PRO_PECAS_POR_FARDO { get; set; }
        public string PRO_ID_INTEGRACAO { get; set; }
        public string PRO_ID_INTEGRACAO_ERP { get; set; }
        public string GRP_ID { get; set; }
        public GrupoProdutoAbstrato GrupoProdutoAbstrato { get; set; }
        public int? TEM_ID { get; set; }
        public Decimal? PRO_LARGURA_PECA { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
        public Decimal? PRO_ALTURA_PECA { get; set; }
        public Decimal? PRO_LARGURA_EMBALADA { get; set; }
        public Decimal? PRO_COMPRIMENTO_EMBALADA { get; set; }
        public Decimal? PRO_ALTURA_EMBALADA { get; set; }
        public string PRO_FRENTE { get; set; }
        public string PRO_ROTACIONA_COMPRIMENTO { get; set; }
        public string PRO_ROTACIONA_LARGURA { get; set; }
        public string PRO_ROTACIONA_ALTURA { get; set; }
        public string PRO_ESCALA_COR { get; set; }
        public string PRO_SUB_ESCALA_COR { get; set; }
        public Decimal? PRO_CUSTO_SUBIDA_ESCALA_COR { get; set; }
        public Decimal? PRO_CUSTO_DECIDA_ESCALA_COR { get; set; }
        public string TMP_TIPO_CARGA { get; set; }
        public Decimal? PRO_TEMPO_CARREGAMENTO_UNITARIO { get; set; }
        public Decimal? PRO_TEMPO_DESCARREGAMENTO_UNITARIO { get; set; }
        public Decimal? PRO_PERCENTUAL_JANELA_EMBARQUE { get; set; }
        public Decimal? PRO_TEMPO_PRODUCAO_CONJUNTO { get; set; }
        public Decimal? PRO_PECAS_DA_PECA { get; set; }
        public int? PRO_TYPE { get; set; }
        public string PRO_COLOR_HEXA { get; set; }
        public string PRO_VINCOS_LARGURA { get; set; }
        public string PRO_VINCOS_COMPRIMENTO { get; set; }
        public Decimal? PRO_LARGURA_INTERNA { get; set; }
        public Decimal? PRO_COMPRIMENTO_INTERNA { get; set; }
        public Decimal? PRO_ALTURA_INTERNA { get; set; }
        public string PRO_COD_DESENHO { get; set; }
        public string PRO_FECHAMENTO { get; set; }
        public string PRO_TIPO_LAP { get; set; }
        public Decimal? PRO_TAMANHO_LAP { get; set; }
        public string PRO_LAP_PROLONGADO { get; set; }
        public Decimal? PRO_TAMANHO_LAP_PROLONG { get; set; }
        public Decimal? PRO_ARRANJO_LARGURA { get; set; }
        public Decimal? PRO_ARRANJO_COMPRIMENTO { get; set; }
        public int? PRO_FITILHOS_FARDO_LARG { get; set; }
        public int? PRO_FITILHOS_FARDO_COMP { get; set; }
        public int? PRO_FITILHOS_PALETE_LARG { get; set; }
        public int? PRO_FITILHOS_PALETE_COMP { get; set; }
        public int? PRO_FILME_PALETE { get; set; }
        public int? PRO_QTD_ESPELHO { get; set; }
        public Decimal? PRO_CUSTO { get; set; }
        public Decimal? PRO_AREA_LIQUIDA { get; set; }
        public Decimal? PRO_PESO { get; set; }
        public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
        public int? PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
        public string PRO_IMG_LASTRO { get; set; }
        public string ABN_ID { get; set; }
        public int? SEG_ID { get; set; }
        public string PRO_RESINA { get; set; }
        public string PRO_ENDURECEDOR_MIOLO { get; set; }
        public string PRO_VINCOS_ONDULADEIRA { get; set; }
        public int? PRO_ADICIONAL_ABA_SUPERIOR { get; set; }
        public int? PRO_ADICIONAL_ABA_INFERIOR { get; set; }
        public string PRO_PROMOVE_RESINA { get; set; }
        public Decimal? PRO_PROMOVE_DE { get; set; }
        public Decimal? PRO_PROMOVE_ATE { get; set; }
        public int? PRO_PROFUNDIDADE_VINCO { get; set; }
        public int VIN_ID { get; set; }
        public Vinco Vinco { get; set; }
        public string PRO_PROMOVE_PRODUTO { get; set; }
        public Decimal? PRO_TARA { get; set; }
        public Decimal? PRO_COMPRESSAO { get; set; }
        public string PRO_COD_BARRAS_CAIXA { get; set; }
        public string CJN_ID { get; set; }
        public string PRJ_ID { get; set; }
        public int? PRO_REFILE_LARGURA { get; set; }
        public int? PRO_REFILE_COMPRIMENTO { get; set; }
        public Decimal? PRO_M2_PONTA { get; set; }
        public int? PRO_QTD_CORTES_PECA1 { get; set; }
        public int? PRO_QTD_CORTES_PECA2 { get; set; }
        public string PRO_DIVISAO_MONTADA { get; set; }
        public Decimal? PRO_SEGMENTO_A { get; set; }
        public Decimal? PRO_SEGMENTO_B { get; set; }
        public Decimal? PRO_SEGMENTO_C { get; set; }
        public Decimal? PRO_SEGMENTO_D { get; set; }
        public Decimal? PRO_SEGMENTO_E { get; set; }
        public Decimal? PRO_SEGMENTO_F { get; set; }
        public Decimal? PRO_SEGMENTO_G { get; set; }
        public Decimal? PRO_SEGMENTO_H { get; set; }
        public Decimal? PRO_SEGMENTO_I { get; set; }
        public Decimal? PRO_QTD_GRAMPOS { get; set; }
        public Decimal? PRO_AREA_REFILE_INTERNO { get; set; }
        public Decimal? PRO_AREA_REFILE_EXTERNO { get; set; }
        public Decimal? PRO_PESO_REFILE { get; set; }
        public string PRO_ORELHA_INVERTIDA { get; set; }
        public string PRO_ENDERECO { get; set; }
        public string PRO_ID_VINCULADO { get; set; }
        public int? PRO_BATIDAS_PROXIMA_MANUTENCAO { get; set; }
        public string PRO_ENTRADA_NA_MAQUINA { get; set; }
        public string TDI_ID { get; set; }
        public int? PRO_QUEBRA_VINCO { get; set; }
        public int? PRO_LARGURA_FARDO { get; set; }
        public int? PRO_COMPRIMENTO_FARDO { get; set; }
        public Decimal? PRO_ALTURA_FARDO { get; set; }
        public string PRO_TIPO_CUSTO { get; set; }
        public string PRO_GRUPO_CONTABIL { get; set; }
        public string PRO_CLASSE_CUSTO_01 { get; set; }
        public string PRO_OBS_ALTERACAO { get; set; }
        public int? TIP_ID { get; set; }
        public Decimal? PRO_PECAS_POR_VEICULO { get; set; }
        public int? PRO_DISTANCIA_ENTRE_VINCOS { get; set; }
        public int? PRO_DISTANCIA_ENTRE_VINCOS2 { get; set; }
        public int? PRO_DISTANCIA_ENTRE_VINCOS3 { get; set; }
        public int? PRO_OUT { get; set; }
        public string PRO_ID_FACA { get; set; }
        public string PRO_ID_CLICHE { get; set; }
        public string PRO_ID_TINTA_01 { get; set; }
        public string PRO_ID_TINTA_02 { get; set; }
        public string PRO_ID_TINTA_03 { get; set; }
        public string PRO_ID_TINTA_04 { get; set; }
        public string PRO_ID_TINTA_05 { get; set; }
        public string PRO_ID_FORROSUP { get; set; }
        public string PRO_ID_CANTONEIRA { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string PRO_ID_TAMPO { get; set; }
        public string PRO_ID_FORROINF { get; set; }
        public string PRO_ID_CHAPA { get; set; }
        public string PRO_ID_COMPOSICAO { get; set; }
        public int? PRO_QUEBRA_VINCO_MAIOR { get; set; }
        public int? PRO_QUEBRA_VINCO_MENOR { get; set; }
        public string CLI_ID { get; set; }

        public static MyApp.QueryBuilder.Query<Produto> Query() => new MyApp.QueryBuilder.Query<Produto>();
    }

    public class Maquina
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public int? CAL_ID { get; set; }
        public Calendario Calendario { get; set; }
        public string MAQ_CONTROL_IP { get; set; }
        public string GMA_ID { get; set; }
        public DateTime? MAQ_ULTIMA_ATUALIZACAO { get; set; }
        public int? MAQ_SIRENE_SEMAFORO { get; set; }
        public string MAQ_COR_SEMAFORO { get; set; }
        public string MAQ_ID_MAQ_PAI { get; set; }
        public int? MAQ_TIPO_CONTADOR { get; set; }
        public string MAQ_TIPO_PLANEJAMENTO { get; set; }
        public int? MAQ_AVALIA_CUSTO { get; set; }
        public int? FPR_ID_OP_PRODUZINDO { get; set; }
        public int? MAQ_CONGELA_FILA { get; set; }
        public int? MAQ_TEMPO_MIN_PARADA { get; set; }
        public int? MAQ_QTD_CORES { get; set; }
        public string MAQ_ID_INTEGRACAO { get; set; }
        public string MAQ_ID_INTEGRACAO_ERP { get; set; }
        public Decimal? MAQ_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public string EQU_ID { get; set; }
        public Decimal? MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
        public string MAQ_ACOMPANHA_LOTE_PILOTO { get; set; }
        public int? MAQ_ID_SENSOR { get; set; }
        public int? MAQ_DEBOUNCING_LOW { get; set; }
        public int? MAQ_DEBOUNCING_HIGHT { get; set; }
        public int? MAQ_TIPO_SINAL { get; set; }
        public int? TEM_ID { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_DE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE { get; set; }
        public Decimal? MAQ_LARGURA_CHAPA_DE { get; set; }
        public Decimal? MAQ_LARGURA_CHAPA_ATE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR { get; set; }
        public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_LARGURA_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_LARGURA_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_ALTURA_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_ALTURA_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE { get; set; }
        public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE { get; set; }
        public Decimal? MAQ_ABA_DE { get; set; }
        public Decimal? MAQ_ABA_ATE { get; set; }
        public Decimal? MAQ_LAP_DE { get; set; }
        public Decimal? MAQ_LAP_ATE { get; set; }
        public string MAQ_ONDAS { get; set; }
        public string MAQ_PROLONGA_LAP { get; set; }
        public Decimal? MAQ_LARGURA_IMPRESSAO { get; set; }
        public Decimal? MAQ_COMPRIMENTO_IMPRESSAO { get; set; }
        public Decimal? MAQ_ROLO_DISPOSITIVO_DE { get; set; }
        public Decimal? MAQ_ROLO_DISPOSITIVO_ATE { get; set; }
        public string MAQ_FAMILIAS { get; set; }
        public Decimal? MAQ_REFILE_MINIMO { get; set; }
        public Decimal? MAQ_LARGURA_UTIL { get; set; }
        public Decimal? MAQ_TOTAL_ACO { get; set; }
        public string MAQ_FECHAMENTO { get; set; }
        public Decimal? MAQ_OPERACAO_VINCAR { get; set; }
        public Decimal? MAQ_OPERACAO_MONTA_DIVISAO { get; set; }
        public Decimal? MAQ_OPERACAO_SERRAR { get; set; }
        public string MAQ_TIPO_LAP { get; set; }
        public Decimal? MAQ_INDICE_PARADAS_POR_OP { get; set; }
        public int? MAQ_PERDA_MAXIMA { get; set; }
        public int? MAQ_TOTAL_PECAS_REFILANDO { get; set; }
        public int? MAQ_TOTAL_PECAS_NAO_REFILANDO { get; set; }
        public int? MAQ_TOTAL_VINCOS { get; set; }

        public static MyApp.QueryBuilder.Query<Maquina> Query() => new MyApp.QueryBuilder.Query<Maquina>();
    }

    public class GrupoMaquina
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public string GMA_TIPO_PLANEJAMENTO { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoMaquina> Query() => new MyApp.QueryBuilder.Query<GrupoMaquina>();
    }

    public class TemplateDeTestes
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public string Observacao { get; set; }

        public static MyApp.QueryBuilder.Query<TemplateDeTestes> Query() => new MyApp.QueryBuilder.Query<TemplateDeTestes>();
    }

    public class Roteiro
    {
        public int? Id { get; set; }
        public string MaquinaId { get; set; }
        public Maquina Maquina { get; set; }
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int SequenciaTransformacao { get; set; }
        public string GrupoMaquinaId { get; set; }
        public GrupoMaquina GrupoMaquina { get; set; }
        public Decimal? PecasPorPulso { get; set; }
        public Decimal? PrioridadeInformada { get; set; }
        public string Acao { get; set; }
        public Decimal Performance { get; set; }
        public Decimal? TempoSetup { get; set; }
        public Decimal? TempoSetupAjuste { get; set; }
        public int? ProximaSequenciaTransformacao { get; set; }
        public string Status { get; set; }
        public Decimal? HierarquiaSequenciaTransformacao { get; set; }
        public int? AvaliaCusto { get; set; }
        public string Operacoes { get; set; }
        public string ExcecaoOperacoes { get; set; }
        public Decimal? PercentualInicioPassoAnterior { get; set; }
        public string LinhaDireta { get; set; }
        public int? TemplateDeTestesId { get; set; }
        public TemplateDeTestes TemplateDeTestes { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Roteiro> Query() => new MyApp.QueryBuilder.Query<Roteiro>();
    }

    public class ConsultaPedido
    {
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string RazaoSocial { get; set; }
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public string ProdutoDescricao { get; set; }
        public string Status { get; set; }
        public string Estagio { get; set; }
        public DateTime DataEntregaDe { get; set; }
        public DateTime DataEntregaAte { get; set; }
        public DateTime? EmbarqueAlvo { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal SaldoAProduzir { get; set; }
        public Decimal? SaldoAExpedir { get; set; }
        public string CorFila { get; set; }
        public string PedidoCliente { get; set; }

        public static MyApp.QueryBuilder.Query<ConsultaPedido> Query() => new MyApp.QueryBuilder.Query<ConsultaPedido>();
    }

    public class RoteiroPedido
    {
        public string PedidoId { get; set; }
        public ConsultaPedido ConsultaPedido { get; set; }
        public string MaquinaId { get; set; }
        public Maquina Maquina { get; set; }
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int SequenciaTransformacao { get; set; }
        public string StatusCadastro { get; set; }
        public string TipoPlanejamento { get; set; }
        public int CalendarioId { get; set; }
        public Decimal? HierarquiaSequenciaTransformacao { get; set; }
        public int? ProximaSequenciaTransformacao { get; set; }
        public Decimal? Performance { get; set; }
        public Decimal? TempoSetup { get; set; }
        public Decimal? TempoSetupAjuste { get; set; }
        public Decimal? PecasPorPulso { get; set; }
        public Decimal? PrioridadeInformada { get; set; }
        public string Status { get; set; }
        public string Operacoes { get; set; }
        public string ExcecaoOperacoes { get; set; }
        public string LinhaDireta { get; set; }
        public int? AvaliaCusto { get; set; }
        public Decimal? PercentualInicioPassoAnterior { get; set; }
        public Decimal? MaquinaLarguraUtil { get; set; }
        public Decimal? GrupoTipo { get; set; }
        public Decimal GrupoPerformanceMetroLinear { get; set; }

        public static MyApp.QueryBuilder.Query<RoteiroPedido> Query() => new MyApp.QueryBuilder.Query<RoteiroPedido>();
    }

    public class T_AGENDA_SCHEDULE
    {
        public int? Id { get; set; }
        public int AGE_ID { get; set; }
        public DateTime? AGE_DATA_ESPECIFICA { get; set; }
        public string AGE_HORARIO_INICIO { get; set; }
        public string AGE_HORARIO_FIM { get; set; }
        public string AGE_SEGUNDA { get; set; }
        public string AGE_TERCA { get; set; }
        public string AGE_QUARTA { get; set; }
        public string AGE_QUINTA { get; set; }
        public string AGE_SEXTA { get; set; }
        public string AGE_SABADO { get; set; }
        public string AGE_DOMINGO { get; set; }
        public Decimal? AGE_INTERVALO { get; set; }
        public string AGE_ORDEM_EXECUCAO { get; set; }
        public string AGE_PARAMETROS { get; set; }
        public string AGE_EXCECAO { get; set; }
        public string AGE_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_AGENDA_SCHEDULE> Query() => new MyApp.QueryBuilder.Query<T_AGENDA_SCHEDULE>();
    }

    public class Auditoria
    {
        public int ID { get; set; }
        public DateTime DATA { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string ROTINA { get; set; }
        public string HISTORICO { get; set; }
        public string CHAVE { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Auditoria> Query() => new MyApp.QueryBuilder.Query<Auditoria>();
    }

    public class Boletim
    {
        public int? Id { get; set; }
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public string BOL_SOLVER { get; set; }
        public string BOL_INTEGRACAO { get; set; }
        public Decimal? BOL_SEQUENCIA { get; set; }
        public Decimal GRP_PAP_GRAMATURA_PROGRAMADO { get; set; }
        public string GRP_ID_PROGRAMADO { get; set; }
        public GrupoProdutoAbstrato GrupoProdutoAbstrato { get; set; }
        public string GRP_PAPEL1_PROGRAMADO { get; set; }
        public string GRP_PAPEL2_PROGRAMADO { get; set; }
        public string GRP_PAPEL3_PROGRAMADO { get; set; }
        public string GRP_PAPEL4_PROGRAMADO { get; set; }
        public string GRP_PAPEL5_PROGRAMADO { get; set; }
        public string BOL_STATUS_INTERFACE { get; set; }
        public string BOL_TIPO { get; set; }
        public int? BOL_FORMATO { get; set; }
        public Decimal? BOL_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? BOL_GRAMATURA_PAPEIS_REALIZADO { get; set; }
        public Decimal? BOL_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? BOL_CUSTO_PAPEIS_REALIZADO { get; set; }
        public Decimal? BOL_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? BOL_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public int? BOL_REFILE_OBRIGATORIO { get; set; }
        public string BOL_OBS { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Boletim> Query() => new MyApp.QueryBuilder.Query<Boletim>();
    }

    public class BoletimEstudo
    {
        public int? Id { get; set; }
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public string BOL_SOLVER { get; set; }
        public string BOL_INTEGRACAO { get; set; }
        public Decimal? BOL_SEQUENCIA { get; set; }
        public Decimal GRP_PAP_GRAMATURA_PROGRAMADO { get; set; }
        public string GRP_ID_PROGRAMADO { get; set; }
        public string GRP_PAPEL1_PROGRAMADO { get; set; }
        public string GRP_PAPEL2_PROGRAMADO { get; set; }
        public string GRP_PAPEL3_PROGRAMADO { get; set; }
        public string GRP_PAPEL4_PROGRAMADO { get; set; }
        public string GRP_PAPEL5_PROGRAMADO { get; set; }
        public string BOL_STATUS_INTERFACE { get; set; }
        public string BOL_TIPO { get; set; }
        public int? BOL_FORMATO { get; set; }
        public Decimal? BOL_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? BOL_GRAMATURA_PAPEIS_REALIZADO { get; set; }
        public Decimal? BOL_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? BOL_CUSTO_PAPEIS_REALIZADO { get; set; }
        public Decimal? BOL_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? BOL_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public int? BOL_REFILE_OBRIGATORIO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<BoletimEstudo> Query() => new MyApp.QueryBuilder.Query<BoletimEstudo>();
    }

    public class Calendario
    {
        public int CAL_ID { get; set; }
        public string CAL_DESCRICAO { get; set; }
        public int? CAL_DIVIDE_DIA_EM { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Calendario> Query() => new MyApp.QueryBuilder.Query<Calendario>();
    }

    public class CalendarioDisponibilidadeVeiculos
    {
        public int? Id { get; set; }
        public int CDV_ID { get; set; }
        public DateTime? CDV_DATA_DE { get; set; }
        public DateTime? CDV_DATA_ATE { get; set; }
        public int? CDV_SEGUNDA { get; set; }
        public int? CDV_TERCA { get; set; }
        public int? CDV_QUARTA { get; set; }
        public int? CDV_QUINTA { get; set; }
        public int? CDV_SEXTA { get; set; }
        public int? CDV_SABADO { get; set; }
        public int? CDV_DOMINGO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CalendarioDisponibilidadeVeiculos> Query() => new MyApp.QueryBuilder.Query<CalendarioDisponibilidadeVeiculos>();
    }

    public class Canhotos
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public string ORD_ID { get; set; }
        public string NOT_ID { get; set; }
        public DateTime? CAN_DATA_ENTREGA { get; set; }
        public string CAN_IMG { get; set; }
        public Decimal? CAN_LAT_ENTREGA { get; set; }
        public Decimal? CAN_LONG_ENTREGA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Canhotos> Query() => new MyApp.QueryBuilder.Query<Canhotos>();
    }

    public class Carga
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public DateTime? CAR_PREVISAO_MATERIA_PRIMA { get; set; }
        public DateTime? CAR_DATA_INICIO_PREVISTO { get; set; }
        public DateTime? CAR_DATA_INICIO_REALIZADO { get; set; }
        public DateTime? CAR_DATA_FIM_PREVISTO { get; set; }
        public DateTime? CAR_DATA_FIM_REALIZADO { get; set; }
        public DateTime? CAR_INICIO_JANELA_EMBARQUE { get; set; }
        public DateTime? CAR_FIM_JANELA_EMBARQUE { get; set; }
        public DateTime? CAR_EMBARQUE_ALVO { get; set; }
        public Decimal? CAR_STATUS { get; set; }
        public Decimal? CAR_PESO_TEORICO { get; set; }
        public Decimal? CAR_VOLUME_TEORICO { get; set; }
        public Decimal? CAR_PESO_REAL { get; set; }
        public Decimal? CAR_VOLUME_REAL { get; set; }
        public Decimal? CAR_PESO_EMBALAGEM { get; set; }
        public Decimal? CAR_PESO_ENTRADA { get; set; }
        public Decimal? CAR_PESO_SAIDA { get; set; }
        public string CAR_ID_DOCA { get; set; }
        public string VEI_PLACA { get; set; }
        public int? TIP_ID { get; set; }
        public string TRA_ID { get; set; }
        public Decimal? CAR_GRUPO_PRODUTIVO { get; set; }
        public string ROT_ID { get; set; }
        public string CAR_OBSERVACAO_DE_TRANSPORTE { get; set; }
        public string CAR_JUSTIFICATIVA_DE_CARREGAMENTO { get; set; }
        public string OCO_ID { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public string CAR_ID_JUNTADA { get; set; }
        public string CAR_OBSERVACAO_OTIMIZADOR { get; set; }
        public string CAR_ID_INTEGRACAO_BALANCA { get; set; }
        public string CAR_PESAGEM_LIBERADA { get; set; }
        public string CAR_OBS_LIERACAO { get; set; }
        public string OCO_ID_LIERACAO { get; set; }
        public DateTime? CAR_DATA_ENTRADA_VEICULO { get; set; }
        public DateTime? CAR_DATA_SAIDA_VEICULO { get; set; }
        public DateTime? CAR_DATA_ROMANEIO_CONSOLIDADO { get; set; }
        public string CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO { get; set; }
        public Decimal? CAR_DIFERENCA_PESAGEM { get; set; }
        public DateTime? CAR_DATA_AGENCIAMENTO { get; set; }
        public string TURN_ID { get; set; }
        public string TURM_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Carga> Query() => new MyApp.QueryBuilder.Query<Carga>();
    }

    public class CargaPrevista
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public string ORD_ID { get; set; }
        public Decimal ITC_QTD_PLANEJADA { get; set; }
        public DateTime? CAR_PREVISAO_MATERIA_PRIMA { get; set; }
        public DateTime? CAR_DATA_INICIO_PREVISTO { get; set; }
        public DateTime? CAR_DATA_INICIO_REALIZADO { get; set; }
        public DateTime? CAR_DATA_FIM_PREVISTO { get; set; }
        public DateTime? CAR_DATA_FIM_REALIZADO { get; set; }
        public DateTime? CAR_INICIO_JANELA_EMBARQUE { get; set; }
        public DateTime? CAR_FIM_JANELA_EMBARQUE { get; set; }
        public DateTime? CAR_EMBARQUE_ALVO { get; set; }
        public Decimal? CAR_STATUS { get; set; }
        public Decimal? CAR_PESO_TEORICO { get; set; }
        public Decimal? CAR_VOLUME_TEORICO { get; set; }
        public Decimal? CAR_PESO_REAL { get; set; }
        public Decimal? CAR_VOLUME_REAL { get; set; }
        public Decimal? CAR_PESO_EMBALAGEM { get; set; }
        public Decimal? CAR_PESO_ENTRADA { get; set; }
        public Decimal? CAR_PESO_SAIDA { get; set; }
        public string CAR_ID_DOCA { get; set; }
        public string VEI_PLACA { get; set; }
        public int? TIP_ID { get; set; }
        public string TRA_ID { get; set; }
        public Decimal? CAR_GRUPO_PRODUTIVO { get; set; }
        public string ROT_ID { get; set; }
        public string CAR_OBSERVACAO_DE_TRANSPORTE { get; set; }
        public string CAR_JUSTIFICATIVA_DE_CARREGAMENTO { get; set; }
        public string OCO_ID { get; set; }
        public string CAR_ID_JUNTADA { get; set; }
        public string CAR_OBSERVACAO_OTIMIZADOR { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CargaPrevista> Query() => new MyApp.QueryBuilder.Query<CargaPrevista>();
    }

    public class Cargos
    {
        public int? Id { get; set; }
        public string RGO_ID { get; set; }
        public string RGO_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Cargos> Query() => new MyApp.QueryBuilder.Query<Cargos>();
    }

    public class Cliente
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
        public Municipio Municipio { get; set; }
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
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Cliente> Query() => new MyApp.QueryBuilder.Query<Cliente>();
    }

    public class ClpMedicoes
    {
        public int? Id { get; set; }
        public int Id2 { get; set; }
        public string MaquinaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime? Emissao { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal? Grupo { get; set; }
        public int? Status { get; set; }
        public string TurnoId { get; set; }
        public string TurmaId { get; set; }
        public int IdLoteClp { get; set; }
        public string OcorrenciaId { get; set; }
        public int? Fase { get; set; }
        public string ClpOrigem { get; set; }
        public int? CLP_LOTE { get; set; }
        public int? COMPACTA { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ClpMedicoes> Query() => new MyApp.QueryBuilder.Query<ClpMedicoes>();
    }

    public class ClpMedicoesH
    {
        public int ID { get; set; }
        public string MAQUINA_ID { get; set; }
        public DateTime DATA_INI { get; set; }
        public DateTime DATA_FIM { get; set; }
        public DateTime? CLP_EMISSAO { get; set; }
        public Decimal QTD { get; set; }
        public Decimal? GRUPO { get; set; }
        public int? STATUS { get; set; }
        public string URN_ID { get; set; }
        public string URM_ID { get; set; }
        public int ID_LOTE_CLP { get; set; }
        public string OCO_ID { get; set; }
        public int? FASE { get; set; }
        public string CLP_ORIGEM { get; set; }
        public int? CLP_LOTE { get; set; }
        public int? COMPACTA { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ClpMedicoesH> Query() => new MyApp.QueryBuilder.Query<ClpMedicoesH>();
    }

    public class Colaborador
    {
        public string COL_CPF { get; set; }
        public string COL_NOME { get; set; }
        public DateTime COL_NASCIMENTO { get; set; }
        public string COL_EMAIL { get; set; }
        public string COL_MATRICULA { get; set; }
        public string TURM_id { get; set; }
        public Turma Turma { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Colaborador> Query() => new MyApp.QueryBuilder.Query<Colaborador>();
    }

    public class Compensacao
    {
        public int? Id { get; set; }
        public int COM_ID { get; set; }
        public string GRP_ID { get; set; }
        public GrupoProdutoAbstrato GrupoProdutoAbstrato { get; set; }
        public string OND_ID { get; set; }
        public Onda Onda { get; set; }
        public int? COM_VINCO1_OND { get; set; }
        public int? COM_VINCO2_OND { get; set; }
        public int? COM_VINCO3_OND { get; set; }
        public int? COM_VINCO4_OND { get; set; }
        public int? COM_VINCO5_OND { get; set; }
        public int? COM_VINCO6_OND { get; set; }
        public int? COM_VINCO7_OND { get; set; }
        public int? COM_VINCO8_OND { get; set; }
        public int? COM_VINCO9_OND { get; set; }
        public int? COM_VINCO10_OND { get; set; }
        public int? COM_VINCO1_CONVERSAO { get; set; }
        public int? COM_VINCO2_CONVERSAO { get; set; }
        public int? COM_VINCO3_CONVERSAO { get; set; }
        public int? COM_VINCO4_CONVERSAO { get; set; }
        public int? COM_VINCO5_CONVERSAO { get; set; }
        public int? COM_VINCO6_CONVERSAO { get; set; }
        public int? COM_VINCO7_CONVERSAO { get; set; }
        public int? COM_VINCO8_CONVERSAO { get; set; }
        public int? COM_VINCO9_CONVERSAO { get; set; }
        public int? COM_VINCO10_CONVERSAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Compensacao> Query() => new MyApp.QueryBuilder.Query<Compensacao>();
    }

    public class CondicaoPagamento
    {
        public int? Id { get; set; }
        public string CON_ID { get; set; }
        public string CON_DESCRICAO { get; set; }
        public int? CON_PARCELAS { get; set; }
        public Decimal? CON_VALOR_ACRECIMO { get; set; }
        public string CON_INTEGRACAO_ERP { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CondicaoPagamento> Query() => new MyApp.QueryBuilder.Query<CondicaoPagamento>();
    }

    public class Configuracoes
    {
        public int CON_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Configuracoes> Query() => new MyApp.QueryBuilder.Query<Configuracoes>();
    }

    public class Consultas
    {
        public int? Id { get; set; }
        public string CON_CASAS_DECIMAIS { get; set; }
        public string CON_CONEXAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Consultas> Query() => new MyApp.QueryBuilder.Query<Consultas>();
    }

    public class ConsultasGrupos
    {
        public int? Id { get; set; }
        public int? CON_ID { get; set; }
        public int? GRU_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ConsultasGrupos> Query() => new MyApp.QueryBuilder.Query<ConsultasGrupos>();
    }

    public class ConsultasIndicadores
    {
        public int? Id { get; set; }
        public int? CON_ID { get; set; }
        public int? IND_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ConsultasIndicadores> Query() => new MyApp.QueryBuilder.Query<ConsultasIndicadores>();
    }

    public class CorConfiguracaoGrafico
    {
        public string COR_ID { get; set; }
        public Decimal COR_PERCENTUAL_INI { get; set; }
        public Decimal COR_PERCENTUAL_FIM { get; set; }
        public string COR_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CorConfiguracaoGrafico> Query() => new MyApp.QueryBuilder.Query<CorConfiguracaoGrafico>();
    }

    public class CorridasOnduladeira
    {
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public Decimal? PRO_LARGURA_PECA { get; set; }
        public Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
        public string PRO_VINCOS_RECALCULADOS { get; set; }
        public string COR_SOLVER { get; set; }
        public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_TOLERANCIA_MENOS { get; set; }
        public Decimal? COR_TOLERANCIA_MAIS { get; set; }
        public int? COR_PILHAS_POR_PALETE { get; set; }
        public string COR_COR_FILA { get; set; }
        public Decimal? COR_M_LINEAR_REALIZADO { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string COR_STATUS_PALETE { get; set; }
        public Decimal? COR_GRUPO_PRODUTIVO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public int COR_ID { get; set; }
        public string COR_STATUS { get; set; }
        public string COR_STATUS_INTERFACE { get; set; }
        public string MAQ_ID { get; set; }
        public int? COR_ID_INTERFACE { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? COR_SEQUENCIA_ORIGEM { get; set; }
        public string ORD_ID { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? COR_FACAO { get; set; }
        public int? COR_FORMATO_BOBINA { get; set; }
        public DateTime? COR_INICIO_PREVISTO { get; set; }
        public DateTime? COR_FIM_PREVISTO { get; set; }
        public string PRO_ID { get; set; }
        public int? COR_QTD_PLANEJADO { get; set; }
        public int? PRO_QTD_PACAS { get; set; }
        public int? COR_PECAS_LARGURA { get; set; }

        public static MyApp.QueryBuilder.Query<CorridasOnduladeira> Query() => new MyApp.QueryBuilder.Query<CorridasOnduladeira>();
    }

    public class CorridasOnduladeiraEstudo
    {
        public int? Id { get; set; }
        public string BOL_ID { get; set; }
        public string BOL_ID_ORIGEM { get; set; }
        public Decimal? PRO_LARGURA_PECA { get; set; }
        public Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
        public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
        public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
        public string PRO_VINCOS_RECALCULADOS { get; set; }
        public string COR_SOLVER { get; set; }
        public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
        public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
        public Decimal? COR_TOLERANCIA_MENOS { get; set; }
        public Decimal? COR_TOLERANCIA_MAIS { get; set; }
        public int? COR_PILHAS_POR_PALETE { get; set; }
        public Decimal? COR_M_LINEAR_REALIZADO { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string COR_STATUS_PALETE { get; set; }
        public Decimal? COR_GRUPO_PRODUTIVO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CorridasOnduladeiraEstudo> Query() => new MyApp.QueryBuilder.Query<CorridasOnduladeiraEstudo>();
    }

    public class Cotas
    {
        public int? Id { get; set; }
        public int COT_ID { get; set; }
        public DateTime? COT_DATA_DE { get; set; }
        public DateTime? COT_DATA_ATE { get; set; }
        public Decimal? COT_VALOR { get; set; }
        public Decimal? COT_OCUPADO { get; set; }
        public int REP_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Cotas> Query() => new MyApp.QueryBuilder.Query<Cotas>();
    }

    public class T_Departamentos
    {
        public int DEP_ID { get; set; }
        public string DEP_NOME { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Departamentos> Query() => new MyApp.QueryBuilder.Query<T_Departamentos>();
    }

    public class Enderecos
    {
        public string END_ID { get; set; }
        public string END_GRUPO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Enderecos> Query() => new MyApp.QueryBuilder.Query<Enderecos>();
    }

    public class Equipe
    {
        public int? Id { get; set; }
        public string EQU_ID { get; set; }
        public Decimal? EQU_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Equipe> Query() => new MyApp.QueryBuilder.Query<Equipe>();
    }

    public class Estradas
    {
        public int? Id { get; set; }
        public int EST_ID { get; set; }
        public string EST_DESCRICAO { get; set; }
        public int? EST_ID_LIGACAO_PONTO_A { get; set; }
        public int? EST_ID_LIGACAO_PONTO_B { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Estradas> Query() => new MyApp.QueryBuilder.Query<Estradas>();
    }

    public class EstruturaCusto
    {
        public int EST_ID { get; set; }
        public int? ITO_ID { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public string PRO_ID { get; set; }
        public string PRO_ID_PRODUTO { get; set; }
        public string PRO_ID_COMPONENTE { get; set; }
        public string PRO_TIPO_CUSTO { get; set; }
        public string PRO_GRUPO_CONTABIL { get; set; }
        public int EST_ORDEM { get; set; }
        public string EST_GRUPO { get; set; }
        public Decimal EST_QUANT { get; set; }
        public Decimal EST_VALOR_TOTAL { get; set; }
        public string EST_DATA_BASE { get; set; }
        public Decimal EST_BASE_PRODUCAO { get; set; }
        public Decimal? EST_NIVEL { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<EstruturaCusto> Query() => new MyApp.QueryBuilder.Query<EstruturaCusto>();
    }

    public class EstruturaImpressao
    {
        public int EST_ID { get; set; }
        public string HTML_ESTRUTURA { get; set; }
        public string CLI_ID { get; set; }
        public Cliente Cliente { get; set; }
        public string EST_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<EstruturaImpressao> Query() => new MyApp.QueryBuilder.Query<EstruturaImpressao>();
    }

    public class EstruturaProduto
    {
        public int? Id { get; set; }
        public DateTime EST_DATA_VALIDADE { get; set; }
        public string PRO_ID_PRODUTO { get; set; }
        public string PRO_ID_COMPONENTE { get; set; }
        public Decimal EST_QUANT { get; set; }
        public DateTime EST_DATA_INCLUSAO { get; set; }
        public Decimal EST_BASE_PRODUCAO { get; set; }
        public string EST_TIPO_REQUISICAO { get; set; }
        public string EST_CODIGO_DE_EXCECAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<EstruturaProduto> Query() => new MyApp.QueryBuilder.Query<EstruturaProduto>();
    }

    public class Etiqueta
    {
        public int ETI_ID { get; set; }
        public DateTime? ETI_EMISSAO { get; set; }
        public string ETI_CODIGO_BARRAS { get; set; }
        public int? ETI_SEQUENCIA { get; set; }
        public int? ETI_NUMERO_COPIAS { get; set; }
        public string ETI_STATUS { get; set; }
        public DateTime? ETI_DATA_FABRICACAO { get; set; }
        public string ETI_COD_BARRAS_ORIGINAL { get; set; }
        public string ETI_OP_ORIGINAL { get; set; }
        public string MAQ_ID { get; set; }
        public int? IMP_ID { get; set; }
        public int? USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public string ROT_PRO_ID { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public Decimal? ETI_QUANTIDADE_PALETE { get; set; }
        public string ETI_LOTE { get; set; }
        public string ETI_SUB_LOTE { get; set; }
        public int? ETI_IMPRIMIR_DE { get; set; }
        public int? ETI_IMPRIMIR_ATE { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Etiqueta> Query() => new MyApp.QueryBuilder.Query<Etiqueta>();
    }

    public class T_Favoritos
    {
        public int IDFAVORITO { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public int ID_INDICADOR { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Favoritos> Query() => new MyApp.QueryBuilder.Query<T_Favoritos>();
    }

    public class FechamentoTeste
    {
        public int? Id { get; set; }
        public int FEC_ID { get; set; }
        public int? FEC_QTD { get; set; }
        public string GRP_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<FechamentoTeste> Query() => new MyApp.QueryBuilder.Query<FechamentoTeste>();
    }

    public class Feedback
    {
        public int Id { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime Datafinal { get; set; }
        public string MaquinaId { get; set; }
        public string OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public string TurnoId { get; set; }
        public Turno Turno { get; set; }
        public string TurmaId { get; set; }
        public Turma Turma { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string OrderId { get; set; }
        public string ProdutoId { get; set; }
        public string Observacoes { get; set; }
        public Decimal Grupo { get; set; }
        public string DiaTurma { get; set; }
        public int? SequenciaTransformacao { get; set; }
        public int? SequenciaRepeticao { get; set; }
        public Decimal QuantidadePulsos { get; set; }
        public Decimal? QuantidadePecasPorPulso { get; set; }
        public Decimal? FEE_QTD_TOTAL_PRODUCAO_AJUSTADA { get; set; }
        public string BOL_ID { get; set; }
        public int? COR_SEQUENCIA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Feedback> Query() => new MyApp.QueryBuilder.Query<Feedback>();
    }

    public class T_FeedbackMovEstoque
    {
        public int? Id { get; set; }
        public int FeedbackId { get; set; }
        public Feedback Feedback { get; set; }
        public int MovimentoEstoqueId { get; set; }
        public MovimentoEstoque MovimentoEstoque { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_FeedbackMovEstoque> Query() => new MyApp.QueryBuilder.Query<T_FeedbackMovEstoque>();
    }

    public class FilaProducao
    {
        public int? Id { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public string ROT_PRO_ID { get; set; }
        public Decimal FPR_QUANTIDADE_PREVISTA { get; set; }
        public string ROT_MAQ_ID { get; set; }
        public DateTime FPR_DATA_INICIO_PREVISTA { get; set; }
        public DateTime FPR_DATA_FIM_PREVISTA { get; set; }
        public DateTime FPR_DATA_FIM_MAXIMA { get; set; }
        public int ROT_SEQ_TRANFORMACAO { get; set; }
        public int FPR_SEQ_REPETICAO { get; set; }
        public string FPR_OBS_PRODUCAO { get; set; }
        public string FPR_STATUS { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_SETUP { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_SETUPA { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_PERFORMANC { get; set; }
        public Decimal? FPR_TEMPO_DECO_PEQUENA_PARADA { get; set; }
        public Decimal? FPR_QTD_PERFORMANCE { get; set; }
        public Decimal? FPR_QTD_SETUP { get; set; }
        public Decimal? FPR_QTD_PRODUZIDA { get; set; }
        public Decimal? FPR_TEMPO_TEORICO_PERFORMANCE { get; set; }
        public Decimal? FPR_TEMPO_RESTANTE_PERFORMANC { get; set; }
        public Decimal? FPR_VELOCIDADE_P_ATINGIR_META { get; set; }
        public Decimal? FPR_QTD_RESTANTE { get; set; }
        public Decimal? FPR_VELO_ATU_PC_SEGUNDO { get; set; }
        public Decimal? FPR_PERFORMANCE_PROJETADA { get; set; }
        public Decimal? FPR_TEMPO_RESTANTE_TOTAL { get; set; }
        public DateTime? FPR_FIM_PREVISTO_ATUAL { get; set; }
        public int? FPR_PRODUZINDO { get; set; }
        public Decimal? FPR_ORDEM_NA_FILA { get; set; }
        public string FPR_ID_INTEGRACAO { get; set; }
        public string FPR_TRUNCADO { get; set; }
        public DateTime? FPR_DATA_TRUNC_INI { get; set; }
        public DateTime? FPR_DATA_TRUNC_FIM { get; set; }
        public int FPR_ID { get; set; }
        public string FPR_COR_FILA { get; set; }
        public string MAQ_ID_MANUAL { get; set; }
        public string MAQ_ID_RESTRINGIDA { get; set; }
        public DateTime FPR_PREVISAO_MATERIA_PRIMA { get; set; }
        public DateTime? FPR_DATA_NECESSIDADE_INICIO_PRODUCAO { get; set; }
        public DateTime? FPR_DATA_NECESSIDADE_FIM_PRODUCAO { get; set; }
        public Decimal? FPR_GRUPO_PRODUTIVO { get; set; }
        public DateTime? FPR_INICIO_GRUPO_PRODUTIVO { get; set; }
        public DateTime? FPR_FIM_GRUPO_PRODUTIVO { get; set; }
        public string FPR_COR_BICO1 { get; set; }
        public string FPR_COR_BICO2 { get; set; }
        public string FPR_COR_BICO3 { get; set; }
        public string FPR_COR_BICO4 { get; set; }
        public string FPR_COR_BICO5 { get; set; }
        public Decimal? FPR_META_SETUP { get; set; }
        public string FPR_ORD_ID_REPROGRAMADO { get; set; }
        public int? FPR_PRIORIDADE { get; set; }
        public int? FPR_SEQ_INCLUSAO_FILA { get; set; }
        public int? FPR_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public int? FPR_ID_ORIGEM { get; set; }
        public DateTime? FPR_DATA_ENTREGA { get; set; }
        public string EQU_ID { get; set; }
        public Decimal? FPR_GRUPO_PRODUTIVO_MANUAL { get; set; }
        public DateTime? FPR_EMISSAO { get; set; }
        public string FPR_MOTIVO_PULA_FILA { get; set; }
        public string OCO_ID { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public Decimal? FPR_TOLERANCIA_MENOS { get; set; }
        public Decimal? FPR_TOLERANCIA_MAIS { get; set; }
        public DateTime? FPR_DATA_ENCERRAMENTO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<FilaProducao> Query() => new MyApp.QueryBuilder.Query<FilaProducao>();
    }

    public class FilaProducaoPrevista
    {
        public int? Id { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public Decimal FPR_QUANTIDADE_PREVISTA { get; set; }
        public string ROT_MAQ_ID { get; set; }
        public DateTime FPR_DATA_INICIO_PREVISTA { get; set; }
        public DateTime FPR_DATA_FIM_PREVISTA { get; set; }
        public DateTime FPR_DATA_FIM_MAXIMA { get; set; }
        public int ROT_SEQ_TRANFORMACAO { get; set; }
        public int FPR_SEQ_REPETICAO { get; set; }
        public string FPR_OBS_PRODUCAO { get; set; }
        public string FPR_STATUS { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_SETUP { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_SETUPA { get; set; }
        public Decimal? FPR_TEMPO_DECORRIDO_PERFORMANC { get; set; }
        public Decimal? FPR_TEMPO_DECO_PEQUENA_PARADA { get; set; }
        public Decimal? FPR_QTD_PERFORMANCE { get; set; }
        public Decimal? FPR_QTD_SETUP { get; set; }
        public Decimal? FPR_QTD_PRODUZIDA { get; set; }
        public Decimal? FPR_TEMPO_TEORICO_PERFORMANCE { get; set; }
        public Decimal? FPR_TEMPO_RESTANTE_PERFORMANC { get; set; }
        public Decimal? FPR_VELOCIDADE_P_ATINGIR_META { get; set; }
        public Decimal? FPR_QTD_RESTANTE { get; set; }
        public Decimal? FPR_VELO_ATU_PC_SEGUNDO { get; set; }
        public Decimal? FPR_PERFORMANCE_PROJETADA { get; set; }
        public Decimal? FPR_TEMPO_RESTANTE_TOTAL { get; set; }
        public DateTime? FPR_FIM_PREVISTO_ATUAL { get; set; }
        public int? FPR_PRODUZINDO { get; set; }
        public Decimal? FPR_ORDEM_NA_FILA { get; set; }
        public string FPR_ID_INTEGRACAO { get; set; }
        public string FPR_TRUNCADO { get; set; }
        public DateTime? FPR_DATA_TRUNC_INI { get; set; }
        public DateTime? FPR_DATA_TRUNC_FIM { get; set; }
        public int FPR_ID { get; set; }
        public string FPR_COR_FILA { get; set; }
        public string MAQ_ID_MANUAL { get; set; }
        public string MAQ_ID_RESTRINGIDA { get; set; }
        public DateTime FPR_PREVISAO_MATERIA_PRIMA { get; set; }
        public DateTime? FPR_DATA_NECESSIDADE_INICIO_PRODUCAO { get; set; }
        public DateTime? FPR_DATA_NECESSIDADE_FIM_PRODUCAO { get; set; }
        public Decimal? FPR_GRUPO_PRODUTIVO { get; set; }
        public DateTime? FPR_INICIO_GRUPO_PRODUTIVO { get; set; }
        public DateTime? FPR_FIM_GRUPO_PRODUTIVO { get; set; }
        public string FPR_COR_BICO1 { get; set; }
        public string FPR_COR_BICO2 { get; set; }
        public string FPR_COR_BICO3 { get; set; }
        public string FPR_COR_BICO4 { get; set; }
        public string FPR_COR_BICO5 { get; set; }
        public Decimal? FPR_META_SETUP { get; set; }
        public string FPR_ORD_ID_REPROGRAMADO { get; set; }
        public int? FPR_PRIORIDADE { get; set; }
        public int? FPR_SEQ_INCLUSAO_FILA { get; set; }
        public int? FPR_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
        public int? FPR_ID_ORIGEM { get; set; }
        public DateTime? FPR_DATA_ENTREGA { get; set; }
        public string EQU_ID { get; set; }
        public Decimal? FPR_GRUPO_PRODUTIVO_MANUAL { get; set; }
        public DateTime? FPR_EMISSAO { get; set; }
        public string FPR_MOTIVO_PULA_FILA { get; set; }
        public string OCO_ID { get; set; }
        public string FPR_PESO_UNITARIO { get; set; }
        public string FPR_M2_UNITARIO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<FilaProducaoPrevista> Query() => new MyApp.QueryBuilder.Query<FilaProducaoPrevista>();
    }

    public class T_Grupo
    {
        public int GRU_ID { get; set; }
        public string NOME { get; set; }
        public int EXIBELISTA { get; set; }
        public string GRU_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Grupo> Query() => new MyApp.QueryBuilder.Query<T_Grupo>();
    }

    public class GrupoIndicador
    {
        public int GRU_IND_ID { get; set; }
        public int GRU_ID { get; set; }
        public T_Grupo T_Grupo { get; set; }
        public int IND_ID { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoIndicador> Query() => new MyApp.QueryBuilder.Query<GrupoIndicador>();
    }

    public class GrupoProdutoAbstrato
    {
        public string GRP_ID { get; set; }
        public string GRP_DESCRICAO { get; set; }
        public int? TEM_ID { get; set; }
        public Decimal? GRP_TIPO { get; set; }
        public string GRP_PAP_ONDA { get; set; }
        public Onda Onda { get; set; }
        public Decimal? GRP_PAP_GRAMATURA { get; set; }
        public Decimal? GRP_PAP_ALTURA { get; set; }
        public string GRP_PAP_NOME_COMERCIAL { get; set; }
        public string GRP_ATIVO { get; set; }
        public DateTime? GRP_DT_CRIACAO { get; set; }
        public string GRP_PAPEL1 { get; set; }
        public string GRP_PAPEL2 { get; set; }
        public string GRP_PAPEL3 { get; set; }
        public string GRP_PAPEL4 { get; set; }
        public string GRP_PAPEL5 { get; set; }
        public string GRP_ID_INTEGRACAO { get; set; }
        public string GRP_ID_INTEGRACAO_ERP { get; set; }
        public int? GRP_TYPE { get; set; }
        public Decimal? GRP_PERFORMANCE { get; set; }
        public Decimal? GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO { get; set; }
        public string GRP_RESINA { get; set; }
        public string GRP_ENDURECEDOR_MIOLO { get; set; }
        public int VIN_ID { get; set; }
        public Vinco Vinco { get; set; }
        public Decimal? GRP_COLUNA_DE { get; set; }
        public Decimal? GRP_COLUNA_ATE { get; set; }
        public Decimal? GRP_CRUSH { get; set; }
        public string GRP_ID_FAMILIA { get; set; }
        public Decimal? GRP_REFILE_LARGURA { get; set; }
        public Decimal? GRP_REFILE_COMPRIMENTO { get; set; }
        public string GRP_TIPO_LAP { get; set; }
        public string GRP_LAP_PROLONGADO { get; set; }
        public Decimal? GRP_TAMANHO_LAP_OND_SIMPLES { get; set; }
        public Decimal? GRP_TAMANHO_LAP_OND_DUPLA { get; set; }
        public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES { get; set; }
        public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA { get; set; }
        public string GRP_FEFCO { get; set; }
        public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_DE { get; set; }
        public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE { get; set; }
        public string GRP_PREFIXO_ID_PRODUTO { get; set; }
        public Decimal? GRP_COLUNA_CAIXA { get; set; }
        public Decimal? GRP_COLUNA_CHAPA { get; set; }
        public Decimal? GRP_MULLEN { get; set; }
        public int? GRP_TENDENCIA_TOLERANCIA_PEDIDO { get; set; }
        public Decimal? GRP_PERCENTUAL_PERDA_MEDIA { get; set; }
        public int? GRP_FILTRA_SEQ_TRANS { get; set; }
        public string GRP_IMG_CAIXA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoProdutoAbstrato> Query() => new MyApp.QueryBuilder.Query<GrupoProdutoAbstrato>();
    }

    public class GrupoRecurso
    {
        public string GRE_ID { get; set; }
        public string GRE_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoRecurso> Query() => new MyApp.QueryBuilder.Query<GrupoRecurso>();
    }

    public class GrupoSegmento
    {
        public int? Id { get; set; }
        public string GRS_ID { get; set; }
        public string GRS_DESCRICAO { get; set; }
        public string GRS_INTEGRACAO_ERP { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoSegmento> Query() => new MyApp.QueryBuilder.Query<GrupoSegmento>();
    }

    public class T_HORARIO_RECEBIMENTO
    {
        public int HRE_DIA_DA_SEMANA { get; set; }
        public DateTime HRE_HORA_INICIAL { get; set; }
        public DateTime HRE_HORA_FINAL { get; set; }
        public string CLI_ID { get; set; }
        public Cliente Cliente { get; set; }
        public int HRE_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_HORARIO_RECEBIMENTO> Query() => new MyApp.QueryBuilder.Query<T_HORARIO_RECEBIMENTO>();
    }

    public class Impressora
    {
        public int IMP_ID { get; set; }
        public string IMP_IP { get; set; }
        public string IMP_NOME { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Impressora> Query() => new MyApp.QueryBuilder.Query<Impressora>();
    }

    public class T_Indicadores
    {
        public int IND_ID { get; set; }
        public string IND_DESCRICAO { get; set; }
        public int NEG_ID { get; set; }
        public T_Negocio T_Negocio { get; set; }
        public string DESC_CALCULO { get; set; }
        public int IND_TIPOCOMPARADOR { get; set; }
        public int? IND_GRAFICO { get; set; }
        public string IND_CONEXAO { get; set; }
        public DateTime? IND_DTCRIACAO { get; set; }
        public string RESPOSAVELIND { get; set; }
        public string RESPOSAVELCARGA { get; set; }
        public string PROCEXTRACAO { get; set; }
        public string PER_ID { get; set; }
        public string DIM_ID { get; set; }
        public string DOM_EMPRESA { get; set; }
        public string DOM_FILIAL { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Indicadores> Query() => new MyApp.QueryBuilder.Query<T_Indicadores>();
    }

    public class IndicadoresDepartamentos
    {
        public int INDDEP_ID { get; set; }
        public int DEP_ID { get; set; }
        public T_Departamentos T_Departamentos { get; set; }
        public int IND_ID { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<IndicadoresDepartamentos> Query() => new MyApp.QueryBuilder.Query<IndicadoresDepartamentos>();
    }

    public class IndicadoresDimencoes
    {
        public int? Id { get; set; }
        public int DIM_ID { get; set; }
        public int IND_ID { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public string DIM_DESCRICAO { get; set; }
        public string DIM_SQL { get; set; }
        public string DIM_CONEXAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<IndicadoresDimencoes> Query() => new MyApp.QueryBuilder.Query<IndicadoresDimencoes>();
    }

    public class IndicadoresFatosDimencoes
    {
        public int? Id { get; set; }
        public string FAT_ID { get; set; }
        public int IND_ID { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public int DIM_ID { get; set; }
        public string FAT_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<IndicadoresFatosDimencoes> Query() => new MyApp.QueryBuilder.Query<IndicadoresFatosDimencoes>();
    }

    public class IndicadoresPeriodosDimencoes
    {
        public int? Id { get; set; }
        public string PER_ID { get; set; }
        public int IND_ID { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public int DIM_ID { get; set; }
        public string PER_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<IndicadoresPeriodosDimencoes> Query() => new MyApp.QueryBuilder.Query<IndicadoresPeriodosDimencoes>();
    }

    public class InformacoesComplementares
    {
        public int INF_ID { get; set; }
        public string INF_DESCRICAO { get; set; }
        public Decimal INF_VALOR { get; set; }
        public int MET_ID { get; set; }
        public T_Metas T_Metas { get; set; }
        public string INF_DATA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<InformacoesComplementares> Query() => new MyApp.QueryBuilder.Query<InformacoesComplementares>();
    }

    public class InpecaoVisual
    {
        public int? Id { get; set; }
        public int IPV_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<InpecaoVisual> Query() => new MyApp.QueryBuilder.Query<InpecaoVisual>();
    }

    public class ItemInspecao
    {
        public int? Id { get; set; }
        public int ITI_ID { get; set; }
        public string ITI_DESC { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItemInspecao> Query() => new MyApp.QueryBuilder.Query<ItemInspecao>();
    }

    public class ItemTestavel
    {
        public int? Id { get; set; }
        public int ITE_ID { get; set; }
        public string ITE_DESCRICAO { get; set; }
        public string ITE_OBS { get; set; }
        public int? ITE_NUMERO_DE_TESTES { get; set; }
        public string ITE_CONDICIONAL_DE_AVALIACAO { get; set; }
        public Decimal? ITE_VALOR_DA_CONDICIONAL { get; set; }
        public string ITE_VALOR_CALCULADO_DA_CONDICIONAL { get; set; }
        public string ITE_TIPO_AVALIACAO_FINAL { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItemTestavel> Query() => new MyApp.QueryBuilder.Query<ItemTestavel>();
    }

    public class ItensCalendario
    {
        public int ICA_ID { get; set; }
        public DateTime ICA_DATA_DE { get; set; }
        public DateTime ICA_DATA_ATE { get; set; }
        public string ICA_OBSERVACAO { get; set; }
        public int ICA_TIPO { get; set; }
        public string URM_ID { get; set; }
        public Turma Turma { get; set; }
        public string URN_ID { get; set; }
        public Turno Turno { get; set; }
        public int CAL_ID { get; set; }
        public Calendario Calendario { get; set; }
        public string MAQ_ID { get; set; }
        public string PRO_ID { get; set; }
        public int? ICA_LIMPESA_MAQUINA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItensCalendario> Query() => new MyApp.QueryBuilder.Query<ItensCalendario>();
    }

    public class ItenCalendarioDisponibilidadeVeiculos
    {
        public int? Id { get; set; }
        public int? CDV_ID { get; set; }
        public int? TIP_ID { get; set; }
        public int? IDV_QTD { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItenCalendarioDisponibilidadeVeiculos> Query() => new MyApp.QueryBuilder.Query<ItenCalendarioDisponibilidadeVeiculos>();
    }

    public class ItenCarga
    {
        public int? Id { get; set; }
        public string CAR_ID { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public DateTime ITC_ENTREGA_PLANEJADA { get; set; }
        public DateTime ITC_ENTREGA_REALIZADA { get; set; }
        public int ITC_ORDEM_ENTREGA { get; set; }
        public Decimal ITC_QTD_PLANEJADA { get; set; }
        public Decimal ITC_QTD_REALIZADA { get; set; }
        public string ORD_HASH_KEY { get; set; }
        public string NOT_ID { get; set; }
        public DateTime? NOT_EMISSAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItenCarga> Query() => new MyApp.QueryBuilder.Query<ItenCarga>();
    }

    public class ItensEstruturaImpressao
    {
        public int? Id { get; set; }
        public int IES_CUSTOM_FONT_SIZE { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItensEstruturaImpressao> Query() => new MyApp.QueryBuilder.Query<ItensEstruturaImpressao>();
    }

    public class ItensOrcamento
    {
        public int? Id { get; set; }
        public int ITO_ID { get; set; }
        public int? ORC_ID { get; set; }
        public int? TIP_ID { get; set; }
        public string PRO_ID { get; set; }
        public string ITO_OBS { get; set; }
        public Decimal? ITO_QUANTIDADE { get; set; }
        public Decimal? ITO_CUSTO { get; set; }
        public Decimal? ITO_MARGEM { get; set; }
        public Decimal? ITO_VALOR_UNITARIO { get; set; }
        public DateTime? ITO_VERSSAO_CUSTO { get; set; }
        public string ITO_STATUS { get; set; }
        public Decimal? ITO_ERP_CUSTOS_FIXOS { get; set; }
        public Decimal? ITO_ERP_CUSTOS_VARIAVEIS { get; set; }
        public Decimal? ITO_ERP_DESPESAS_VAR_VENDA { get; set; }
        public Decimal? ITO_ERP_IMPOSTOS { get; set; }
        public string GRP_ID_COMPOSICAO { get; set; }
        public GrupoProdutoAbstrato GrupoProdutoAbstrato { get; set; }
        public Decimal? ITO_LARGURA { get; set; }
        public Decimal? ITO_COMPRIMENTO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItensOrcamento> Query() => new MyApp.QueryBuilder.Query<ItensOrcamento>();
    }

    public class ItensPacked
    {
        public int? Id { get; set; }
        public int IPA_ID { get; set; }
        public string CAR_ID { get; set; }
        public string PRO_ID { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public Decimal? IPA_COORDC { get; set; }
        public Decimal? IPA_COORDL { get; set; }
        public Decimal? IPA_COORDA { get; set; }
        public Decimal? IPA_DIMC { get; set; }
        public Decimal? IPA_DIML { get; set; }
        public Decimal? IPA_DIMA { get; set; }
        public Decimal? IPA_QTD_POR_PALETE { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ItensPacked> Query() => new MyApp.QueryBuilder.Query<ItensPacked>();
    }

    public class LaudoTesteFisico
    {
        public int? Id { get; set; }
        public int LTF_ID { get; set; }
        public DateTime? LTF_EMISSAO { get; set; }
        public Decimal? LTF_VALOR { get; set; }
        public string LTF_OBS { get; set; }
        public string LTF_STATUS { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? USE_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<LaudoTesteFisico> Query() => new MyApp.QueryBuilder.Query<LaudoTesteFisico>();
    }

    public class Logs
    {
        public int? Id { get; set; }
        public string LOG_CHAVE { get; set; }
        public string LOG_CONTEXTO { get; set; }
        public string LOG_CONTEUDO { get; set; }
        public int LOG_ID { get; set; }
        public DateTime? LOG_EMISSAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Logs> Query() => new MyApp.QueryBuilder.Query<Logs>();
    }

    public class LogsDatabase
    {
        public int LOGS_ID { get; set; }
        public string LOGS_TABLE { get; set; }
        public string LOGS_KEY { get; set; }
        public string LOGS_KEY1 { get; set; }
        public string LOGS_KEY2 { get; set; }
        public string LOGS_KEY3 { get; set; }
        public string LOGS_KEY4 { get; set; }
        public string LOGS_COLUMN { get; set; }
        public string LOGS_BEFORE { get; set; }
        public string LOGS_AFTER { get; set; }
        public string LOGS_ACTION { get; set; }
        public DateTime LOGS_DATE { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string LOGS_ORIGEM { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<LogsDatabase> Query() => new MyApp.QueryBuilder.Query<LogsDatabase>();
    }

    public class Loock
    {
        public int? Id { get; set; }
        public string LOO_ID { get; set; }
        public string LOO_DESCRICAO { get; set; }
        public string LOO_CONTEUDO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Loock> Query() => new MyApp.QueryBuilder.Query<Loock>();
    }

    public class LoteTeste
    {
        public int? Id { get; set; }
        public int LT_ID { get; set; }
        public int? TES_ID { get; set; }
        public int? RL_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<LoteTeste> Query() => new MyApp.QueryBuilder.Query<LoteTeste>();
    }

    public class Lotes
    {
        public int? Id { get; set; }
        public string MOV_LOTE { get; set; }
        public string MOV_SUB_LOTE { get; set; }
        public Decimal? LOT_LARGURA { get; set; }
        public Decimal? LOT_COMPRIMENTO { get; set; }
        public Decimal? LOT_DIAMETRO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Lotes> Query() => new MyApp.QueryBuilder.Query<Lotes>();
    }

    public class Mapa
    {
        public int? Id { get; set; }
        public int MAP_ID { get; set; }
        public string PON_ID { get; set; }
        public PontosMapa PontosMapa { get; set; }
        public string PON_ID_VIZINHO { get; set; }
        public Decimal MAP_DISTANCIA { get; set; }
        public Decimal? MAP_CUSTO_PEDAGIO_POR_EIXO { get; set; }
        public int? ROD_ID { get; set; }
        public Decimal? MAP_ALTURA_ROD { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Mapa> Query() => new MyApp.QueryBuilder.Query<Mapa>();
    }

    public class MaquinaGrupoMaquina
    {
        public int? Id { get; set; }
        public string GMA_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MaquinaGrupoMaquina> Query() => new MyApp.QueryBuilder.Query<MaquinaGrupoMaquina>();
    }

    public class MaquinaImpressora
    {
        public int MAQ_IMP_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int IMP_ID { get; set; }
        public Impressora Impressora { get; set; }
        public int MAI_FACAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MaquinaImpressora> Query() => new MyApp.QueryBuilder.Query<MaquinaImpressora>();
    }

    public class T_MAQUINAS_EQUIPES
    {
        public int? Id { get; set; }
        public string MAQ_ID { get; set; }
        public string EQU_ID { get; set; }
        public int? CAL_ID { get; set; }
        public string CLI_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_MAQUINAS_EQUIPES> Query() => new MyApp.QueryBuilder.Query<T_MAQUINAS_EQUIPES>();
    }

    public class T_Medicoes
    {
        public int? Id { get; set; }
        public int MED_ID { get; set; }
        public int? IND_ID { get; set; }
        public int? MET_ID { get; set; }
        public int? UNI_ID { get; set; }
        public DateTime MED_DATA { get; set; }
        public string MED_VALOR { get; set; }
        public string MED_AC_ANO { get; set; }
        public string MED_DATAMEDICAO { get; set; }
        public Decimal? MED_PONDERACAO { get; set; }
        public string DIM_ID { get; set; }
        public string DIM_DESCRICAO { get; set; }
        public string DIM_SUBDIMENSAO_ID { get; set; }
        public string DIM_SUB_DESCRICAO { get; set; }
        public string PER_ID { get; set; }
        public string PER_DESCRICAO { get; set; }
        public string FAT_ID { get; set; }
        public string FAT_DESCRICAO { get; set; }
        public string MED_SQL { get; set; }
        public string DOM_EMPRESA { get; set; }
        public string DOM_FILIAL { get; set; }
        public string MED_VALOR_DISPER { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Medicoes> Query() => new MyApp.QueryBuilder.Query<T_Medicoes>();
    }

    public class MedicoesOnduladeira
    {
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MedicoesOnduladeira> Query() => new MyApp.QueryBuilder.Query<MedicoesOnduladeira>();
    }

    public class MedidasTeste
    {
        public int? Id { get; set; }
        public int MDT_ID { get; set; }
        public string MDT_DESC { get; set; }
        public Decimal? MDT_VALOR_ESPERADO { get; set; }
        public Decimal? MDT_ENCONTRADO { get; set; }
        public string UNI_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MedidasTeste> Query() => new MyApp.QueryBuilder.Query<MedidasTeste>();
    }

    public class MemoriaDeCalculo
    {
        public int? Id { get; set; }
        public int MEM_ID { get; set; }
        public int? ORC_ID { get; set; }
        public Decimal? MEM_VALOR { get; set; }
        public string MEM_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MemoriaDeCalculo> Query() => new MyApp.QueryBuilder.Query<MemoriaDeCalculo>();
    }

    public class Mensagem
    {
        public string MEN_ID { get; set; }
        public string MEN_SEND { get; set; }
        public DateTime? MEN_EMISSION { get; set; }
        public string MEN_STATUS { get; set; }
        public string MEN_RECEIVE { get; set; }
        public string MEN_TYPE { get; set; }
        public Decimal? MEN_QTD_TRY_SEND { get; set; }
        public DateTime? MEN_DATE_TRY_SEND { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Mensagem> Query() => new MyApp.QueryBuilder.Query<Mensagem>();
    }

    public class Meses
    {
        public string MES { get; set; }
        public int fator { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Meses> Query() => new MyApp.QueryBuilder.Query<Meses>();
    }

    public class T_Metas
    {
        public int MET_ID { get; set; }
        public string MET_DTINICIO { get; set; }
        public string MET_DTFIM { get; set; }
        public string MET_ALVO { get; set; }
        public int MET_TIPOALVO { get; set; }
        public int IND_ID { get; set; }
        public T_Indicadores T_Indicadores { get; set; }
        public Decimal? MET_RANGE01 { get; set; }
        public Decimal? MET_RANGE02 { get; set; }
        public Decimal? MET_RANGE03 { get; set; }
        public int? DIM_ID { get; set; }
        public string FAT_ID { get; set; }
        public string DIM_SUBDIMENSAO_ID { get; set; }
        public string PER_ID { get; set; }
        public string DOM_EMPRESA { get; set; }
        public string DOM_FILIAL { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Metas> Query() => new MyApp.QueryBuilder.Query<T_Metas>();
    }

    public class MovimentoEstoque
    {
        public int Id { get; set; }
        public string ProdutoId { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string Tipo { get; set; }
        public TipoMovimentoEstoque TipoMovimentoEstoque { get; set; }
        public string TurnoId { get; set; }
        public Turno Turno { get; set; }
        public string TurmaId { get; set; }
        public Turma Turma { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal MOV_PESO_UNITARIO { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public DateTime? DataHoraEmissao { get; set; }
        public string DiaTurma { get; set; }
        public string Lote { get; set; }
        public string SubLote { get; set; }
        public string MaquinaId { get; set; }
        public int? USE_ID { get; set; }
        public string Observacao { get; set; }
        public string OcorrenciaId { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
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
        public Cliente Cliente { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MovimentoEstoque> Query() => new MyApp.QueryBuilder.Query<MovimentoEstoque>();
    }

    public class Municipio
    {
        public string MUN_ID { get; set; }
        public string MUN_NOME { get; set; }
        public string UF_COD { get; set; }
        public string MUN_CODIGO_IBGE { get; set; }
        public Decimal? MUN_LATITUDE { get; set; }
        public Decimal? MUN_LONGITUDE { get; set; }
        public string MUN_ID_INTEGRACAO_ERP { get; set; }
        public string MUN_CODIGO_SIAFI { get; set; }
        public string MUN_CODIGO_CNPJ { get; set; }
        public Decimal? MUN_DISTANCIA_KM { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Municipio> Query() => new MyApp.QueryBuilder.Query<Municipio>();
    }

    public class T_Negocio
    {
        public int NEG_ID { get; set; }
        public string NEG_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_Negocio> Query() => new MyApp.QueryBuilder.Query<T_Negocio>();
    }

    public class ObjetoControlavel
    {
        public int? Id { get; set; }
        public string OBJ_ID { get; set; }
        public string OBJ_DESCRICAO { get; set; }
        public string OBJ_TIPO { get; set; }
        public string OBJ_GRUPO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ObjetoControlavel> Query() => new MyApp.QueryBuilder.Query<ObjetoControlavel>();
    }

    public class Observacoes
    {
        public int OBS_ID { get; set; }
        public string OBS_TIPO { get; set; }
        public string OBS_DESCRICAO { get; set; }
        public string CLI_ID { get; set; }
        public Cliente Cliente { get; set; }
        public string MAQ_ID { get; set; }
        public string PRO_ID { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public string OBS_INTEGRACAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Observacoes> Query() => new MyApp.QueryBuilder.Query<Observacoes>();
    }

    public class Ocorrencia
    {
        public string OCO_ID { get; set; }
        public string OCO_DESCRICAO { get; set; }
        public int TIP_ID { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; }
        public string GMA_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? SPR { get; set; }
        public string OCO_SUB_TIPO { get; set; }
        public string SUB_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Ocorrencia> Query() => new MyApp.QueryBuilder.Query<Ocorrencia>();
    }

    public class Onda
    {
        public string OND_ID { get; set; }
        public Decimal OND_ESPESSURA { get; set; }
        public Decimal? OND_PESO_COLA { get; set; }
        public Decimal? OND_RENDIMENTO_ONDA_1 { get; set; }
        public Decimal? OND_RENDIMENTO_ONDA_2 { get; set; }
        public int? OND_PROFUNDIDADE_VINCO { get; set; }
        public string OND_ID_INTEGRACAO { get; set; }
        public int VIN_ID { get; set; }
        public Vinco Vinco { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Onda> Query() => new MyApp.QueryBuilder.Query<Onda>();
    }

    public class Operacoes
    {
        public int? Id { get; set; }
        public string OPE_TIPO_REGISTRO { get; set; }
        public string OPE_ID { get; set; }
        public string GMA_ID { get; set; }
        public string MAQ_ID { get; set; }
        public string PRO_ID { get; set; }
        public string OPE_EXCECAO { get; set; }
        public int ROT_SEQ_TRANFORMACAO { get; set; }
        public string ORD_ID { get; set; }
        public int FPR_SEQ_REPETICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Operacoes> Query() => new MyApp.QueryBuilder.Query<Operacoes>();
    }

    public class OptAlteracaoDimencoes
    {
        public int? Id { get; set; }
        public int OAD_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<OptAlteracaoDimencoes> Query() => new MyApp.QueryBuilder.Query<OptAlteracaoDimencoes>();
    }

    public class Orcamento
    {
        public int? Id { get; set; }
        public int ORC_ID { get; set; }
        public string REP_ID { get; set; }
        public string CON_ID { get; set; }
        public string ORC_TIPO_FRETE { get; set; }
        public DateTime? ORC_EMISSAO { get; set; }
        public string CLI_ID { get; set; }
        public Cliente Cliente { get; set; }
        public int VER_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Orcamento> Query() => new MyApp.QueryBuilder.Query<Orcamento>();
    }

    public class OrderTrack
    {
        public int? Id { get; set; }
        public int OTK_ID { get; set; }
        public Decimal OTK_SEQUENCIA { get; set; }
        public int OTK_VERSSAO { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public string OTK_EVENTO { get; set; }
        public DateTime? OTK_DATA_NECESSIDADE_DE { get; set; }
        public DateTime? OTK_DATA_NECESSIDADE_ATE { get; set; }
        public DateTime? OTK_DATA_PREVISTA { get; set; }
        public DateTime? OTK_DATA_REALIZADA { get; set; }
        public int? FPR_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<OrderTrack> Query() => new MyApp.QueryBuilder.Query<OrderTrack>();
    }

    public class Order
    {
        public string ORD_ID { get; set; }
        public string ORD_ID_RESERVA { get; set; }
        public string ORD_ID_CONJUNTO { get; set; }
        public string PRO_ID { get; set; }
        public string PRO_ID_CONJUNTO { get; set; }
        public string CLI_ID { get; set; }
        public Cliente Cliente { get; set; }
        public Decimal? ORD_PRECO_UNITARIO { get; set; }
        public Decimal ORD_QUANTIDADE { get; set; }
        public DateTime ORD_DATA_ENTREGA_DE { get; set; }
        public DateTime ORD_DATA_ENTREGA_ATE { get; set; }
        public int? ORD_TIPO { get; set; }
        public Decimal? ORD_TOLERANCIA_MAIS { get; set; }
        public Decimal? ORD_TOLERANCIA_MENOS { get; set; }
        public string HASH_KEY { get; set; }
        public DateTime? ORD_INICIO_JANELA_EMBARQUE { get; set; }
        public DateTime? ORD_FIM_JANELA_EMBARQUE { get; set; }
        public DateTime? ORD_EMBARQUE_ALVO { get; set; }
        public DateTime? ORD_INICIO_GRUPO_PRODUTIVO { get; set; }
        public DateTime? ORD_FIM_GRUPO_PRODUTIVO { get; set; }
        public Decimal? ORD_PESO_UNITARIO { get; set; }
        public Decimal? ORD_PESO_UNITARIO_BRUTO { get; set; }
        public Decimal? ORD_M2_UNITARIO { get; set; }
        public string ORD_MIT { get; set; }
        public string CAR_TIPO_CARREGAMENTO { get; set; }
        public string ORD_STATUS { get; set; }
        public string ORD_TIPO_FRETE { get; set; }
        public string ORD_ENDERECO_ENTREGA { get; set; }
        public string ORD_BAIRRO_ENTREGA { get; set; }
        public string UF_ID_ENTREGA { get; set; }
        public string ORD_CEP_ENTREGA { get; set; }
        public string MUN_ID_ENTREGA { get; set; }
        public Municipio Municipio { get; set; }
        public string ORD_REGIAO_ENTREGA { get; set; }
        public PontosMapa PontosMapa { get; set; }
        public Decimal? ORD_LARGURA { get; set; }
        public Decimal? ORD_COMPRIMENTO { get; set; }
        public Decimal? ORD_GRAMATURA { get; set; }
        public string GRP_ID { get; set; }
        public string ORD_ID_INTEGRACAO { get; set; }
        public string ORD_OBSERVACAO_OTIMIZADOR { get; set; }
        public string ORD_COR_FILA { get; set; }
        public string ORD_PED_CLI { get; set; }
        public string ORD_OP_INTEGRACAO { get; set; }
        public string ORD_LOTE_PILOTO { get; set; }
        public int? ORD_PRIORIDADE { get; set; }
        public DateTime? ORD_EMISSAO { get; set; }
        public string REP_ID { get; set; }
        public string ORD_RESINA { get; set; }
        public string ORD_ENDURECEDOR_MIOLO { get; set; }
        public string PRO_ID_INTEGRACAO_ERP { get; set; }
        public string ORD_VINCOS_ONDULADEIRA { get; set; }
        public Decimal? ORD_ERP_CUSTOS_FIXOS { get; set; }
        public Decimal? ORD_ERP_CUSTOS_VARIAVEIS { get; set; }
        public Decimal? ORD_ERP_DESPESAS_VAR_VENDA { get; set; }
        public Decimal? ORD_ERP_IMPOSTOS { get; set; }
        public string ORD_STATUS_PLANEJAMENTO { get; set; }
        public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_DE { get; set; }
        public int? ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE { get; set; }
        public Decimal? ORD_PROMOVE_DE { get; set; }
        public Decimal? ORD_PROMOVE_ATE { get; set; }
        public string ORD_TRAVA_COMPOSICAO { get; set; }
        public string ORD_TRAVA_RESINA { get; set; }
        public string ORD_PROMOVE_RESINA { get; set; }
        public Decimal? ORD_LATITUDE_ENTREGA { get; set; }
        public Decimal? ORD_LONGITUDE_ENTREGA { get; set; }
        public string OCO_ID_CANCELAMENTO { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public string TMP_TIPO_CARGA { get; set; }
        public string PRO_ID_PALETE { get; set; }
        public string PRO_ID_TAMPO { get; set; }
        public int? ORD_PILHAS_POR_PALETE { get; set; }
        public int? ORD_CHAPAS_POR_PILHA { get; set; }
        public DateTime? ORD_DATA_CANCELAMENTO { get; set; }
        public string ORD_STATUS_ESTATISTICA { get; set; }
        public DateTime? ORD_DATA_ESTATISTICA { get; set; }
        public string OCO_ID_MOTIVO_ATRASO { get; set; }
        public int? OTK_VERSSAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Order> Query() => new MyApp.QueryBuilder.Query<Order>();
    }

    public class Param
    {
        public string PAR_ID { get; set; }
        public string PAR_DESCRICAO { get; set; }
        public string PAR_VALOR_S { get; set; }
        public Decimal PAR_VALOR_N { get; set; }
        public DateTime PAR_VALOR_D { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Param> Query() => new MyApp.QueryBuilder.Query<Param>();
    }

    public class ParametrosDeCusto
    {
        public int? Id { get; set; }
        public int PAR_ID { get; set; }
        public string PRO_ID { get; set; }
        public string CUS_ID { get; set; }
        public string PAR_VALOR { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ParametrosDeCusto> Query() => new MyApp.QueryBuilder.Query<ParametrosDeCusto>();
    }

    public class PendenciasInterface
    {
        public string PEN_STATUS_OUT { get; set; }
        public string PEN_PROTOCOLO_OUT { get; set; }
        public string PEN_ID_PROTOCOLO_OUT { get; set; }
        public string PEN_STATUS_IN { get; set; }
        public string PEN_PROTOCOLO_IN { get; set; }
        public string PEN_ID_PROTOCOLO_IN { get; set; }
        public DateTime DATA_ENTRADA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public int PEN_ID { get; set; }

        public static MyApp.QueryBuilder.Query<PendenciasInterface> Query() => new MyApp.QueryBuilder.Query<PendenciasInterface>();
    }

    public class Perfil
    {
        public int PER_ID { get; set; }
        public string PER_NOME { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Perfil> Query() => new MyApp.QueryBuilder.Query<Perfil>();
    }

    public class PerfilObjetoControlavel
    {
        public int? Id { get; set; }
        public int PER_ID { get; set; }
        public Perfil Perfil { get; set; }
        public string OBJ_ID { get; set; }
        public string PEO_ACAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<PerfilObjetoControlavel> Query() => new MyApp.QueryBuilder.Query<PerfilObjetoControlavel>();
    }

    public class PeriodicidadeTeste
    {
        public int? Id { get; set; }
        public int PER_ID { get; set; }
        public string PER_QTD { get; set; }
        public string UNI_ID { get; set; }
        public string GRP_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<PeriodicidadeTeste> Query() => new MyApp.QueryBuilder.Query<PeriodicidadeTeste>();
    }

    public class PlanoAmostralTeste
    {
        public Decimal? GRP_TIPO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public int PAT_ID { get; set; }
        public int? PAT_QTD_CAIXAS_DE { get; set; }
        public int? PAT_QTD_CAIXAS_ATE { get; set; }
        public int? PAT_N_AMOSTRAGEM { get; set; }
        public Decimal? PAT_PERCENT_ESPECIF { get; set; }

        public static MyApp.QueryBuilder.Query<PlanoAmostralTeste> Query() => new MyApp.QueryBuilder.Query<PlanoAmostralTeste>();
    }

    public class Planoacao
    {
        public int PLA_ID { get; set; }
        public string PLA_DESCRICAO { get; set; }
        public int? MET_ID { get; set; }
        public T_Metas T_Metas { get; set; }
        public string PLA_STATUS { get; set; }
        public DateTime? PLA_DATA { get; set; }
        public string PLA_METAPERIODO { get; set; }
        public string PLA_VLRPERIODO { get; set; }
        public string PLA_METACULADO { get; set; }
        public string PLA_VLRACUMULADO { get; set; }
        public string PLA_REFERENCIA { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Planoacao> Query() => new MyApp.QueryBuilder.Query<Planoacao>();
    }

    public class Plotagem
    {
        public int? Id { get; set; }
        public int PLO_ID { get; set; }
        public string PLO_NOME { get; set; }
        public string PLO_DIMENSAO { get; set; }
        public string PLO_X { get; set; }
        public string PLO_Y { get; set; }
        public string PLO_Z { get; set; }
        public string PLO_GRAFICO { get; set; }
        public int? CON_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Plotagem> Query() => new MyApp.QueryBuilder.Query<Plotagem>();
    }

    public class PoliticaOnduladeira
    {
        public int? Id { get; set; }
        public int POL_ID { get; set; }
        public int? POL_NIVEL { get; set; }
        public int? POL_PROMOCAO { get; set; }
        public int? POL_DIAS_ANTECIPACAO { get; set; }
        public int? POL_METROS_LINEARES { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<PoliticaOnduladeira> Query() => new MyApp.QueryBuilder.Query<PoliticaOnduladeira>();
    }

    public class PontosMapa
    {
        public string PON_ID { get; set; }
        public string PON_DESCRICAO { get; set; }
        public string PON_TIPO { get; set; }
        public Decimal? PON_LATITUDE { get; set; }
        public Decimal? PON_LONGITUDE { get; set; }
        public Decimal? PON_DISTANCIA_KM { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<PontosMapa> Query() => new MyApp.QueryBuilder.Query<PontosMapa>();
    }

    public class T_PREFERENCIAS
    {
        public int? Id { get; set; }
        public int PRE_ID { get; set; }
        public string PRE_DESCRICAO { get; set; }
        public string PRE_NAMESPACE { get; set; }
        public string PRE_TIPO { get; set; }
        public string PRE_VALOR { get; set; }
        public int? USE_ID { get; set; }
        public int? PER_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_PREFERENCIAS> Query() => new MyApp.QueryBuilder.Query<T_PREFERENCIAS>();
    }

    public class ProtocoloOnduladeira
    {
        public int? Id { get; set; }
        public string PTO_ID { get; set; }
        public string PTO_CHAVE { get; set; }
        public string MAQ_ID { get; set; }
        public string PTO_COMANDO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ProtocoloOnduladeira> Query() => new MyApp.QueryBuilder.Query<ProtocoloOnduladeira>();
    }

    public class Recursos
    {
        public string REC_ID { get; set; }
        public string REC_DESCRICAO { get; set; }
        public int? CAL_ID { get; set; }
        public Calendario Calendario { get; set; }
        public string REC_CONTROL_IP { get; set; }
        public string GRE_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Recursos> Query() => new MyApp.QueryBuilder.Query<Recursos>();
    }

    public class RegistrosOnduladeira
    {
        public int? Id { get; set; }
        public int REG_ID { get; set; }
        public string REG_RESPOSTA { get; set; }
        public string REG_STATUS { get; set; }
        public DateTime REG_DATA_INICIO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<RegistrosOnduladeira> Query() => new MyApp.QueryBuilder.Query<RegistrosOnduladeira>();
    }

    public class Representantes
    {
        public int? Id { get; set; }
        public int REP_ID { get; set; }
        public string REP_NOME { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Representantes> Query() => new MyApp.QueryBuilder.Query<Representantes>();
    }

    public class RespInspVisual
    {
        public int? Id { get; set; }
        public int RIV_ID { get; set; }
        public int? IPV_ID { get; set; }
        public int? ITI_ID { get; set; }
        public string RIV_STATUS { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<RespInspVisual> Query() => new MyApp.QueryBuilder.Query<RespInspVisual>();
    }

    public class RestricoesDeRodagem
    {
        public int? Id { get; set; }
        public int RES_ID { get; set; }
        public string RES_TIPO { get; set; }
        public string RES_HORA_INI { get; set; }
        public string RES_HORA_FIM { get; set; }
        public Decimal? RES_VELOCIDADE_HORA_RUSH { get; set; }
        public int? TVE_ID { get; set; }
        public int? MAP_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<RestricoesDeRodagem> Query() => new MyApp.QueryBuilder.Query<RestricoesDeRodagem>();
    }

    public class ResultLote
    {
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ResultLote> Query() => new MyApp.QueryBuilder.Query<ResultLote>();
    }

    public class ResultMedida
    {
        public int? Id { get; set; }
        public int RSM_ID { get; set; }
        public int? RL_ID { get; set; }
        public int? MDT_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ResultMedida> Query() => new MyApp.QueryBuilder.Query<ResultMedida>();
    }

    public class Rodovias
    {
        public int? Id { get; set; }
        public int ROD_ID { get; set; }
        public string ROD_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Rodovias> Query() => new MyApp.QueryBuilder.Query<Rodovias>();
    }

    public class RotaRealizada
    {
        public int ROT_ID { get; set; }
        public string CAR_ID { get; set; }
        public DateTime? ROT_DATA_HORA { get; set; }
        public Decimal? ROT_LAT { get; set; }
        public Decimal? ROT_LONG { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<RotaRealizada> Query() => new MyApp.QueryBuilder.Query<RotaRealizada>();
    }

    public class RotaPontosMapa
    {
        public int? Id { get; set; }
        public string ROT_ID { get; set; }
        public string PON_ID_DESTINO { get; set; }
        public PontosMapa PontosMapa { get; set; }
        public string PON_ID_ORIGEM { get; set; }
        public Decimal? ROT_CUSTO_TOTAL { get; set; }
        public string PON_ID_ROTEIRO { get; set; }
        public int? ROT_ORDEM_ROTEIRO { get; set; }
        public string ROT_TIPO { get; set; }
        public Decimal? ROT_DISTANCIA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<RotaPontosMapa> Query() => new MyApp.QueryBuilder.Query<RotaPontosMapa>();
    }

    public class Segmento
    {
        public int? Id { get; set; }
        public string SEG_ID { get; set; }
        public string SEG_DESCRICAO { get; set; }
        public string SEG_ID_SEGUIMENTO_PAI { get; set; }
        public string GRS_ID { get; set; }
        public string SEG_INTEGRACAO_ERP { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Segmento> Query() => new MyApp.QueryBuilder.Query<Segmento>();
    }

    public class SegmentosProdutos
    {
        public int? Id { get; set; }
        public string GRS_ID { get; set; }
        public string PRO_ID { get; set; }
        public string SEG_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<SegmentosProdutos> Query() => new MyApp.QueryBuilder.Query<SegmentosProdutos>();
    }

    public class Semaforo
    {
        public int? Id { get; set; }
        public string SEM_ID { get; set; }
        public string SEM_STATUS { get; set; }
        public string SEM_ORIGEM { get; set; }
        public DateTime? SEM_EMISSAO { get; set; }
        public string SEM_ID_CONEXAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Semaforo> Query() => new MyApp.QueryBuilder.Query<Semaforo>();
    }

    public class SubOcorrencia
    {
        public int? Id { get; set; }
        public string SUB_ID { get; set; }
        public string SUB_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<SubOcorrencia> Query() => new MyApp.QueryBuilder.Query<SubOcorrencia>();
    }

    public class Tabela
    {
        public int ID_TABELA { get; set; }
        public string CODIGO { get; set; }
        public string NOME { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Tabela> Query() => new MyApp.QueryBuilder.Query<Tabela>();
    }

    public class TargetProduto
    {
        public int TAR_ID { get; set; }
        public int? MOV_ID { get; set; }
        public MovimentoEstoque MovimentoEstoque { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public string PRO_ID { get; set; }
        public string MAQ_ID { get; set; }
        public string UNI_ID { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public string TURM_ID { get; set; }
        public Turma Turma { get; set; }
        public string TURN_ID { get; set; }
        public Turno Turno { get; set; }
        public int? USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string TAR_DIA_TURMA { get; set; }
        public Decimal TAR_META_PERFORMANCE { get; set; }
        public Decimal? TAR_REALIZADO_PERFORMANCE { get; set; }
        public Decimal? TAR_PERCENTUAL_REALIZADO_PERFORMANCE { get; set; }
        public Decimal? TAR_PROXIMA_META_PERFORMANCE { get; set; }
        public Decimal TAR_META_TEMPO_SETUP { get; set; }
        public Decimal? TAR_REALIZADO_TEMPO_SETUP { get; set; }
        public Decimal? TAR_PROXIMA_META_TEMPO_SETUP { get; set; }
        public Decimal TAR_META_TEMPO_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_REALIZADO_TEMPO_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE { get; set; }
        public string OCO_ID_PERFORMANCE { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public string TAR_OBS_PERFORMANCE { get; set; }
        public string OCO_ID_SETUP { get; set; }
        public string TAR_OBS_SETUP { get; set; }
        public string OCO_ID_SETUPA { get; set; }
        public string TAR_OBS_SETUPA { get; set; }
        public string TAR_TIPO_FEEDBACK_PERFORMANCE { get; set; }
        public string TAR_TIPO_FEEDBACK_SETUP { get; set; }
        public string TAR_TIPO_FEEDBACK_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_QTD_SETUP_AJUSTE { get; set; }
        public Decimal? TAR_QTD { get; set; }
        public int? TAR_PARAMETRO_TIME_WORK_STOP_MACHINE { get; set; }
        public int? TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE { get; set; }
        public int? ROT_SEQ_TRANFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public Decimal? TAR_PERFORMANCE_MAX_VERDE { get; set; }
        public Decimal? TAR_PERFORMANCE_MIN_VERDE { get; set; }
        public Decimal? TAR_SETUP_MAX_VERDE { get; set; }
        public Decimal? TAR_SETUP_MIN_VERDE { get; set; }
        public Decimal? TAR_SETUPA_MAX_VERDE { get; set; }
        public Decimal? TAR_SETUPA_MIN_VERDE { get; set; }
        public Decimal? TAR_PERFORMANCE_MIN_AMARELO { get; set; }
        public Decimal? TAR_SETUP_MAX_AMARELO { get; set; }
        public Decimal? TAR_SETUPA_MAX_AMARELO { get; set; }
        public string TAR_OBS_OP_PARCIAL { get; set; }
        public string TAR_OCO_ID_OP_PARCIAL { get; set; }
        public string TAR_COR_PERFORMANCE { get; set; }
        public string TAR_COR_SETUP_GERAL { get; set; }
        public string TAR_COR_SETUP { get; set; }
        public string TAR_COR_SETUPA { get; set; }
        public DateTime? TAR_DIA_TURMA_D { get; set; }
        public Decimal? FEE_QTD_PECAS_POR_PULSO { get; set; }
        public Decimal? TAR_QTD_PERDAS { get; set; }
        public DateTime? TAR_DATA_INICIAL { get; set; }
        public DateTime? TAR_DATA_FINAL { get; set; }
        public string TAR_APROVADO { get; set; }
        public int? TAR_TEMPO_PRODUZINDO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TargetProduto> Query() => new MyApp.QueryBuilder.Query<TargetProduto>();
    }

    public class TemplatesGrupoMaquina
    {
        public int? Id { get; set; }
        public int TEM_ID { get; set; }
        public string GMA_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TemplatesGrupoMaquina> Query() => new MyApp.QueryBuilder.Query<TemplatesGrupoMaquina>();
    }

    public class TemplatesMaquinas
    {
        public int? Id { get; set; }
        public int TEM_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TemplatesMaquinas> Query() => new MyApp.QueryBuilder.Query<TemplatesMaquinas>();
    }

    public class TempoSetupOnduladeira
    {
        public int TEM_ID { get; set; }
        public string OND_ID_DE { get; set; }
        public Onda Onda { get; set; }
        public string OND_ID_PARA { get; set; }
        public string TEM_RESINA_DE { get; set; }
        public string TEM_RESINA_PARA { get; set; }
        public int? TEM_TEMPO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TempoSetupOnduladeira> Query() => new MyApp.QueryBuilder.Query<TempoSetupOnduladeira>();
    }

    public class TemposLogisticos
    {
        public int? Id { get; set; }
        public string TMP_TIPO_TEMPO { get; set; }
        public string TMP_TIPO_CARGA { get; set; }
        public Decimal TMP_TEMPO_MEDIO_UNITARIO { get; set; }
        public string CLI_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TemposLogisticos> Query() => new MyApp.QueryBuilder.Query<TemposLogisticos>();
    }

    public class TesteFisico
    {
        public int? Id { get; set; }
        public int TES_ID { get; set; }
        public int? ITE_ID { get; set; }
        public int? USR_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string TES_NOME_TECNICO { get; set; }
        public int? TES_AMOSTRA { get; set; }
        public string TES_OP { get; set; }
        public Decimal? TES_VALOR_NUMERICO { get; set; }
        public DateTime? TES_VALOR_DATA { get; set; }
        public string TES_VALOR_TEXTO { get; set; }
        public DateTime? TES_EMISSAO { get; set; }
        public string ORD_ID { get; set; }
        public Order Order { get; set; }
        public string PRO_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public int? FPR_SEQ_TRANFORMACAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TesteFisico> Query() => new MyApp.QueryBuilder.Query<TesteFisico>();
    }

    public class TipoABNT
    {
        public int? Id { get; set; }
        public string ABN_ID { get; set; }
        public string ABN_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoABNT> Query() => new MyApp.QueryBuilder.Query<TipoABNT>();
    }

    public class TipoCarroceria
    {
        public int? Id { get; set; }
        public string TCA_ID { get; set; }
        public string TCA_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoCarroceria> Query() => new MyApp.QueryBuilder.Query<TipoCarroceria>();
    }

    public class TipoDispositivo
    {
        public int? Id { get; set; }
        public string TDI_ID { get; set; }
        public string TDI_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoDispositivo> Query() => new MyApp.QueryBuilder.Query<TipoDispositivo>();
    }

    public class TipoDispositivoMaquina
    {
        public int? Id { get; set; }
        public string TDI_ID { get; set; }
        public string MAQ_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoDispositivoMaquina> Query() => new MyApp.QueryBuilder.Query<TipoDispositivoMaquina>();
    }

    public class TipoInspecaoItens
    {
        public int? Id { get; set; }
        public int TII_ID { get; set; }
        public int? TIV_ID { get; set; }
        public int? ITI_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoInspecaoItens> Query() => new MyApp.QueryBuilder.Query<TipoInspecaoItens>();
    }

    public class TipoInspecaoVisual
    {
        public int? Id { get; set; }
        public int TIV_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public string TIV_NOME { get; set; }
        public string TIV_DESCRICAO { get; set; }
        public string TIV_FECHAMENTO { get; set; }
        public string TIV_AMOSTRA_ALEATORIA { get; set; }
        public int? TIV_N_AMOSTRAS { get; set; }
        public string TIV_MEDIDA { get; set; }
        public Decimal? TIV_ESPECIFICACAO { get; set; }
        public Decimal? TIV_TOL_MAIS { get; set; }
        public Decimal? TIV_TOL_MENOS { get; set; }

        public static MyApp.QueryBuilder.Query<TipoInspecaoVisual> Query() => new MyApp.QueryBuilder.Query<TipoInspecaoVisual>();
    }

    public class TipoMovimentoEstoque
    {
        public string TIP_ID { get; set; }
        public string TIP_DESCRICAO { get; set; }
        public int TIP_TYPE { get; set; }
        public int SPR { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoMovimentoEstoque> Query() => new MyApp.QueryBuilder.Query<TipoMovimentoEstoque>();
    }

    public class TipoOcorrencia
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int? Spr { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoOcorrencia> Query() => new MyApp.QueryBuilder.Query<TipoOcorrencia>();
    }

    public class TipoTeste
    {
        public Decimal? TT_ESPECIFICACAO { get; set; }
        public string TT_ORIGEM_ESPECIFICACAO { get; set; }
        public string TT_IMPRIME_NO_LAUDO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public int TT_ID { get; set; }
        public string TT_NOME { get; set; }
        public string TT_DESC { get; set; }
        public Decimal? TT_TOL_MAIS { get; set; }
        public Decimal? TT_TOL_MENOS { get; set; }
        public string TT_NORMA { get; set; }
        public string TT_INICIO_PROCESSO { get; set; }
        public int TA_ID { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }
        public string UNI_ID { get; set; }
        public int? TT_N_AMOSTRAS_P_TESTE { get; set; }
        public int? TT_MAX_DEF_CRITICO { get; set; }
        public int? TT_MAX_DEF_GRAVE { get; set; }

        public static MyApp.QueryBuilder.Query<TipoTeste> Query() => new MyApp.QueryBuilder.Query<TipoTeste>();
    }

    public class TipoVeiculo
    {
        public int? Id { get; set; }
        public int TIP_ID { get; set; }
        public string TIP_DESCRICAO { get; set; }
        public int? TIP_QTD_DISPONIVEL { get; set; }
        public Decimal? TIP_VALOR_KM { get; set; }
        public Decimal? TIP_VALOR_DIARIA { get; set; }
        public Decimal? TIP_VALOR_AJUDANTE { get; set; }
        public Decimal? TIP_QTD_EIXOS { get; set; }
        public Decimal? TIP_VELOCIDADE_MEDIA { get; set; }
        public Decimal? TIP_CAPACIDADE_ALTURA { get; set; }
        public Decimal? TIP_CAPACIDADE_COMPRIMENTO { get; set; }
        public Decimal? TIP_CAPACIDADE_LARGURA { get; set; }
        public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_E { get; set; }
        public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E { get; set; }
        public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_E { get; set; }
        public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_D { get; set; }
        public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D { get; set; }
        public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_D { get; set; }
        public Decimal? TIP_CAPACIDADE_M3 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoVeiculo> Query() => new MyApp.QueryBuilder.Query<TipoVeiculo>();
    }

    public class Vinco
    {
        public int VIN_ID { get; set; }
        public string VIN_DESCRICAO { get; set; }
        public string VIN_ID_DESLOCAMENTO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Vinco> Query() => new MyApp.QueryBuilder.Query<Vinco>();
    }

    public class TiposVincoGruposProdutos
    {
        public int? Id { get; set; }
        public int Id2 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TiposVincoGruposProdutos> Query() => new MyApp.QueryBuilder.Query<TiposVincoGruposProdutos>();
    }

    public class TiposVincoOndas
    {
        public int? Id { get; set; }
        public int Id2 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TiposVincoOndas> Query() => new MyApp.QueryBuilder.Query<TiposVincoOndas>();
    }

    public class TiposVincoProdutos
    {
        public int? Id { get; set; }
        public int Id2 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TiposVincoProdutos> Query() => new MyApp.QueryBuilder.Query<TiposVincoProdutos>();
    }

    public class Transportadora
    {
        public int? Id { get; set; }
        public string TRA_ID { get; set; }
        public string TRA_NOME { get; set; }
        public string TRA_EMAIL { get; set; }
        public string TRA_RESPONSAVEL { get; set; }
        public string TRA_FONE { get; set; }
        public string TRA_ID_INTEGRACAO { get; set; }
        public string TRA_ID_INTEGRACAO_ERP { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Transportadora> Query() => new MyApp.QueryBuilder.Query<Transportadora>();
    }

    public class Turma
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public DateTime? TURM_HORA_INI_DIA1 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA1 { get; set; }
        public DateTime? TURM_HORA_INI_DIA2 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA2 { get; set; }
        public DateTime? TURM_HORA_INI_DIA3 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA3 { get; set; }
        public DateTime? TURM_HORA_INI_DIA4 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA4 { get; set; }
        public DateTime? TURM_HORA_INI_DIA5 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA5 { get; set; }
        public DateTime? TURM_HORA_INI_DIA6 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA6 { get; set; }
        public DateTime? TURM_HORA_INI_DIA7 { get; set; }
        public DateTime? TURM_HORA_FIM_DIA7 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Turma> Query() => new MyApp.QueryBuilder.Query<Turma>();
    }

    public class Turno
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public int TURN_PRIORIDADE { get; set; }
        public DateTime? TURN_HORA_INI_DIA1 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA1 { get; set; }
        public DateTime? TURN_HORA_INI_DIA2 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA2 { get; set; }
        public DateTime? TURN_HORA_INI_DIA3 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA3 { get; set; }
        public DateTime? TURN_HORA_INI_DIA4 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA4 { get; set; }
        public DateTime? TURN_HORA_INI_DIA5 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA5 { get; set; }
        public DateTime? TURN_HORA_INI_DIA6 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA6 { get; set; }
        public DateTime? TURN_HORA_INI_DIA7 { get; set; }
        public DateTime? TURN_HORA_FIM_DIA7 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Turno> Query() => new MyApp.QueryBuilder.Query<Turno>();
    }

    public class Unidade
    {
        public int UNI_ID { get; set; }
        public string DEESCRICAO { get; set; }
        public string UN { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Unidade> Query() => new MyApp.QueryBuilder.Query<Unidade>();
    }

    public class UnidadeMedida
    {
        public string UNI_ID { get; set; }
        public string UNI_DESCRICAO { get; set; }
        public string UNI_ESCALA_TEMPO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<UnidadeMedida> Query() => new MyApp.QueryBuilder.Query<UnidadeMedida>();
    }

    public class Uniuser
    {
        public int USERGRU_ID { get; set; }
        public int UNI_ID { get; set; }
        public Unidade Unidade { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Uniuser> Query() => new MyApp.QueryBuilder.Query<Uniuser>();
    }

    public class T_USER_GRUPO
    {
        public int? Id { get; set; }
        public int GRU_ID { get; set; }
        public T_Grupo T_Grupo { get; set; }
        public int ID_USUARIO { get; set; }
        public Usuario Usuario { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<T_USER_GRUPO> Query() => new MyApp.QueryBuilder.Query<T_USER_GRUPO>();
    }

    public class Usuario
    {
        public int USE_ID { get; set; }
        public string USE_NOME { get; set; }
        public string USE_EMAIL { get; set; }
        public string USE_SENHA { get; set; }
        public string TURM_ID { get; set; }
        public Turma Turma { get; set; }
        public int USE_ATIVO { get; set; }
        public string USE_CODERP { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Usuario> Query() => new MyApp.QueryBuilder.Query<Usuario>();
    }

    public class UsuarioObjetoControlavel
    {
        public int? Id { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string OBJ_ID { get; set; }
        public string USU_OBJETO_ACAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<UsuarioObjetoControlavel> Query() => new MyApp.QueryBuilder.Query<UsuarioObjetoControlavel>();
    }

    public class UsuarioPerfil
    {
        public int? Id { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public int PER_ID { get; set; }
        public Perfil Perfil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<UsuarioPerfil> Query() => new MyApp.QueryBuilder.Query<UsuarioPerfil>();
    }

    public class UsuariosCarga
    {
        public int? Id { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public string CAR_ID { get; set; }
        public string RGO_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<UsuariosCarga> Query() => new MyApp.QueryBuilder.Query<UsuariosCarga>();
    }

    public class Variavel
    {
        public int? Id { get; set; }
        public int VAR_ID { get; set; }
        public string VAR_DESCRICAO { get; set; }
        public int? CON_ID { get; set; }
        public int VAR_MODO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Variavel> Query() => new MyApp.QueryBuilder.Query<Variavel>();
    }

    public class VariavelPlotagem
    {
        public int? Id { get; set; }
        public int VAR_ID { get; set; }
        public int PLO_ID { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<VariavelPlotagem> Query() => new MyApp.QueryBuilder.Query<VariavelPlotagem>();
    }

    public class Veiculo
    {
        public int? Id { get; set; }
        public string VEI_PLACA { get; set; }
        public int TIP_ID { get; set; }
        public Decimal? VEI_CAPACIDADE_M3 { get; set; }
        public Decimal? VEI_CAPACIDADE_LARGURA { get; set; }
        public Decimal? VEI_CAPACIDADE_COMPRIMENTO { get; set; }
        public Decimal? VEI_CAPACIDADE_ALTURA { get; set; }
        public string VEI_MODELO { get; set; }
        public string VEI_NOME_MOTORISTA { get; set; }
        public string VEI_DADOS_CONTATO { get; set; }
        public string VEI_CPF_MOTORISTA { get; set; }
        public string TCA_ID { get; set; }
        public DateTime? VEI_EMISSAO { get; set; }
        public DateTime? VEI_VENCIMENTO { get; set; }
        public string VEI_STATUS { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Veiculo> Query() => new MyApp.QueryBuilder.Query<Veiculo>();
    }

    public class VersaoCusto
    {
        public int? Id { get; set; }
        public int VER_ID { get; set; }
        public string VER_STATUS { get; set; }
        public string VER_OBS { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<VersaoCusto> Query() => new MyApp.QueryBuilder.Query<VersaoCusto>();
    }

    public class VerssaoCusto
    {
        public int? Id { get; set; }
        public int VER_ID { get; set; }
        public string VER_STATUS { get; set; }
        public DateTime? VER_DATA_VERSSAO_CUSTO { get; set; }
        public string VER_OBS { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<VerssaoCusto> Query() => new MyApp.QueryBuilder.Query<VerssaoCusto>();
    }

    public class Cabvisao
    {
        public int CAB_ID { get; set; }
        public string CAB_DESC { get; set; }
        public int CAB_STATUS { get; set; }
        public int USE_ID { get; set; }
        public Usuario Usuario { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Cabvisao> Query() => new MyApp.QueryBuilder.Query<Cabvisao>();
    }

    public class Movimentos
    {
        public int MOV_ID { get; set; }
        public string MOV_DATA { get; set; }
        public Decimal MOV_VALOR { get; set; }
        public int MOV_PLAID { get; set; }
        public Planocontas Planocontas { get; set; }
        public int MOV_UNID { get; set; }
        public int? Tr_Unidade_UNI_ID { get; set; }
        public Unidade_Unidade Unidade_Unidade { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Movimentos> Query() => new MyApp.QueryBuilder.Query<Movimentos>();
    }

    public class Planocontas
    {
        public int PLA_ID { get; set; }
        public string PLA_CODIGO { get; set; }
        public string PLA_DESCRICAO { get; set; }
        public int PLA_TIPO { get; set; }
        public string PLA_NATUREZA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Planocontas> Query() => new MyApp.QueryBuilder.Query<Planocontas>();
    }

    public class Unidade_Unidade
    {
        public int UNI_ID { get; set; }
        public string UNI_DESCRICAO { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Unidade_Unidade> Query() => new MyApp.QueryBuilder.Query<Unidade_Unidade>();
    }

    public class Visoes
    {
        public int VIS_ID { get; set; }
        public int VIS_PLANID { get; set; }
        public Planocontas Planocontas { get; set; }
        public string VIS_FORMULA { get; set; }
        public int CAB_ID { get; set; }
        public Cabvisao Cabvisao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Visoes> Query() => new MyApp.QueryBuilder.Query<Visoes>();
    }

    public class Relatorios
    {
        public int REL_ID { get; set; }
        public string REL_NOME_RELATORIO { get; set; }
        public string REL_NOME_CAMPO { get; set; }
        public string REL_TIPO_CAMPO { get; set; }
        public int? REL_POS_X { get; set; }
        public int? REL_POS_Y { get; set; }
        public int? REL_TAMANHO_FONTE { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Relatorios> Query() => new MyApp.QueryBuilder.Query<Relatorios>();
    }

    public class InspecaoVisual
    {
        public int IPV_ID { get; set; }
        public string IPV_VALOR { get; set; }
        public int? IPV_ID_OPERADOR { get; set; }
        public int? IPV_ID_LIBERACAO { get; set; }
        public string IPV_OBS { get; set; }
        public DateTime? IPV_DATA_COLETA { get; set; }
        public DateTime? IPV_DATA_AVAL { get; set; }
        public int? TIV_ID { get; set; }
        public string TURN_ID { get; set; }
        public Turno Turno { get; set; }
        public string TURM_ID { get; set; }
        public Turma Turma { get; set; }
        public string ORD_ID { get; set; }
        public string ROT_PRO_ID { get; set; }
        public string ROT_MAQ_ID { get; set; }
        public int? ROT_SEQ_TRANSFORMACAO { get; set; }
        public int? FPR_SEQ_REPETICAO { get; set; }
        public string IPV_STATUS_LIBERACAO { get; set; }
        public Decimal? IPV_VALOR_MEDIDA { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<InspecaoVisual> Query() => new MyApp.QueryBuilder.Query<InspecaoVisual>();
    }

    public class TemplateTipoInspecaoVisual
    {
        public int TTI_ID { get; set; }
        public int? TIV_ID { get; set; }
        public int? TEM_ID { get; set; }
        public TemplateDeTestes TemplateDeTestes { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TemplateTipoInspecaoVisual> Query() => new MyApp.QueryBuilder.Query<TemplateTipoInspecaoVisual>();
    }

    public class TemplateTipoTeste
    {
        public int TTT_ID { get; set; }
        public int TT_ID { get; set; }
        public TipoTeste TipoTeste { get; set; }
        public int TEM_ID { get; set; }
        public TemplateDeTestes TemplateDeTestes { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TemplateTipoTeste> Query() => new MyApp.QueryBuilder.Query<TemplateTipoTeste>();
    }

    public class TipoAvaliacao
    {
        public int TA_ID { get; set; }
        public string TA_DESC { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TipoAvaliacao> Query() => new MyApp.QueryBuilder.Query<TipoAvaliacao>();
    }

    public class yFileUpload
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string FilePath { get; set; }
        public long? FileSize { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yFileUpload> Query() => new MyApp.QueryBuilder.Query<yFileUpload>();
    }

    public class ySaga
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string KeyCurrentStep { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public DateTime? NextExecutionAt { get; set; }
        public DateTime? LockedAt { get; set; }
        public string LockedBy { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ySaga> Query() => new MyApp.QueryBuilder.Query<ySaga>();
    }

    public class ySagaStep
    {
        public int? Id { get; set; }
        public int SagaId { get; set; }
        public ySaga ySaga { get; set; }
        public string StepKey { get; set; }
        public int IndexOrder { get; set; }
        public string CorrelationId { get; set; }
        public int Status { get; set; }
        public int ExecutionCount { get; set; }
        public DateTime? LastExecutionAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string ErrorMessage { get; set; }
        public string Payload { get; set; }
        public int RetryCount { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ySagaStep> Query() => new MyApp.QueryBuilder.Query<ySagaStep>();
    }

    public class yOutbox
    {
        public int? Id { get; set; }
        public string MessageId { get; set; }
        public string Type { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
        public int Status { get; set; }
        public int TransportType { get; set; }
        public string TransportData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int RetryCount { get; set; }
        public string LastError { get; set; }
        public DateTime? ProcessingAt { get; set; }
        public DateTime? NextAttemptAt { get; set; }
        public int? SagaId { get; set; }
        public ySaga ySaga { get; set; }
        public int? SagaStepId { get; set; }
        public ySagaStep ySagaStep { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yOutbox> Query() => new MyApp.QueryBuilder.Query<yOutbox>();
    }

    public class yInbox
    {
        public int? Id { get; set; }
        public string MessageId { get; set; }
        public string Type { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RetryCount { get; set; }
        public string LastError { get; set; }
        public DateTime? ProcessingAt { get; set; }
        public DateTime? NextAttemptAt { get; set; }
        public int? SagaId { get; set; }
        public ySaga ySaga { get; set; }
        public int? SagaStepId { get; set; }
        public ySagaStep ySagaStep { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yInbox> Query() => new MyApp.QueryBuilder.Query<yInbox>();
    }

    public class yToken
    {
        public int? Id { get; set; }
        public string TokenHash { get; set; }
        public string Description { get; set; }
        public string ConnectorKey { get; set; }
        public bool Active { get; set; }
        public DateTime? ValidUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yToken> Query() => new MyApp.QueryBuilder.Query<yToken>();
    }

    public class yTenant
    {
        public int? Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yTenant> Query() => new MyApp.QueryBuilder.Query<yTenant>();
    }

    public class yUser
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yUser> Query() => new MyApp.QueryBuilder.Query<yUser>();
    }

    public class yConfigArcteture
    {
        public int? Id { get; set; }
        public int? AuditTrackerActived { get; set; }
        public int? AuditCRUDActived { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yConfigArcteture> Query() => new MyApp.QueryBuilder.Query<yConfigArcteture>();
    }

    public class yConfigNotification
    {
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public string EmailSmtpClient { get; set; }
        public int? EmailPort { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yConfigNotification> Query() => new MyApp.QueryBuilder.Query<yConfigNotification>();
    }

    public class yPerfil
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yPerfil> Query() => new MyApp.QueryBuilder.Query<yPerfil>();
    }

    public class yModule
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public static MyApp.QueryBuilder.Query<yModule> Query() => new MyApp.QueryBuilder.Query<yModule>();
    }

    public class yTenantModule
    {
        public int? Id { get; set; }
        public string ModuleId { get; set; }
        public yModule yModule { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yTenantModule> Query() => new MyApp.QueryBuilder.Query<yTenantModule>();
    }

    public class yUserModule
    {
        public int? Id { get; set; }
        public string ModuleId { get; set; }
        public yModule yModule { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yUserModule> Query() => new MyApp.QueryBuilder.Query<yUserModule>();
    }

    public class yGrant
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yGrant> Query() => new MyApp.QueryBuilder.Query<yGrant>();
    }

    public class yPerfilGrant
    {
        public int? Id { get; set; }
        public int? PerfilId { get; set; }
        public yPerfil yPerfil { get; set; }
        public string GrantId { get; set; }
        public yGrant yGrant { get; set; }
        public bool? CanGrant { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanRead { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? CanDelete { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yPerfilGrant> Query() => new MyApp.QueryBuilder.Query<yPerfilGrant>();
    }

    public class yUserGrant
    {
        public int? Id { get; set; }
        public int? PerfilId { get; set; }
        public yPerfil yPerfil { get; set; }
        public string GrantId { get; set; }
        public yGrant yGrant { get; set; }
        public bool? CanGrant { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanRead { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? CanDelete { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yUserGrant> Query() => new MyApp.QueryBuilder.Query<yUserGrant>();
    }

}
//Dominio.Schemas.CQRS.SourceCodeEntityInternalMigration