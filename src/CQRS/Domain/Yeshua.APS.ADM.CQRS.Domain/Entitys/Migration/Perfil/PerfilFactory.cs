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
                                public class PerfilFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PerfilFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PerfilFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPerfilEntity Create(int per_id, string per_nome )
                            {
                                return Create(null, per_id, per_nome);
                            }

                            public IPerfilEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int per_id, string per_nome )
                            {
                            var entity = new PerfilEntity(per_id, per_nome );


                            var trackingMask = _trackingPolicy?.GetMask("Perfil", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PerfilDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration