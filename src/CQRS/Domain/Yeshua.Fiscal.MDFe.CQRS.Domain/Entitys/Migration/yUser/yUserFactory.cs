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
                                public class yUserFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yUserFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yUserFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyUserEntity Create(int? id, string nome, string email, string senha )
                            {
                                return Create(null, id, nome, email, senha);
                            }

                            public IyUserEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string nome, string email, string senha )
                            {
                            var entity = new yUserEntity(id, nome, email, senha );


                            var trackingMask = _trackingPolicy?.GetMask("yUser", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yUserDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration