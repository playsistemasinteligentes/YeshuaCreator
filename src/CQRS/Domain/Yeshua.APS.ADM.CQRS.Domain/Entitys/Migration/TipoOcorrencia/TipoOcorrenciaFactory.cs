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
                                public class TipoOcorrenciaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoOcorrenciaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoOcorrenciaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoOcorrenciaEntity Create(int id, string descricao, int? spr )
                            {
                                return Create(null, id, descricao, spr);
                            }

                            public ITipoOcorrenciaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id, string descricao, int? spr )
                            {
                            var entity = new TipoOcorrenciaEntity(id, descricao, spr );


                            var trackingMask = _trackingPolicy?.GetMask("TipoOcorrencia", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoOcorrenciaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration