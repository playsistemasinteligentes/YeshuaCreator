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
                                public class yPerfilFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yPerfilFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yPerfilFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyPerfilEntity Create(int? id, string description )
                            {
                                return Create(null, id, description);
                            }

                            public IyPerfilEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string description )
                            {
                            var entity = new yPerfilEntity(id, description );


                            var trackingMask = _trackingPolicy?.GetMask("yPerfil", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yPerfilDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration