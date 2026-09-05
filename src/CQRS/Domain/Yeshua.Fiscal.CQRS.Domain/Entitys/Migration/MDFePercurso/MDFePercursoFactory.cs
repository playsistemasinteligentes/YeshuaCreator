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
                                public class MDFePercursoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFePercursoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFePercursoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFePercursoEntity Create(int? id, int mdfesolicitacaofiscalid, string uf, int ordem )
                            {
                                return Create(null, id, mdfesolicitacaofiscalid, uf, ordem);
                            }

                            public IMDFePercursoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdfesolicitacaofiscalid, string uf, int ordem )
                            {
                            var entity = new MDFePercursoEntity(id, mdfesolicitacaofiscalid, uf, ordem );


                            var trackingMask = _trackingPolicy?.GetMask("MDFePercurso", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFePercursoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration