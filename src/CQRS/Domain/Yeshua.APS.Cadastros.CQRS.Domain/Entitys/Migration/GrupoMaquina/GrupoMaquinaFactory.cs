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
                                public class GrupoMaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoMaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoMaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoMaquinaEntity Create(string gma_id, string gma_descricao, string gma_status )
                            {
                                return Create(null, gma_id, gma_descricao, gma_status);
                            }

                            public IGrupoMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string gma_id, string gma_descricao, string gma_status )
                            {
                            var entity = new GrupoMaquinaEntity(gma_id, gma_descricao, gma_status );


                            var trackingMask = _trackingPolicy?.GetMask("GrupoMaquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoMaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration