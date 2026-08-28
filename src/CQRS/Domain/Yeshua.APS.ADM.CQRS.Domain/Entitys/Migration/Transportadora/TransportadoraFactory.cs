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
                                public class TransportadoraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TransportadoraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TransportadoraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITransportadoraEntity Create(int? id, string tra_id, string tra_nome, string tra_email, string tra_responsavel, string tra_fone, string tra_id_integracao, string tra_id_integracao_erp )
                            {
                                return Create(null, id, tra_id, tra_nome, tra_email, tra_responsavel, tra_fone, tra_id_integracao, tra_id_integracao_erp);
                            }

                            public ITransportadoraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string tra_id, string tra_nome, string tra_email, string tra_responsavel, string tra_fone, string tra_id_integracao, string tra_id_integracao_erp )
                            {
                            var entity = new TransportadoraEntity(id, tra_id, tra_nome, tra_email, tra_responsavel, tra_fone, tra_id_integracao, tra_id_integracao_erp );


                            var trackingMask = _trackingPolicy?.GetMask("Transportadora", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TransportadoraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration