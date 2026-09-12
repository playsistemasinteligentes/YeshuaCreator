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
                                public class CTeRomaneioConsolidadoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CTeRomaneioConsolidadoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CTeRomaneioConsolidadoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICTeRomaneioConsolidadoEntity Create(int? id, int entradaoficialid, string correlationid, string romaneioid, string? cargaid, DateTime consolidadoemutc, string ufinicio, string uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, string? emitentedocumento, string? tomadordocumento, string? rotasnapshotjson, string? cargasnapshotjson, string? preferenciasfiscaisjson, int status )
                            {
                                return Create(null, id, entradaoficialid, correlationid, romaneioid, cargaid, consolidadoemutc, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, emitentedocumento, tomadordocumento, rotasnapshotjson, cargasnapshotjson, preferenciasfiscaisjson, status);
                            }

                            public ICTeRomaneioConsolidadoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int entradaoficialid, string correlationid, string romaneioid, string? cargaid, DateTime consolidadoemutc, string ufinicio, string uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, string? emitentedocumento, string? tomadordocumento, string? rotasnapshotjson, string? cargasnapshotjson, string? preferenciasfiscaisjson, int status )
                            {
                            var entity = new CTeRomaneioConsolidadoEntity(id, entradaoficialid, correlationid, romaneioid, cargaid, consolidadoemutc, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, emitentedocumento, tomadordocumento, rotasnapshotjson, cargasnapshotjson, preferenciasfiscaisjson, status );


                            var trackingMask = _trackingPolicy?.GetMask("CTeRomaneioConsolidado", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CTeRomaneioConsolidadoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration