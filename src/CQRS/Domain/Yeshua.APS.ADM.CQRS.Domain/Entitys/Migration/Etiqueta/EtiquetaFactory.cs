// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>



                            namespace Dominio.Entitys
                            {
                                public class EtiquetaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EtiquetaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EtiquetaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEtiquetaEntity Create(int eti_id, DateTime? eti_emissao, string eti_codigo_barras, int? eti_sequencia, int? eti_numero_copias, string eti_status, DateTime? eti_data_fabricacao, string eti_cod_barras_original, string eti_op_original, string maq_id, int? imp_id, int? use_id, string ord_id, string rot_pro_id, int? rot_seq_tranformacao, int? fpr_seq_repeticao, Decimal? eti_quantidade_palete, string eti_lote, string eti_sub_lote, int? eti_imprimir_de, int? eti_imprimir_ate, string bol_id, int? cor_sequencia )
                            {
                                return Create(null, eti_id, eti_emissao, eti_codigo_barras, eti_sequencia, eti_numero_copias, eti_status, eti_data_fabricacao, eti_cod_barras_original, eti_op_original, maq_id, imp_id, use_id, ord_id, rot_pro_id, rot_seq_tranformacao, fpr_seq_repeticao, eti_quantidade_palete, eti_lote, eti_sub_lote, eti_imprimir_de, eti_imprimir_ate, bol_id, cor_sequencia);
                            }

                            public IEtiquetaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int eti_id, DateTime? eti_emissao, string eti_codigo_barras, int? eti_sequencia, int? eti_numero_copias, string eti_status, DateTime? eti_data_fabricacao, string eti_cod_barras_original, string eti_op_original, string maq_id, int? imp_id, int? use_id, string ord_id, string rot_pro_id, int? rot_seq_tranformacao, int? fpr_seq_repeticao, Decimal? eti_quantidade_palete, string eti_lote, string eti_sub_lote, int? eti_imprimir_de, int? eti_imprimir_ate, string bol_id, int? cor_sequencia )
                            {
                            var entity = new EtiquetaEntity(eti_id, eti_emissao, eti_codigo_barras, eti_sequencia, eti_numero_copias, eti_status, eti_data_fabricacao, eti_cod_barras_original, eti_op_original, maq_id, imp_id, use_id, ord_id, rot_pro_id, rot_seq_tranformacao, fpr_seq_repeticao, eti_quantidade_palete, eti_lote, eti_sub_lote, eti_imprimir_de, eti_imprimir_ate, bol_id, cor_sequencia );


                            var trackingMask = _trackingPolicy?.GetMask("Etiqueta", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EtiquetaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration