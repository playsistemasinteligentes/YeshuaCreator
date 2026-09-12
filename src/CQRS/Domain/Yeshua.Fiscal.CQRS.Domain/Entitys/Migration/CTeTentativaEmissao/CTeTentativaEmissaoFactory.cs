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
                                public class CTeTentativaEmissaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CTeTentativaEmissaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CTeTentativaEmissaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICTeTentativaEmissaoEntity Create(int? id, int ctesolicitacaofiscalid, string? chaveacesso, int? numero, int? serie, int tentativa, string? xmlassinadostoragekey, string? xmlprocstoragekey, string? xmlhash, string? codigoretorno, string? mensagemretorno, string? protocoloautorizacao, DateTime? enviadoemutc, DateTime? autorizadoemutc, int status )
                            {
                                return Create(null, id, ctesolicitacaofiscalid, chaveacesso, numero, serie, tentativa, xmlassinadostoragekey, xmlprocstoragekey, xmlhash, codigoretorno, mensagemretorno, protocoloautorizacao, enviadoemutc, autorizadoemutc, status);
                            }

                            public ICTeTentativaEmissaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ctesolicitacaofiscalid, string? chaveacesso, int? numero, int? serie, int tentativa, string? xmlassinadostoragekey, string? xmlprocstoragekey, string? xmlhash, string? codigoretorno, string? mensagemretorno, string? protocoloautorizacao, DateTime? enviadoemutc, DateTime? autorizadoemutc, int status )
                            {
                            var entity = new CTeTentativaEmissaoEntity(id, ctesolicitacaofiscalid, chaveacesso, numero, serie, tentativa, xmlassinadostoragekey, xmlprocstoragekey, xmlhash, codigoretorno, mensagemretorno, protocoloautorizacao, enviadoemutc, autorizadoemutc, status );


                            var trackingMask = _trackingPolicy?.GetMask("CTeTentativaEmissao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CTeTentativaEmissaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration