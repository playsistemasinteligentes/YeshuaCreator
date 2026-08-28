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
                                public class IndicadoresDepartamentosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public IndicadoresDepartamentosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public IndicadoresDepartamentosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IIndicadoresDepartamentosEntity Create(int inddep_id, int dep_id, int ind_id )
                            {
                                return Create(null, inddep_id, dep_id, ind_id);
                            }

                            public IIndicadoresDepartamentosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int inddep_id, int dep_id, int ind_id )
                            {
                            var entity = new IndicadoresDepartamentosEntity(inddep_id, dep_id, ind_id );


                            var trackingMask = _trackingPolicy?.GetMask("IndicadoresDepartamentos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new IndicadoresDepartamentosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration