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
                                public class EstruturaCustoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EstruturaCustoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EstruturaCustoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEstruturaCustoEntity Create(int est_id, int? ito_id, string ord_id, string pro_id, string pro_id_produto, string pro_id_componente, string pro_tipo_custo, string pro_grupo_contabil, int est_ordem, string est_grupo, Decimal est_quant, Decimal est_valor_total, string est_data_base, Decimal est_base_producao, Decimal? est_nivel, int? fpr_seq_repeticao )
                            {
                                return Create(null, est_id, ito_id, ord_id, pro_id, pro_id_produto, pro_id_componente, pro_tipo_custo, pro_grupo_contabil, est_ordem, est_grupo, est_quant, est_valor_total, est_data_base, est_base_producao, est_nivel, fpr_seq_repeticao);
                            }

                            public IEstruturaCustoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int est_id, int? ito_id, string ord_id, string pro_id, string pro_id_produto, string pro_id_componente, string pro_tipo_custo, string pro_grupo_contabil, int est_ordem, string est_grupo, Decimal est_quant, Decimal est_valor_total, string est_data_base, Decimal est_base_producao, Decimal? est_nivel, int? fpr_seq_repeticao )
                            {
                            var entity = new EstruturaCustoEntity(est_id, ito_id, ord_id, pro_id, pro_id_produto, pro_id_componente, pro_tipo_custo, pro_grupo_contabil, est_ordem, est_grupo, est_quant, est_valor_total, est_data_base, est_base_producao, est_nivel, fpr_seq_repeticao );


                            var trackingMask = _trackingPolicy?.GetMask("EstruturaCusto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EstruturaCustoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration