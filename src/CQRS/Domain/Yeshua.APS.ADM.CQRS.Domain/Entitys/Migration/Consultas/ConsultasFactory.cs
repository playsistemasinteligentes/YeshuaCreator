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
                                public class ConsultasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConsultasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConsultasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConsultasEntity Create(int? id, string con_casas_decimais, string con_conexao )
                            {
                                return Create(null, id, con_casas_decimais, con_conexao);
                            }

                            public IConsultasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string con_casas_decimais, string con_conexao )
                            {
                            var entity = new ConsultasEntity(id, con_casas_decimais, con_conexao );


                            var trackingMask = _trackingPolicy?.GetMask("Consultas", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConsultasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration