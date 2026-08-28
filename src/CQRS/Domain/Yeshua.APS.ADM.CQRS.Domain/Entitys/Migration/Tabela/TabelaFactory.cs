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
                                public class TabelaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TabelaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TabelaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITabelaEntity Create(int id_tabela, string codigo, string nome )
                            {
                                return Create(null, id_tabela, codigo, nome);
                            }

                            public ITabelaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id_tabela, string codigo, string nome )
                            {
                            var entity = new TabelaEntity(id_tabela, codigo, nome );


                            var trackingMask = _trackingPolicy?.GetMask("Tabela", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TabelaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration