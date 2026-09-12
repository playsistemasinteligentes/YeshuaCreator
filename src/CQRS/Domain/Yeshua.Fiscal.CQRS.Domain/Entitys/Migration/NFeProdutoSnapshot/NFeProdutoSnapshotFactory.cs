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
                                public class NFeProdutoSnapshotFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public NFeProdutoSnapshotFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public NFeProdutoSnapshotFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public INFeProdutoSnapshotEntity Create(int? id, int? documentofiscaloriginarioid, string correlationid, string? cargaid, string? pedidoid, string chaveacesso, string? emitentedocumento, string? destinatariodocumento, string? uforigem, string? ufdestino, string? municipioorigemcodigoibge, string? municipiodestinocodigoibge, Decimal? valordocumento, Decimal? pesobruto, Decimal? volume, string? xmlstoragekey, string? snapshotjson, int status )
                            {
                                return Create(null, id, documentofiscaloriginarioid, correlationid, cargaid, pedidoid, chaveacesso, emitentedocumento, destinatariodocumento, uforigem, ufdestino, municipioorigemcodigoibge, municipiodestinocodigoibge, valordocumento, pesobruto, volume, xmlstoragekey, snapshotjson, status);
                            }

                            public INFeProdutoSnapshotEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? documentofiscaloriginarioid, string correlationid, string? cargaid, string? pedidoid, string chaveacesso, string? emitentedocumento, string? destinatariodocumento, string? uforigem, string? ufdestino, string? municipioorigemcodigoibge, string? municipiodestinocodigoibge, Decimal? valordocumento, Decimal? pesobruto, Decimal? volume, string? xmlstoragekey, string? snapshotjson, int status )
                            {
                            var entity = new NFeProdutoSnapshotEntity(id, documentofiscaloriginarioid, correlationid, cargaid, pedidoid, chaveacesso, emitentedocumento, destinatariodocumento, uforigem, ufdestino, municipioorigemcodigoibge, municipiodestinocodigoibge, valordocumento, pesobruto, volume, xmlstoragekey, snapshotjson, status );


                            var trackingMask = _trackingPolicy?.GetMask("NFeProdutoSnapshot", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new NFeProdutoSnapshotDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration