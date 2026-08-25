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
                                public class PacienteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PacienteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PacienteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPacienteEntity Create(int? id, string nome, string telefone, DateTime? datanascimento, int? genero, string escolaridade, string profissao, string endereco, string nomeresponsavel, string telefoneresponsavel, string observacao )
                            {
                                return Create(null, id, nome, telefone, datanascimento, genero, escolaridade, profissao, endereco, nomeresponsavel, telefoneresponsavel, observacao);
                            }

                            public IPacienteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string nome, string telefone, DateTime? datanascimento, int? genero, string escolaridade, string profissao, string endereco, string nomeresponsavel, string telefoneresponsavel, string observacao )
                            {
                            var entity = new PacienteEntity(id, nome, telefone, datanascimento, genero, escolaridade, profissao, endereco, nomeresponsavel, telefoneresponsavel, observacao );


                            var trackingMask = _trackingPolicy?.GetMask("Paciente", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PacienteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration