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
                                public class EmissaoFiscalTransporteDocumentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EmissaoFiscalTransporteDocumentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EmissaoFiscalTransporteDocumentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEmissaoFiscalTransporteDocumentoEntity Create(int? id, int emissaofiscaltransporteid, int? documentofiscalid, int? documentofiscaloriginarioid, int? nfeprodutosnapshotid, int produtofiscal, int papel, string? tipoevento, string? chaveacesso, string? xmlstoragekey, string? pdfstoragekey, string? protocolo, string? codigoretorno, string? mensagemretorno, DateTime criadoemutc, int status )
                            {
                                return Create(null, id, emissaofiscaltransporteid, documentofiscalid, documentofiscaloriginarioid, nfeprodutosnapshotid, produtofiscal, papel, tipoevento, chaveacesso, xmlstoragekey, pdfstoragekey, protocolo, codigoretorno, mensagemretorno, criadoemutc, status);
                            }

                            public IEmissaoFiscalTransporteDocumentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int emissaofiscaltransporteid, int? documentofiscalid, int? documentofiscaloriginarioid, int? nfeprodutosnapshotid, int produtofiscal, int papel, string? tipoevento, string? chaveacesso, string? xmlstoragekey, string? pdfstoragekey, string? protocolo, string? codigoretorno, string? mensagemretorno, DateTime criadoemutc, int status )
                            {
                            var entity = new EmissaoFiscalTransporteDocumentoEntity(id, emissaofiscaltransporteid, documentofiscalid, documentofiscaloriginarioid, nfeprodutosnapshotid, produtofiscal, papel, tipoevento, chaveacesso, xmlstoragekey, pdfstoragekey, protocolo, codigoretorno, mensagemretorno, criadoemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("EmissaoFiscalTransporteDocumento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EmissaoFiscalTransporteDocumentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration