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
                                public class MedidasTesteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MedidasTesteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MedidasTesteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMedidasTesteEntity Create(int? id, int mdt_id, string mdt_desc, Decimal? mdt_valor_esperado, Decimal? mdt_encontrado, string uni_id )
                            {
                                return Create(null, id, mdt_id, mdt_desc, mdt_valor_esperado, mdt_encontrado, uni_id);
                            }

                            public IMedidasTesteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdt_id, string mdt_desc, Decimal? mdt_valor_esperado, Decimal? mdt_encontrado, string uni_id )
                            {
                            var entity = new MedidasTesteEntity(id, mdt_id, mdt_desc, mdt_valor_esperado, mdt_encontrado, uni_id );


                            var trackingMask = _trackingPolicy?.GetMask("MedidasTeste", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MedidasTesteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration