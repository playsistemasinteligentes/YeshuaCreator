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
                                public class CargosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CargosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CargosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICargosEntity Create(int? id, string rgo_id, string rgo_descricao )
                            {
                                return Create(null, id, rgo_id, rgo_descricao);
                            }

                            public ICargosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string rgo_id, string rgo_descricao )
                            {
                            var entity = new CargosEntity(id, rgo_id, rgo_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("Cargos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CargosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration