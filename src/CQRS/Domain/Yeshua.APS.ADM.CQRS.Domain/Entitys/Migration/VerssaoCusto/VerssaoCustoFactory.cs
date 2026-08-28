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
                                public class VerssaoCustoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VerssaoCustoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VerssaoCustoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVerssaoCustoEntity Create(int? id, int ver_id, string ver_status, DateTime? ver_data_verssao_custo, string ver_obs )
                            {
                                return Create(null, id, ver_id, ver_status, ver_data_verssao_custo, ver_obs);
                            }

                            public IVerssaoCustoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ver_id, string ver_status, DateTime? ver_data_verssao_custo, string ver_obs )
                            {
                            var entity = new VerssaoCustoEntity(id, ver_id, ver_status, ver_data_verssao_custo, ver_obs );


                            var trackingMask = _trackingPolicy?.GetMask("VerssaoCusto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VerssaoCustoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration