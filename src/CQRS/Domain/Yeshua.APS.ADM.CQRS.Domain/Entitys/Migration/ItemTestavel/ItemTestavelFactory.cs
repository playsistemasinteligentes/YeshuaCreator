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
                                public class ItemTestavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItemTestavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItemTestavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItemTestavelEntity Create(int? id, int ite_id, string ite_descricao, string ite_obs, int? ite_numero_de_testes, string ite_condicional_de_avaliacao, Decimal? ite_valor_da_condicional, string ite_valor_calculado_da_condicional, string ite_tipo_avaliacao_final )
                            {
                                return Create(null, id, ite_id, ite_descricao, ite_obs, ite_numero_de_testes, ite_condicional_de_avaliacao, ite_valor_da_condicional, ite_valor_calculado_da_condicional, ite_tipo_avaliacao_final);
                            }

                            public IItemTestavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ite_id, string ite_descricao, string ite_obs, int? ite_numero_de_testes, string ite_condicional_de_avaliacao, Decimal? ite_valor_da_condicional, string ite_valor_calculado_da_condicional, string ite_tipo_avaliacao_final )
                            {
                            var entity = new ItemTestavelEntity(id, ite_id, ite_descricao, ite_obs, ite_numero_de_testes, ite_condicional_de_avaliacao, ite_valor_da_condicional, ite_valor_calculado_da_condicional, ite_tipo_avaliacao_final );


                            var trackingMask = _trackingPolicy?.GetMask("ItemTestavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItemTestavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration