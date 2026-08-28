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
                                public class TemplateTipoTesteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TemplateTipoTesteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TemplateTipoTesteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITemplateTipoTesteEntity Create(int ttt_id, int tt_id, int tem_id )
                            {
                                return Create(null, ttt_id, tt_id, tem_id);
                            }

                            public ITemplateTipoTesteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int ttt_id, int tt_id, int tem_id )
                            {
                            var entity = new TemplateTipoTesteEntity(ttt_id, tt_id, tem_id );


                            var trackingMask = _trackingPolicy?.GetMask("TemplateTipoTeste", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TemplateTipoTesteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration