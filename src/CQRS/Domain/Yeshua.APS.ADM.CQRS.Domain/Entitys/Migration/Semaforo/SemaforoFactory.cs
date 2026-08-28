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
                                public class SemaforoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public SemaforoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public SemaforoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ISemaforoEntity Create(int? id, string sem_id, string sem_status, string sem_origem, DateTime? sem_emissao, string sem_id_conexao )
                            {
                                return Create(null, id, sem_id, sem_status, sem_origem, sem_emissao, sem_id_conexao);
                            }

                            public ISemaforoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string sem_id, string sem_status, string sem_origem, DateTime? sem_emissao, string sem_id_conexao )
                            {
                            var entity = new SemaforoEntity(id, sem_id, sem_status, sem_origem, sem_emissao, sem_id_conexao );


                            var trackingMask = _trackingPolicy?.GetMask("Semaforo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new SemaforoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration