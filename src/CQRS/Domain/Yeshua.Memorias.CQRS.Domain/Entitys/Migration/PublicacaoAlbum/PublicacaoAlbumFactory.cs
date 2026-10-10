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
                                public class PublicacaoAlbumFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PublicacaoAlbumFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PublicacaoAlbumFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPublicacaoAlbumEntity Create(int? id, int albumid, string correlationid, string? manifeststoragekey, string? videostoragekey, string? youtubevideoid, string? youtubeurl, string? mensagem, DateTime solicitadaemutc, DateTime? publicadaemutc, int status )
                            {
                                return Create(null, id, albumid, correlationid, manifeststoragekey, videostoragekey, youtubevideoid, youtubeurl, mensagem, solicitadaemutc, publicadaemutc, status);
                            }

                            public IPublicacaoAlbumEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int albumid, string correlationid, string? manifeststoragekey, string? videostoragekey, string? youtubevideoid, string? youtubeurl, string? mensagem, DateTime solicitadaemutc, DateTime? publicadaemutc, int status )
                            {
                            var entity = new PublicacaoAlbumEntity(id, albumid, correlationid, manifeststoragekey, videostoragekey, youtubevideoid, youtubeurl, mensagem, solicitadaemutc, publicadaemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("PublicacaoAlbum", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PublicacaoAlbumDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration