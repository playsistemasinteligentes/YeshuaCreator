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
                                public class OptAlteracaoDimencoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OptAlteracaoDimencoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OptAlteracaoDimencoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOptAlteracaoDimencoesEntity Create(int? id, int oad_id )
                            {
                                return Create(null, id, oad_id);
                            }

                            public IOptAlteracaoDimencoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int oad_id )
                            {
                            var entity = new OptAlteracaoDimencoesEntity(id, oad_id );


                            var trackingMask = _trackingPolicy?.GetMask("OptAlteracaoDimencoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OptAlteracaoDimencoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration