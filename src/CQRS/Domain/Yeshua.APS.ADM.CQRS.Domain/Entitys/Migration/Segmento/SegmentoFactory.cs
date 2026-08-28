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
                                public class SegmentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public SegmentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public SegmentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ISegmentoEntity Create(int? id, string seg_id, string seg_descricao, string seg_id_seguimento_pai, string grs_id, string seg_integracao_erp )
                            {
                                return Create(null, id, seg_id, seg_descricao, seg_id_seguimento_pai, grs_id, seg_integracao_erp);
                            }

                            public ISegmentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string seg_id, string seg_descricao, string seg_id_seguimento_pai, string grs_id, string seg_integracao_erp )
                            {
                            var entity = new SegmentoEntity(id, seg_id, seg_descricao, seg_id_seguimento_pai, grs_id, seg_integracao_erp );


                            var trackingMask = _trackingPolicy?.GetMask("Segmento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new SegmentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration