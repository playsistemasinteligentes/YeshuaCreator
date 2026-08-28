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
                                public class VersaoCustoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VersaoCustoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VersaoCustoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVersaoCustoEntity Create(int? id, int ver_id, string ver_status, string ver_obs )
                            {
                                return Create(null, id, ver_id, ver_status, ver_obs);
                            }

                            public IVersaoCustoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ver_id, string ver_status, string ver_obs )
                            {
                            var entity = new VersaoCustoEntity(id, ver_id, ver_status, ver_obs );


                            var trackingMask = _trackingPolicy?.GetMask("VersaoCusto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VersaoCustoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration