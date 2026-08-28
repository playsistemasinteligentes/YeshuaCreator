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
                                public class ItensCalendarioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItensCalendarioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItensCalendarioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItensCalendarioEntity Create(int ica_id, DateTime ica_data_de, DateTime ica_data_ate, string ica_observacao, int ica_tipo, string urm_id, string urn_id, int cal_id, string maq_id, string pro_id, int? ica_limpesa_maquina )
                            {
                                return Create(null, ica_id, ica_data_de, ica_data_ate, ica_observacao, ica_tipo, urm_id, urn_id, cal_id, maq_id, pro_id, ica_limpesa_maquina);
                            }

                            public IItensCalendarioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int ica_id, DateTime ica_data_de, DateTime ica_data_ate, string ica_observacao, int ica_tipo, string urm_id, string urn_id, int cal_id, string maq_id, string pro_id, int? ica_limpesa_maquina )
                            {
                            var entity = new ItensCalendarioEntity(ica_id, ica_data_de, ica_data_ate, ica_observacao, ica_tipo, urm_id, urn_id, cal_id, maq_id, pro_id, ica_limpesa_maquina );


                            var trackingMask = _trackingPolicy?.GetMask("ItensCalendario", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItensCalendarioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration