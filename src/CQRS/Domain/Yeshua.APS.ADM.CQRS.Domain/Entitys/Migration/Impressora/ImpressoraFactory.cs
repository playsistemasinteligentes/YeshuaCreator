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
                                public class ImpressoraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ImpressoraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ImpressoraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IImpressoraEntity Create(int imp_id, string imp_ip, string imp_nome )
                            {
                                return Create(null, imp_id, imp_ip, imp_nome);
                            }

                            public IImpressoraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int imp_id, string imp_ip, string imp_nome )
                            {
                            var entity = new ImpressoraEntity(imp_id, imp_ip, imp_nome );


                            var trackingMask = _trackingPolicy?.GetMask("Impressora", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ImpressoraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration