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
                                public class RepresentantesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RepresentantesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RepresentantesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRepresentantesEntity Create(int? id, int rep_id, string rep_nome )
                            {
                                return Create(null, id, rep_id, rep_nome);
                            }

                            public IRepresentantesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int rep_id, string rep_nome )
                            {
                            var entity = new RepresentantesEntity(id, rep_id, rep_nome );


                            var trackingMask = _trackingPolicy?.GetMask("Representantes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RepresentantesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration