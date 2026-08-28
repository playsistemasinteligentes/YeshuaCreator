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
                                public class Unidade_UnidadeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public Unidade_UnidadeFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public Unidade_UnidadeFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUnidade_UnidadeEntity Create(int uni_id, string uni_descricao )
                            {
                                return Create(null, uni_id, uni_descricao);
                            }

                            public IUnidade_UnidadeEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int uni_id, string uni_descricao )
                            {
                            var entity = new Unidade_UnidadeEntity(uni_id, uni_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("Unidade_Unidade", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new Unidade_UnidadeDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration