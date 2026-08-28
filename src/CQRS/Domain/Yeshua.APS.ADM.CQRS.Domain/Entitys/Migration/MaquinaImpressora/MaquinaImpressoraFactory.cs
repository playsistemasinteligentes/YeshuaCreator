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
                                public class MaquinaImpressoraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MaquinaImpressoraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MaquinaImpressoraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMaquinaImpressoraEntity Create(int maq_imp_id, string maq_id, int imp_id, int mai_facao )
                            {
                                return Create(null, maq_imp_id, maq_id, imp_id, mai_facao);
                            }

                            public IMaquinaImpressoraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int maq_imp_id, string maq_id, int imp_id, int mai_facao )
                            {
                            var entity = new MaquinaImpressoraEntity(maq_imp_id, maq_id, imp_id, mai_facao );


                            var trackingMask = _trackingPolicy?.GetMask("MaquinaImpressora", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MaquinaImpressoraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration