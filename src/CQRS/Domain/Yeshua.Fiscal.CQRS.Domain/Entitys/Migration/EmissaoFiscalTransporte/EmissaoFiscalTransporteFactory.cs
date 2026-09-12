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
                                public class EmissaoFiscalTransporteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EmissaoFiscalTransporteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EmissaoFiscalTransporteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEmissaoFiscalTransporteEntity Create(int? id, string correlationid, int origemfluxo, string? cargaid, string? romaneioid, int ambiente, string? emitentedocumento, string? tomadordocumento, string? transportadordocumento, string? ufinicio, string? uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, int? quantidadenfe, int? quantidadecte, int? quantidademdfe, Decimal? valorcarga, Decimal? pesobruto, Decimal? volume, string? ultimamensagem, DateTime criadoemutc, DateTime? atualizadoemutc, DateTime? concluidoemutc, int status )
                            {
                                return Create(null, id, correlationid, origemfluxo, cargaid, romaneioid, ambiente, emitentedocumento, tomadordocumento, transportadordocumento, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, quantidadenfe, quantidadecte, quantidademdfe, valorcarga, pesobruto, volume, ultimamensagem, criadoemutc, atualizadoemutc, concluidoemutc, status);
                            }

                            public IEmissaoFiscalTransporteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string correlationid, int origemfluxo, string? cargaid, string? romaneioid, int ambiente, string? emitentedocumento, string? tomadordocumento, string? transportadordocumento, string? ufinicio, string? uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, int? quantidadenfe, int? quantidadecte, int? quantidademdfe, Decimal? valorcarga, Decimal? pesobruto, Decimal? volume, string? ultimamensagem, DateTime criadoemutc, DateTime? atualizadoemutc, DateTime? concluidoemutc, int status )
                            {
                            var entity = new EmissaoFiscalTransporteEntity(id, correlationid, origemfluxo, cargaid, romaneioid, ambiente, emitentedocumento, tomadordocumento, transportadordocumento, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, quantidadenfe, quantidadecte, quantidademdfe, valorcarga, pesobruto, volume, ultimamensagem, criadoemutc, atualizadoemutc, concluidoemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("EmissaoFiscalTransporte", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EmissaoFiscalTransporteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration