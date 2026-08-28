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
                                public class ParametrosDeCustoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ParametrosDeCustoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ParametrosDeCustoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IParametrosDeCustoEntity Create(int? id, int par_id, string pro_id, string cus_id, string par_valor )
                            {
                                return Create(null, id, par_id, pro_id, cus_id, par_valor);
                            }

                            public IParametrosDeCustoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int par_id, string pro_id, string cus_id, string par_valor )
                            {
                            var entity = new ParametrosDeCustoEntity(id, par_id, pro_id, cus_id, par_valor );


                            var trackingMask = _trackingPolicy?.GetMask("ParametrosDeCusto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ParametrosDeCustoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration