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
                                public class VariavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VariavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VariavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVariavelEntity Create(int? id, int var_id, string var_descricao, int? con_id, int var_modo )
                            {
                                return Create(null, id, var_id, var_descricao, con_id, var_modo);
                            }

                            public IVariavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int var_id, string var_descricao, int? con_id, int var_modo )
                            {
                            var entity = new VariavelEntity(id, var_id, var_descricao, con_id, var_modo );


                            var trackingMask = _trackingPolicy?.GetMask("Variavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VariavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration