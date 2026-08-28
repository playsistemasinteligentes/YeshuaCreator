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
                                public class MemoriaDeCalculoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MemoriaDeCalculoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MemoriaDeCalculoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMemoriaDeCalculoEntity Create(int? id, int mem_id, int? orc_id, Decimal? mem_valor, string mem_descricao )
                            {
                                return Create(null, id, mem_id, orc_id, mem_valor, mem_descricao);
                            }

                            public IMemoriaDeCalculoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mem_id, int? orc_id, Decimal? mem_valor, string mem_descricao )
                            {
                            var entity = new MemoriaDeCalculoEntity(id, mem_id, orc_id, mem_valor, mem_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("MemoriaDeCalculo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MemoriaDeCalculoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration