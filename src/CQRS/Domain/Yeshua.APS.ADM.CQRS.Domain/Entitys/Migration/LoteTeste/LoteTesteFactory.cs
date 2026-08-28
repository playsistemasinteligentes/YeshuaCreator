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
                                public class LoteTesteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public LoteTesteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public LoteTesteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ILoteTesteEntity Create(int? id, int lt_id, int? tes_id, int? rl_id )
                            {
                                return Create(null, id, lt_id, tes_id, rl_id);
                            }

                            public ILoteTesteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int lt_id, int? tes_id, int? rl_id )
                            {
                            var entity = new LoteTesteEntity(id, lt_id, tes_id, rl_id );


                            var trackingMask = _trackingPolicy?.GetMask("LoteTeste", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new LoteTesteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration