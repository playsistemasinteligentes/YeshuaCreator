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
                                public class EquipeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EquipeFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EquipeFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEquipeEntity Create(int? id, string equ_id, Decimal? equ_hierarquia_seq_transformacao )
                            {
                                return Create(null, id, equ_id, equ_hierarquia_seq_transformacao);
                            }

                            public IEquipeEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string equ_id, Decimal? equ_hierarquia_seq_transformacao )
                            {
                            var entity = new EquipeEntity(id, equ_id, equ_hierarquia_seq_transformacao );


                            var trackingMask = _trackingPolicy?.GetMask("Equipe", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EquipeDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration