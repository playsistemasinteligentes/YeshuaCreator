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
                                public class MedicoesOnduladeiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MedicoesOnduladeiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MedicoesOnduladeiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMedicoesOnduladeiraEntity Create(int? id )
                            {
                                return Create(null, id);
                            }

                            public IMedicoesOnduladeiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id )
                            {
                            var entity = new MedicoesOnduladeiraEntity(id );


                            var trackingMask = _trackingPolicy?.GetMask("MedicoesOnduladeira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MedicoesOnduladeiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration