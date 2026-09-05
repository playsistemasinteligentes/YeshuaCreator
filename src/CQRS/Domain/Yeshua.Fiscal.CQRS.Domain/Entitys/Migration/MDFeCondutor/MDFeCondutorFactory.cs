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
                                public class MDFeCondutorFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeCondutorFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeCondutorFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeCondutorEntity Create(int? id, int mdfesolicitacaofiscalid, string nome, string documento )
                            {
                                return Create(null, id, mdfesolicitacaofiscalid, nome, documento);
                            }

                            public IMDFeCondutorEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdfesolicitacaofiscalid, string nome, string documento )
                            {
                            var entity = new MDFeCondutorEntity(id, mdfesolicitacaofiscalid, nome, documento );


                            var trackingMask = _trackingPolicy?.GetMask("MDFeCondutor", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeCondutorDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration