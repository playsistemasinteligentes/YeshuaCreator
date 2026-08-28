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
                                public class TempoSetupOnduladeiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TempoSetupOnduladeiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TempoSetupOnduladeiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITempoSetupOnduladeiraEntity Create(int tem_id, string ond_id_de, string ond_id_para, string tem_resina_de, string tem_resina_para, int? tem_tempo )
                            {
                                return Create(null, tem_id, ond_id_de, ond_id_para, tem_resina_de, tem_resina_para, tem_tempo);
                            }

                            public ITempoSetupOnduladeiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int tem_id, string ond_id_de, string ond_id_para, string tem_resina_de, string tem_resina_para, int? tem_tempo )
                            {
                            var entity = new TempoSetupOnduladeiraEntity(tem_id, ond_id_de, ond_id_para, tem_resina_de, tem_resina_para, tem_tempo );


                            var trackingMask = _trackingPolicy?.GetMask("TempoSetupOnduladeira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TempoSetupOnduladeiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration