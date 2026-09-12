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
                                public class EntradaFiscalContingenciaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EntradaFiscalContingenciaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EntradaFiscalContingenciaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEntradaFiscalContingenciaEntity Create(int? id, string correlationid, string cargaid, int tiposolicitante, int ambiente, string sourceapplication, string? sourcemodule, string sourcemessageid, string? emitentefiscaldocumento, string? tomadordocumento, string? transportadordocumento, string? remetentedocumento, string? destinatariodocumento, string? ufinicio, string? uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, string? rntrc, string? placaveiculo, string? ufveiculo, string? condutordocumento, string? condutornome, int? quantidadedocumentos, Decimal? valorcarga, Decimal? pesobruto, Decimal? volume, string? pendenciasjson, string? snapshotjson, string? emissaofiscalcorrelationid, int? emissaofiscalsagaid, DateTime criadoemutc, DateTime? atualizadoemutc, int status )
                            {
                                return Create(null, id, correlationid, cargaid, tiposolicitante, ambiente, sourceapplication, sourcemodule, sourcemessageid, emitentefiscaldocumento, tomadordocumento, transportadordocumento, remetentedocumento, destinatariodocumento, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, rntrc, placaveiculo, ufveiculo, condutordocumento, condutornome, quantidadedocumentos, valorcarga, pesobruto, volume, pendenciasjson, snapshotjson, emissaofiscalcorrelationid, emissaofiscalsagaid, criadoemutc, atualizadoemutc, status);
                            }

                            public IEntradaFiscalContingenciaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string correlationid, string cargaid, int tiposolicitante, int ambiente, string sourceapplication, string? sourcemodule, string sourcemessageid, string? emitentefiscaldocumento, string? tomadordocumento, string? transportadordocumento, string? remetentedocumento, string? destinatariodocumento, string? ufinicio, string? uffim, string? municipioiniciocodigoibge, string? municipiofimcodigoibge, string? rntrc, string? placaveiculo, string? ufveiculo, string? condutordocumento, string? condutornome, int? quantidadedocumentos, Decimal? valorcarga, Decimal? pesobruto, Decimal? volume, string? pendenciasjson, string? snapshotjson, string? emissaofiscalcorrelationid, int? emissaofiscalsagaid, DateTime criadoemutc, DateTime? atualizadoemutc, int status )
                            {
                            var entity = new EntradaFiscalContingenciaEntity(id, correlationid, cargaid, tiposolicitante, ambiente, sourceapplication, sourcemodule, sourcemessageid, emitentefiscaldocumento, tomadordocumento, transportadordocumento, remetentedocumento, destinatariodocumento, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, rntrc, placaveiculo, ufveiculo, condutordocumento, condutornome, quantidadedocumentos, valorcarga, pesobruto, volume, pendenciasjson, snapshotjson, emissaofiscalcorrelationid, emissaofiscalsagaid, criadoemutc, atualizadoemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("EntradaFiscalContingencia", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EntradaFiscalContingenciaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration