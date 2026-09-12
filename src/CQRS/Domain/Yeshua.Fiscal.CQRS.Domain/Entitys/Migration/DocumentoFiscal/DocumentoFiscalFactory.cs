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
                                public class DocumentoFiscalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public DocumentoFiscalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public DocumentoFiscalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IDocumentoFiscalEntity Create(int? id, string correlationid, int produtofiscal, string? chaveacesso, int? serie, int? numero, int ambiente, string? ufemitente, string? emitentedocumento, string? destinatariodocumento, string? xmlstoragekey, string? xmlhash, string? protocoloautorizacao, string? codigoretorno, string? mensagemretorno, int status )
                            {
                                return Create(null, id, correlationid, produtofiscal, chaveacesso, serie, numero, ambiente, ufemitente, emitentedocumento, destinatariodocumento, xmlstoragekey, xmlhash, protocoloautorizacao, codigoretorno, mensagemretorno, status);
                            }

                            public IDocumentoFiscalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string correlationid, int produtofiscal, string? chaveacesso, int? serie, int? numero, int ambiente, string? ufemitente, string? emitentedocumento, string? destinatariodocumento, string? xmlstoragekey, string? xmlhash, string? protocoloautorizacao, string? codigoretorno, string? mensagemretorno, int status )
                            {
                            var entity = new DocumentoFiscalEntity(id, correlationid, produtofiscal, chaveacesso, serie, numero, ambiente, ufemitente, emitentedocumento, destinatariodocumento, xmlstoragekey, xmlhash, protocoloautorizacao, codigoretorno, mensagemretorno, status );


                            var trackingMask = _trackingPolicy?.GetMask("DocumentoFiscal", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new DocumentoFiscalDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration