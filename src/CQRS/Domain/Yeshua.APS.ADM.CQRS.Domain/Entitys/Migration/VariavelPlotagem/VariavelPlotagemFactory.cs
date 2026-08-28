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
                                public class VariavelPlotagemFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VariavelPlotagemFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VariavelPlotagemFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVariavelPlotagemEntity Create(int? id, int var_id, int plo_id )
                            {
                                return Create(null, id, var_id, plo_id);
                            }

                            public IVariavelPlotagemEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int var_id, int plo_id )
                            {
                            var entity = new VariavelPlotagemEntity(id, var_id, plo_id );


                            var trackingMask = _trackingPolicy?.GetMask("VariavelPlotagem", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VariavelPlotagemDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration