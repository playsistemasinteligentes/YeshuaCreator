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
                                public class T_PREFERENCIASFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_PREFERENCIASFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_PREFERENCIASFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_PREFERENCIASEntity Create(int? id, int pre_id, string pre_descricao, string pre_namespace, string pre_tipo, string pre_valor, int? use_id, int? per_id )
                            {
                                return Create(null, id, pre_id, pre_descricao, pre_namespace, pre_tipo, pre_valor, use_id, per_id);
                            }

                            public IT_PREFERENCIASEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int pre_id, string pre_descricao, string pre_namespace, string pre_tipo, string pre_valor, int? use_id, int? per_id )
                            {
                            var entity = new T_PREFERENCIASEntity(id, pre_id, pre_descricao, pre_namespace, pre_tipo, pre_valor, use_id, per_id );


                            var trackingMask = _trackingPolicy?.GetMask("T_PREFERENCIAS", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_PREFERENCIASDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration