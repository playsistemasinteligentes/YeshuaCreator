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
                                public class ContingenciaFiscalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ContingenciaFiscalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ContingenciaFiscalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IContingenciaFiscalEntity Create(int? id, int? emissaofiscaltransporteid, int? entradafiscalcontingenciaid, string correlationid, string cargaid, int tiposolicitante, int ambiente, string? emitentedocumento, string? tomadordocumento, string? transportadordocumento, int? quantidadedocumentos, int? quantidadecte, int? quantidademdfe, Decimal? valorcarga, Decimal? pesobruto, string? ultimamensagem, DateTime criadoemutc, DateTime? atualizadoemutc, DateTime? concluidoemutc, int status )
                            {
                                return Create(null, id, emissaofiscaltransporteid, entradafiscalcontingenciaid, correlationid, cargaid, tiposolicitante, ambiente, emitentedocumento, tomadordocumento, transportadordocumento, quantidadedocumentos, quantidadecte, quantidademdfe, valorcarga, pesobruto, ultimamensagem, criadoemutc, atualizadoemutc, concluidoemutc, status);
                            }

                            public IContingenciaFiscalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? emissaofiscaltransporteid, int? entradafiscalcontingenciaid, string correlationid, string cargaid, int tiposolicitante, int ambiente, string? emitentedocumento, string? tomadordocumento, string? transportadordocumento, int? quantidadedocumentos, int? quantidadecte, int? quantidademdfe, Decimal? valorcarga, Decimal? pesobruto, string? ultimamensagem, DateTime criadoemutc, DateTime? atualizadoemutc, DateTime? concluidoemutc, int status )
                            {
                            var entity = new ContingenciaFiscalEntity(id, emissaofiscaltransporteid, entradafiscalcontingenciaid, correlationid, cargaid, tiposolicitante, ambiente, emitentedocumento, tomadordocumento, transportadordocumento, quantidadedocumentos, quantidadecte, quantidademdfe, valorcarga, pesobruto, ultimamensagem, criadoemutc, atualizadoemutc, concluidoemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("ContingenciaFiscal", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ContingenciaFiscalDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration