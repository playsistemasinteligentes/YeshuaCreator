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
                                public class T_GrupoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_GrupoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_GrupoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_GrupoEntity Create(int gru_id, string nome, int exibelista, string gru_descricao )
                            {
                                return Create(null, gru_id, nome, exibelista, gru_descricao);
                            }

                            public IT_GrupoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int gru_id, string nome, int exibelista, string gru_descricao )
                            {
                            var entity = new T_GrupoEntity(gru_id, nome, exibelista, gru_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("T_Grupo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_GrupoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration