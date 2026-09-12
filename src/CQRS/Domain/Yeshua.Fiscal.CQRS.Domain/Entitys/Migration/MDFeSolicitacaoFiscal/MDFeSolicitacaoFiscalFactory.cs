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
                                public class MDFeSolicitacaoFiscalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeSolicitacaoFiscalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeSolicitacaoFiscalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeSolicitacaoFiscalEntity Create(int? id, string correlationid, string? cargaid, int ambiente, string ufcarregamento, string ufdescarregamento, string? placaveiculo, string? condutordocumento, string? documentosoriginariosjson, string? transportesnapshotjson, int status )
                            {
                                return Create(null, id, correlationid, cargaid, ambiente, ufcarregamento, ufdescarregamento, placaveiculo, condutordocumento, documentosoriginariosjson, transportesnapshotjson, status);
                            }

                            public IMDFeSolicitacaoFiscalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string correlationid, string? cargaid, int ambiente, string ufcarregamento, string ufdescarregamento, string? placaveiculo, string? condutordocumento, string? documentosoriginariosjson, string? transportesnapshotjson, int status )
                            {
                            var entity = new MDFeSolicitacaoFiscalEntity(id, correlationid, cargaid, ambiente, ufcarregamento, ufdescarregamento, placaveiculo, condutordocumento, documentosoriginariosjson, transportesnapshotjson, status );


                            var trackingMask = _trackingPolicy?.GetMask("MDFeSolicitacaoFiscal", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeSolicitacaoFiscalDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration