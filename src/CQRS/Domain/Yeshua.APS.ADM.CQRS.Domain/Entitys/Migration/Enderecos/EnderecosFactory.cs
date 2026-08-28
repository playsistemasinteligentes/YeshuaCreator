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
                                public class EnderecosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EnderecosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EnderecosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEnderecosEntity Create(string end_id, string end_grupo )
                            {
                                return Create(null, end_id, end_grupo);
                            }

                            public IEnderecosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string end_id, string end_grupo )
                            {
                            var entity = new EnderecosEntity(end_id, end_grupo );


                            var trackingMask = _trackingPolicy?.GetMask("Enderecos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EnderecosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration