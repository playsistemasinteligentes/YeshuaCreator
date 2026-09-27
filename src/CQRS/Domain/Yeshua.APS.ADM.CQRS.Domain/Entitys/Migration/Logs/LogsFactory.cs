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
                                public class LogsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public LogsFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public LogsFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ILogsEntity Create(int? id, string? log_chave, string? log_contexto, string? log_conteudo, int log_id, DateTime? log_emissao )
                            {
                                return Create(null, id, log_chave, log_contexto, log_conteudo, log_id, log_emissao);
                            }

                            public ILogsEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string? log_chave, string? log_contexto, string? log_conteudo, int log_id, DateTime? log_emissao )
                            {
                            var entity = new LogsEntity(id, log_chave, log_contexto, log_conteudo, log_id, log_emissao );


                            var trackingMask = _trackingPolicy?.GetMask("Logs", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new LogsDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration