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
                                public class DocumentoFiscalOriginarioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public DocumentoFiscalOriginarioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public DocumentoFiscalOriginarioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IDocumentoFiscalOriginarioEntity Create(int? id, int? documentofiscalid, string correlationid, string sourceapplication, string sourcemodule, string sourcemessageid, string tipodocumento, string chaveacesso, string numero, string serie, string emitentedocumento, string destinatariodocumento, Decimal? valordocumento, Decimal? pesobruto, Decimal? volume, string snapshotjson, int status )
                            {
                                return Create(null, id, documentofiscalid, correlationid, sourceapplication, sourcemodule, sourcemessageid, tipodocumento, chaveacesso, numero, serie, emitentedocumento, destinatariodocumento, valordocumento, pesobruto, volume, snapshotjson, status);
                            }

                            public IDocumentoFiscalOriginarioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? documentofiscalid, string correlationid, string sourceapplication, string sourcemodule, string sourcemessageid, string tipodocumento, string chaveacesso, string numero, string serie, string emitentedocumento, string destinatariodocumento, Decimal? valordocumento, Decimal? pesobruto, Decimal? volume, string snapshotjson, int status )
                            {
                            var entity = new DocumentoFiscalOriginarioEntity(id, documentofiscalid, correlationid, sourceapplication, sourcemodule, sourcemessageid, tipodocumento, chaveacesso, numero, serie, emitentedocumento, destinatariodocumento, valordocumento, pesobruto, volume, snapshotjson, status );


                            var trackingMask = _trackingPolicy?.GetMask("DocumentoFiscalOriginario", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new DocumentoFiscalOriginarioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration