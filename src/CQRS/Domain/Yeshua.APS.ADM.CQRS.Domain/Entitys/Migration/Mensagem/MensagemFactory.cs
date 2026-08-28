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
                                public class MensagemFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MensagemFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MensagemFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMensagemEntity Create(string men_id, string men_send, DateTime? men_emission, string men_status, string men_receive, string men_type, Decimal? men_qtd_try_send, DateTime? men_date_try_send )
                            {
                                return Create(null, men_id, men_send, men_emission, men_status, men_receive, men_type, men_qtd_try_send, men_date_try_send);
                            }

                            public IMensagemEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string men_id, string men_send, DateTime? men_emission, string men_status, string men_receive, string men_type, Decimal? men_qtd_try_send, DateTime? men_date_try_send )
                            {
                            var entity = new MensagemEntity(men_id, men_send, men_emission, men_status, men_receive, men_type, men_qtd_try_send, men_date_try_send );


                            var trackingMask = _trackingPolicy?.GetMask("Mensagem", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MensagemDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration