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
                                public class ParamFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ParamFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ParamFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IParamEntity Create(string par_id, string par_descricao, string par_valor_s, Decimal par_valor_n, DateTime par_valor_d )
                            {
                                return Create(null, par_id, par_descricao, par_valor_s, par_valor_n, par_valor_d);
                            }

                            public IParamEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string par_id, string par_descricao, string par_valor_s, Decimal par_valor_n, DateTime par_valor_d )
                            {
                            var entity = new ParamEntity(par_id, par_descricao, par_valor_s, par_valor_n, par_valor_d );


                            var trackingMask = _trackingPolicy?.GetMask("Param", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ParamDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration