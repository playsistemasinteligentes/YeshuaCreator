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
                                public class SesoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public SesoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public SesoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ISesoesEntity Create(int? pacienteid, DateTime datainicio, DateTime datafim, int? statusagendamento, int? statusprontuario, string prontuario, string queixaprincipal, string registrodocumental, string sintomasrelatados, int? mudancasdesdeultimasessaao, string comportamentoobservado, string estadoemocionalgeral, string discursopensamentos, string usomedicacao, string tecnicasutilizadas, string questionamentosreflexoesabordadas, string exerciciostarefassugeridas, string diagnoosticohipotesediagnoostica, string objetivoscurtoprazo, string objetivoslongoprazo, string frequenciasugeridasessooes, string encaminhamentooutrosprofissionais, string informacoesrelevantesfuturasconsultas, string feedbackpacientesobreprocessoterapeeutico, int? id, int? servicoid, int? movimentacaofinanceiraid, int? profissionalid )
                            {
                                return Create(null, pacienteid, datainicio, datafim, statusagendamento, statusprontuario, prontuario, queixaprincipal, registrodocumental, sintomasrelatados, mudancasdesdeultimasessaao, comportamentoobservado, estadoemocionalgeral, discursopensamentos, usomedicacao, tecnicasutilizadas, questionamentosreflexoesabordadas, exerciciostarefassugeridas, diagnoosticohipotesediagnoostica, objetivoscurtoprazo, objetivoslongoprazo, frequenciasugeridasessooes, encaminhamentooutrosprofissionais, informacoesrelevantesfuturasconsultas, feedbackpacientesobreprocessoterapeeutico, id, servicoid, movimentacaofinanceiraid, profissionalid);
                            }

                            public ISesoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? pacienteid, DateTime datainicio, DateTime datafim, int? statusagendamento, int? statusprontuario, string prontuario, string queixaprincipal, string registrodocumental, string sintomasrelatados, int? mudancasdesdeultimasessaao, string comportamentoobservado, string estadoemocionalgeral, string discursopensamentos, string usomedicacao, string tecnicasutilizadas, string questionamentosreflexoesabordadas, string exerciciostarefassugeridas, string diagnoosticohipotesediagnoostica, string objetivoscurtoprazo, string objetivoslongoprazo, string frequenciasugeridasessooes, string encaminhamentooutrosprofissionais, string informacoesrelevantesfuturasconsultas, string feedbackpacientesobreprocessoterapeeutico, int? id, int? servicoid, int? movimentacaofinanceiraid, int? profissionalid )
                            {
                            var entity = new SesoesEntity(pacienteid, datainicio, datafim, statusagendamento, statusprontuario, prontuario, queixaprincipal, registrodocumental, sintomasrelatados, mudancasdesdeultimasessaao, comportamentoobservado, estadoemocionalgeral, discursopensamentos, usomedicacao, tecnicasutilizadas, questionamentosreflexoesabordadas, exerciciostarefassugeridas, diagnoosticohipotesediagnoostica, objetivoscurtoprazo, objetivoslongoprazo, frequenciasugeridasessooes, encaminhamentooutrosprofissionais, informacoesrelevantesfuturasconsultas, feedbackpacientesobreprocessoterapeeutico, id, servicoid, movimentacaofinanceiraid, profissionalid );


                            var trackingMask = _trackingPolicy?.GetMask("Sesoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new SesoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration