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
                                public class ChamadoSuporteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ChamadoSuporteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ChamadoSuporteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IChamadoSuporteEntity Create(string? id, string aplicativo, string? modulo, string? tela, string? titulotela, string? rota, string? caminho, string versao, string? fusohorario, string? momentoclienteutc, string? assunto, string? descricao, int status, DateTime criadoemutc, DateTime? abertoemutc )
                            {
                                return Create(null, id, aplicativo, modulo, tela, titulotela, rota, caminho, versao, fusohorario, momentoclienteutc, assunto, descricao, status, criadoemutc, abertoemutc);
                            }

                            public IChamadoSuporteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string aplicativo, string? modulo, string? tela, string? titulotela, string? rota, string? caminho, string versao, string? fusohorario, string? momentoclienteutc, string? assunto, string? descricao, int status, DateTime criadoemutc, DateTime? abertoemutc, ulong? trackingMask = null )
                            {
                            var entity = new ChamadoSuporteEntity(id, aplicativo, modulo, tela, titulotela, rota, caminho, versao, fusohorario, momentoclienteutc, assunto, descricao, status, criadoemutc, abertoemutc );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("ChamadoSuporte", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ChamadoSuporteDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration