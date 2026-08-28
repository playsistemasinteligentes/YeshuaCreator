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
                                public class LaudoTesteFisicoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public LaudoTesteFisicoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public LaudoTesteFisicoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ILaudoTesteFisicoEntity Create(int? id, int ltf_id, DateTime? ltf_emissao, Decimal? ltf_valor, string ltf_obs, string ltf_status, string ord_id, string rot_pro_id, int? fpr_seq_repeticao, int? use_id )
                            {
                                return Create(null, id, ltf_id, ltf_emissao, ltf_valor, ltf_obs, ltf_status, ord_id, rot_pro_id, fpr_seq_repeticao, use_id);
                            }

                            public ILaudoTesteFisicoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ltf_id, DateTime? ltf_emissao, Decimal? ltf_valor, string ltf_obs, string ltf_status, string ord_id, string rot_pro_id, int? fpr_seq_repeticao, int? use_id )
                            {
                            var entity = new LaudoTesteFisicoEntity(id, ltf_id, ltf_emissao, ltf_valor, ltf_obs, ltf_status, ord_id, rot_pro_id, fpr_seq_repeticao, use_id );


                            var trackingMask = _trackingPolicy?.GetMask("LaudoTesteFisico", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new LaudoTesteFisicoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration