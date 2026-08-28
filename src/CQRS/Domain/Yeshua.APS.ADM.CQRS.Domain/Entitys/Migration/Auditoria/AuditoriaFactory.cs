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
                                public class AuditoriaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public AuditoriaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public AuditoriaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IAuditoriaEntity Create(int id, DateTime data, int use_id, string rotina, string historico, string chave )
                            {
                                return Create(null, id, data, use_id, rotina, historico, chave);
                            }

                            public IAuditoriaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id, DateTime data, int use_id, string rotina, string historico, string chave )
                            {
                            var entity = new AuditoriaEntity(id, data, use_id, rotina, historico, chave );


                            var trackingMask = _trackingPolicy?.GetMask("Auditoria", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new AuditoriaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration