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
                                public class MDFeTentativaEmissaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeTentativaEmissaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeTentativaEmissaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeTentativaEmissaoEntity Create(int? id, int mdfesolicitacaofiscalid, string? chaveacesso, int? numero, int? serie, int tentativa, string? xmlassinadostoragekey, string? xmlprocstoragekey, string? xmlhash, string? codigoretorno, string? mensagemretorno, string? protocoloautorizacao, DateTime? enviadoemutc, DateTime? autorizadoemutc, int status )
                            {
                                return Create(null, id, mdfesolicitacaofiscalid, chaveacesso, numero, serie, tentativa, xmlassinadostoragekey, xmlprocstoragekey, xmlhash, codigoretorno, mensagemretorno, protocoloautorizacao, enviadoemutc, autorizadoemutc, status);
                            }

                            public IMDFeTentativaEmissaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdfesolicitacaofiscalid, string? chaveacesso, int? numero, int? serie, int tentativa, string? xmlassinadostoragekey, string? xmlprocstoragekey, string? xmlhash, string? codigoretorno, string? mensagemretorno, string? protocoloautorizacao, DateTime? enviadoemutc, DateTime? autorizadoemutc, int status )
                            {
                            var entity = new MDFeTentativaEmissaoEntity(id, mdfesolicitacaofiscalid, chaveacesso, numero, serie, tentativa, xmlassinadostoragekey, xmlprocstoragekey, xmlhash, codigoretorno, mensagemretorno, protocoloautorizacao, enviadoemutc, autorizadoemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("MDFeTentativaEmissao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeTentativaEmissaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration