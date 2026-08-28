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
                                public class InspecaoVisualFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public InspecaoVisualFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public InspecaoVisualFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IInspecaoVisualEntity Create(int ipv_id, string ipv_valor, int? ipv_id_operador, int? ipv_id_liberacao, string ipv_obs, DateTime? ipv_data_coleta, DateTime? ipv_data_aval, int? tiv_id, string turn_id, string turm_id, string ord_id, string rot_pro_id, string rot_maq_id, int? rot_seq_transformacao, int? fpr_seq_repeticao, string ipv_status_liberacao, Decimal? ipv_valor_medida )
                            {
                                return Create(null, ipv_id, ipv_valor, ipv_id_operador, ipv_id_liberacao, ipv_obs, ipv_data_coleta, ipv_data_aval, tiv_id, turn_id, turm_id, ord_id, rot_pro_id, rot_maq_id, rot_seq_transformacao, fpr_seq_repeticao, ipv_status_liberacao, ipv_valor_medida);
                            }

                            public IInspecaoVisualEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int ipv_id, string ipv_valor, int? ipv_id_operador, int? ipv_id_liberacao, string ipv_obs, DateTime? ipv_data_coleta, DateTime? ipv_data_aval, int? tiv_id, string turn_id, string turm_id, string ord_id, string rot_pro_id, string rot_maq_id, int? rot_seq_transformacao, int? fpr_seq_repeticao, string ipv_status_liberacao, Decimal? ipv_valor_medida )
                            {
                            var entity = new InspecaoVisualEntity(ipv_id, ipv_valor, ipv_id_operador, ipv_id_liberacao, ipv_obs, ipv_data_coleta, ipv_data_aval, tiv_id, turn_id, turm_id, ord_id, rot_pro_id, rot_maq_id, rot_seq_transformacao, fpr_seq_repeticao, ipv_status_liberacao, ipv_valor_medida );


                            var trackingMask = _trackingPolicy?.GetMask("InspecaoVisual", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new InspecaoVisualDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration