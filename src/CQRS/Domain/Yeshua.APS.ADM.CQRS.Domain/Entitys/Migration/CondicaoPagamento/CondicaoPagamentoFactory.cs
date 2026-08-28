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
                                public class CondicaoPagamentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CondicaoPagamentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CondicaoPagamentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICondicaoPagamentoEntity Create(int? id, string con_id, string con_descricao, int? con_parcelas, Decimal? con_valor_acrecimo, string con_integracao_erp )
                            {
                                return Create(null, id, con_id, con_descricao, con_parcelas, con_valor_acrecimo, con_integracao_erp);
                            }

                            public ICondicaoPagamentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string con_id, string con_descricao, int? con_parcelas, Decimal? con_valor_acrecimo, string con_integracao_erp )
                            {
                            var entity = new CondicaoPagamentoEntity(id, con_id, con_descricao, con_parcelas, con_valor_acrecimo, con_integracao_erp );


                            var trackingMask = _trackingPolicy?.GetMask("CondicaoPagamento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CondicaoPagamentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration