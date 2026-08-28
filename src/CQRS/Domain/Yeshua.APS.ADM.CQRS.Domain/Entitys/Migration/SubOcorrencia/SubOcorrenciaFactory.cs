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
                                public class SubOcorrenciaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public SubOcorrenciaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public SubOcorrenciaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ISubOcorrenciaEntity Create(int? id, string sub_id, string sub_descricao )
                            {
                                return Create(null, id, sub_id, sub_descricao);
                            }

                            public ISubOcorrenciaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string sub_id, string sub_descricao )
                            {
                            var entity = new SubOcorrenciaEntity(id, sub_id, sub_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("SubOcorrencia", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new SubOcorrenciaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration