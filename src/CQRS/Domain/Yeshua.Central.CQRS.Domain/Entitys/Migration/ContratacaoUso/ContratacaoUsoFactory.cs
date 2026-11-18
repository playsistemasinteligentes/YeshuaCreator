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
                                public class ContratacaoUsoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ContratacaoUsoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ContratacaoUsoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IContratacaoUsoEntity Create(string? id, string oferta, int quantidade, Decimal creditos, DateTime criadaemutc )
                            {
                                return Create(null, id, oferta, quantidade, creditos, criadaemutc);
                            }

                            public IContratacaoUsoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string oferta, int quantidade, Decimal creditos, DateTime criadaemutc, ulong? trackingMask = null )
                            {
                            var entity = new ContratacaoUsoEntity(id, oferta, quantidade, creditos, criadaemutc );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("ContratacaoUso", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ContratacaoUsoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration