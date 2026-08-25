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
                                public class ServicoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ServicoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ServicoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IServicoEntity Create(int? id, int? gruposervicoid, string nome, Decimal valor )
                            {
                                return Create(null, id, gruposervicoid, nome, valor);
                            }

                            public IServicoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? gruposervicoid, string nome, Decimal valor )
                            {
                            var entity = new ServicoEntity(id, gruposervicoid, nome, valor );


                            var trackingMask = _trackingPolicy?.GetMask("Servico", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ServicoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration