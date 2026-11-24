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
                                public class PublicacaoDestinoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PublicacaoDestinoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PublicacaoDestinoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPublicacaoDestinoEntity Create(string? id, string? identidadeid, string? versaoid, string? canalid, string? estado, int? tentativas, DateTime? proximatentativautc, string? reciboexterno, string? urlpublica )
                            {
                                return Create(null, id, identidadeid, versaoid, canalid, estado, tentativas, proximatentativautc, reciboexterno, urlpublica);
                            }

                            public IPublicacaoDestinoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? versaoid, string? canalid, string? estado, int? tentativas, DateTime? proximatentativautc, string? reciboexterno, string? urlpublica, ulong? trackingMask = null )
                            {
                            var entity = new PublicacaoDestinoEntity(id, identidadeid, versaoid, canalid, estado, tentativas, proximatentativautc, reciboexterno, urlpublica );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("PublicacaoDestino", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PublicacaoDestinoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration