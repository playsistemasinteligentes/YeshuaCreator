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
                                public class T_NegocioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_NegocioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_NegocioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_NegocioEntity Create(int neg_id, string neg_descricao )
                            {
                                return Create(null, neg_id, neg_descricao);
                            }

                            public IT_NegocioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int neg_id, string neg_descricao )
                            {
                            var entity = new T_NegocioEntity(neg_id, neg_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("T_Negocio", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_NegocioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration