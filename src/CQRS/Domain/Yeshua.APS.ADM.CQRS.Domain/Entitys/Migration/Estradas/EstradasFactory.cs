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
                                public class EstradasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EstradasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EstradasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEstradasEntity Create(int? id, int est_id, string est_descricao, int? est_id_ligacao_ponto_a, int? est_id_ligacao_ponto_b )
                            {
                                return Create(null, id, est_id, est_descricao, est_id_ligacao_ponto_a, est_id_ligacao_ponto_b);
                            }

                            public IEstradasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int est_id, string est_descricao, int? est_id_ligacao_ponto_a, int? est_id_ligacao_ponto_b )
                            {
                            var entity = new EstradasEntity(id, est_id, est_descricao, est_id_ligacao_ponto_a, est_id_ligacao_ponto_b );


                            var trackingMask = _trackingPolicy?.GetMask("Estradas", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EstradasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration