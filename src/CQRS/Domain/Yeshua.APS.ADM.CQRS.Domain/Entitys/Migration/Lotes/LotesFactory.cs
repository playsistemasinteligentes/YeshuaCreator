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
                                public class LotesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public LotesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public LotesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ILotesEntity Create(int? id, string mov_lote, string mov_sub_lote, Decimal? lot_largura, Decimal? lot_comprimento, Decimal? lot_diametro )
                            {
                                return Create(null, id, mov_lote, mov_sub_lote, lot_largura, lot_comprimento, lot_diametro);
                            }

                            public ILotesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string mov_lote, string mov_sub_lote, Decimal? lot_largura, Decimal? lot_comprimento, Decimal? lot_diametro )
                            {
                            var entity = new LotesEntity(id, mov_lote, mov_sub_lote, lot_largura, lot_comprimento, lot_diametro );


                            var trackingMask = _trackingPolicy?.GetMask("Lotes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new LotesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration