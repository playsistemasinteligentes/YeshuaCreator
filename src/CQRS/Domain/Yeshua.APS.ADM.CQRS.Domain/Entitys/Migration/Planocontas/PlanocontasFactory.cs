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
                                public class PlanocontasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlanocontasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlanocontasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlanocontasEntity Create(int pla_id, string pla_codigo, string pla_descricao, int pla_tipo, string pla_natureza )
                            {
                                return Create(null, pla_id, pla_codigo, pla_descricao, pla_tipo, pla_natureza);
                            }

                            public IPlanocontasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int pla_id, string pla_codigo, string pla_descricao, int pla_tipo, string pla_natureza )
                            {
                            var entity = new PlanocontasEntity(pla_id, pla_codigo, pla_descricao, pla_tipo, pla_natureza );


                            var trackingMask = _trackingPolicy?.GetMask("Planocontas", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlanocontasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration