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
                                public class CTeSolicitacaoFiscalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CTeSolicitacaoFiscalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CTeSolicitacaoFiscalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICTeSolicitacaoFiscalEntity Create(int? id, int? entradaoficialid, int? romaneioconsolidadoid, string correlationid, int ambiente, string ufemitente, string emitentedocumento, int produtofiscal, int tipocte, int tiposervico, int modal, int globalizado, string ufinicio, string uffim, string municipioiniciocodigoibge, string municipiofimcodigoibge, Decimal? valorservico, Decimal? valorcarga, string preferenciasmanifestojson, int status )
                            {
                                return Create(null, id, entradaoficialid, romaneioconsolidadoid, correlationid, ambiente, ufemitente, emitentedocumento, produtofiscal, tipocte, tiposervico, modal, globalizado, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, valorservico, valorcarga, preferenciasmanifestojson, status);
                            }

                            public ICTeSolicitacaoFiscalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? entradaoficialid, int? romaneioconsolidadoid, string correlationid, int ambiente, string ufemitente, string emitentedocumento, int produtofiscal, int tipocte, int tiposervico, int modal, int globalizado, string ufinicio, string uffim, string municipioiniciocodigoibge, string municipiofimcodigoibge, Decimal? valorservico, Decimal? valorcarga, string preferenciasmanifestojson, int status )
                            {
                            var entity = new CTeSolicitacaoFiscalEntity(id, entradaoficialid, romaneioconsolidadoid, correlationid, ambiente, ufemitente, emitentedocumento, produtofiscal, tipocte, tiposervico, modal, globalizado, ufinicio, uffim, municipioiniciocodigoibge, municipiofimcodigoibge, valorservico, valorcarga, preferenciasmanifestojson, status );


                            var trackingMask = _trackingPolicy?.GetMask("CTeSolicitacaoFiscal", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CTeSolicitacaoFiscalDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration