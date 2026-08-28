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
                                public class TipoAvaliacaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoAvaliacaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoAvaliacaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoAvaliacaoEntity Create(int ta_id, string ta_desc )
                            {
                                return Create(null, ta_id, ta_desc);
                            }

                            public ITipoAvaliacaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int ta_id, string ta_desc )
                            {
                            var entity = new TipoAvaliacaoEntity(ta_id, ta_desc );


                            var trackingMask = _trackingPolicy?.GetMask("TipoAvaliacao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoAvaliacaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration