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
                                public class T_DepartamentosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_DepartamentosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_DepartamentosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_DepartamentosEntity Create(int dep_id, string dep_nome )
                            {
                                return Create(null, dep_id, dep_nome);
                            }

                            public IT_DepartamentosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int dep_id, string dep_nome )
                            {
                            var entity = new T_DepartamentosEntity(dep_id, dep_nome );


                            var trackingMask = _trackingPolicy?.GetMask("T_Departamentos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_DepartamentosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration