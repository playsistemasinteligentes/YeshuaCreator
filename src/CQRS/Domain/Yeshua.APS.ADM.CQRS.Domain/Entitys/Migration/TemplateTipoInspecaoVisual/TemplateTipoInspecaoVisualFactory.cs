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
                                public class TemplateTipoInspecaoVisualFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TemplateTipoInspecaoVisualFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TemplateTipoInspecaoVisualFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITemplateTipoInspecaoVisualEntity Create(int tti_id, int? tiv_id, int? tem_id )
                            {
                                return Create(null, tti_id, tiv_id, tem_id);
                            }

                            public ITemplateTipoInspecaoVisualEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int tti_id, int? tiv_id, int? tem_id )
                            {
                            var entity = new TemplateTipoInspecaoVisualEntity(tti_id, tiv_id, tem_id );


                            var trackingMask = _trackingPolicy?.GetMask("TemplateTipoInspecaoVisual", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TemplateTipoInspecaoVisualDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration