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
                                public class AlbumFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public AlbumFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public AlbumFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IAlbumEntity Create(int? id, string titulo, string? descricao, int privacidade, int segundosporfoto, int status )
                            {
                                return Create(null, id, titulo, descricao, privacidade, segundosporfoto, status);
                            }

                            public IAlbumEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string titulo, string? descricao, int privacidade, int segundosporfoto, int status )
                            {
                            var entity = new AlbumEntity(id, titulo, descricao, privacidade, segundosporfoto, status );


                            var trackingMask = _trackingPolicy?.GetMask("Album", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new AlbumDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration