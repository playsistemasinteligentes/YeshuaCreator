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
                                public class OcorrenciaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OcorrenciaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OcorrenciaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOcorrenciaEntity Create(string oco_id, string oco_descricao, int tip_id, string gma_id, string maq_id, int? spr, string oco_sub_tipo, string sub_id )
                            {
                                return Create(null, oco_id, oco_descricao, tip_id, gma_id, maq_id, spr, oco_sub_tipo, sub_id);
                            }

                            public IOcorrenciaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string oco_id, string oco_descricao, int tip_id, string gma_id, string maq_id, int? spr, string oco_sub_tipo, string sub_id )
                            {
                            var entity = new OcorrenciaEntity(oco_id, oco_descricao, tip_id, gma_id, maq_id, spr, oco_sub_tipo, sub_id );


                            var trackingMask = _trackingPolicy?.GetMask("Ocorrencia", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OcorrenciaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration