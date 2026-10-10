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
                                public class AlbumFotoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public AlbumFotoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public AlbumFotoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IAlbumFotoEntity Create(int? id, int albumid, int fotoid, int ordem, string? legenda )
                            {
                                return Create(null, id, albumid, fotoid, ordem, legenda);
                            }

                            public IAlbumFotoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int albumid, int fotoid, int ordem, string? legenda )
                            {
                            var entity = new AlbumFotoEntity(id, albumid, fotoid, ordem, legenda );


                            var trackingMask = _trackingPolicy?.GetMask("AlbumFoto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new AlbumFotoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration