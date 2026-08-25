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
                                public class MaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMaquinaEntity Create(string maq_id, string maq_descricao, string maq_status )
                            {
                                return Create(null, maq_id, maq_descricao, maq_status);
                            }

                            public IMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string maq_id, string maq_descricao, string maq_status )
                            {
                            var entity = new MaquinaEntity(maq_id, maq_descricao, maq_status );


                            var trackingMask = _trackingPolicy?.GetMask("Maquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration