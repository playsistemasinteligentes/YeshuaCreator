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
                                public class ConfiguracoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConfiguracoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConfiguracoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConfiguracoesEntity Create(int con_id )
                            {
                                return Create(null, con_id);
                            }

                            public IConfiguracoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int con_id )
                            {
                            var entity = new ConfiguracoesEntity(con_id );


                            var trackingMask = _trackingPolicy?.GetMask("Configuracoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConfiguracoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration