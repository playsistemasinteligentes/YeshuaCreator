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
                                public class UnidadeMedidaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UnidadeMedidaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UnidadeMedidaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUnidadeMedidaEntity Create(string uni_id, string uni_descricao, string uni_escala_tempo )
                            {
                                return Create(null, uni_id, uni_descricao, uni_escala_tempo);
                            }

                            public IUnidadeMedidaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string uni_id, string uni_descricao, string uni_escala_tempo )
                            {
                            var entity = new UnidadeMedidaEntity(uni_id, uni_descricao, uni_escala_tempo );


                            var trackingMask = _trackingPolicy?.GetMask("UnidadeMedida", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UnidadeMedidaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration