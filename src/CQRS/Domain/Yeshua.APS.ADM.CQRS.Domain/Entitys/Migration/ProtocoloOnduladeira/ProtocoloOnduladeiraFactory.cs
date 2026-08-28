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
                                public class ProtocoloOnduladeiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ProtocoloOnduladeiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ProtocoloOnduladeiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IProtocoloOnduladeiraEntity Create(int? id, string pto_id, string pto_chave, string maq_id, string pto_comando )
                            {
                                return Create(null, id, pto_id, pto_chave, maq_id, pto_comando);
                            }

                            public IProtocoloOnduladeiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string pto_id, string pto_chave, string maq_id, string pto_comando )
                            {
                            var entity = new ProtocoloOnduladeiraEntity(id, pto_id, pto_chave, maq_id, pto_comando );


                            var trackingMask = _trackingPolicy?.GetMask("ProtocoloOnduladeira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ProtocoloOnduladeiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration