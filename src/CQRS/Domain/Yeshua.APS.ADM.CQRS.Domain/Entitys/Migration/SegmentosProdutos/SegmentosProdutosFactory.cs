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
                                public class SegmentosProdutosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public SegmentosProdutosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public SegmentosProdutosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ISegmentosProdutosEntity Create(int? id, string grs_id, string pro_id, string seg_id )
                            {
                                return Create(null, id, grs_id, pro_id, seg_id);
                            }

                            public ISegmentosProdutosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string grs_id, string pro_id, string seg_id )
                            {
                            var entity = new SegmentosProdutosEntity(id, grs_id, pro_id, seg_id );


                            var trackingMask = _trackingPolicy?.GetMask("SegmentosProdutos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new SegmentosProdutosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration