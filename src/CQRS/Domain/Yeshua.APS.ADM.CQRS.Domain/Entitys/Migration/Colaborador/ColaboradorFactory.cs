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
                                public class ColaboradorFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ColaboradorFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ColaboradorFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IColaboradorEntity Create(string col_cpf, string col_nome, DateTime col_nascimento, string col_email, string col_matricula, string turm_id )
                            {
                                return Create(null, col_cpf, col_nome, col_nascimento, col_email, col_matricula, turm_id);
                            }

                            public IColaboradorEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string col_cpf, string col_nome, DateTime col_nascimento, string col_email, string col_matricula, string turm_id )
                            {
                            var entity = new ColaboradorEntity(col_cpf, col_nome, col_nascimento, col_email, col_matricula, turm_id );


                            var trackingMask = _trackingPolicy?.GetMask("Colaborador", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ColaboradorDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration