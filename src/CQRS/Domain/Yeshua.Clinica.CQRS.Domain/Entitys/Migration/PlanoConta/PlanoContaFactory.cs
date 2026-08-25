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
                                public class PlanoContaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlanoContaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlanoContaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlanoContaEntity Create(int? id, string codigo, string nome, int tipo )
                            {
                                return Create(null, id, codigo, nome, tipo);
                            }

                            public IPlanoContaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string codigo, string nome, int tipo )
                            {
                            var entity = new PlanoContaEntity(id, codigo, nome, tipo );


                            var trackingMask = _trackingPolicy?.GetMask("PlanoConta", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlanoContaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration