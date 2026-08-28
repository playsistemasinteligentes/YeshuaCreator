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
                                public class ItensOrcamentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItensOrcamentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItensOrcamentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItensOrcamentoEntity Create(int? id, int ito_id, int? orc_id, int? tip_id, string pro_id, string ito_obs, Decimal? ito_quantidade, Decimal? ito_custo, Decimal? ito_margem, Decimal? ito_valor_unitario, DateTime? ito_verssao_custo, string ito_status, Decimal? ito_erp_custos_fixos, Decimal? ito_erp_custos_variaveis, Decimal? ito_erp_despesas_var_venda, Decimal? ito_erp_impostos, string grp_id_composicao, Decimal? ito_largura, Decimal? ito_comprimento )
                            {
                                return Create(null, id, ito_id, orc_id, tip_id, pro_id, ito_obs, ito_quantidade, ito_custo, ito_margem, ito_valor_unitario, ito_verssao_custo, ito_status, ito_erp_custos_fixos, ito_erp_custos_variaveis, ito_erp_despesas_var_venda, ito_erp_impostos, grp_id_composicao, ito_largura, ito_comprimento);
                            }

                            public IItensOrcamentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ito_id, int? orc_id, int? tip_id, string pro_id, string ito_obs, Decimal? ito_quantidade, Decimal? ito_custo, Decimal? ito_margem, Decimal? ito_valor_unitario, DateTime? ito_verssao_custo, string ito_status, Decimal? ito_erp_custos_fixos, Decimal? ito_erp_custos_variaveis, Decimal? ito_erp_despesas_var_venda, Decimal? ito_erp_impostos, string grp_id_composicao, Decimal? ito_largura, Decimal? ito_comprimento )
                            {
                            var entity = new ItensOrcamentoEntity(id, ito_id, orc_id, tip_id, pro_id, ito_obs, ito_quantidade, ito_custo, ito_margem, ito_valor_unitario, ito_verssao_custo, ito_status, ito_erp_custos_fixos, ito_erp_custos_variaveis, ito_erp_despesas_var_venda, ito_erp_impostos, grp_id_composicao, ito_largura, ito_comprimento );


                            var trackingMask = _trackingPolicy?.GetMask("ItensOrcamento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItensOrcamentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration