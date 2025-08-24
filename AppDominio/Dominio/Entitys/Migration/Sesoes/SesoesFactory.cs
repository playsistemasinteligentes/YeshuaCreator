

                            namespace Dominio.Entitys
                            {
                                public class SesoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public SesoesFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public ISesoesEntity Create(int? pacienteid, DateTime datainicio, DateTime datafim, int? status, int? movimentacaofinanceiraid, string prontuario, string queixaprincipal, string registrodocumental, string sintomasrelatados, int? mudancasdesdeultimasessaao, string comportamentoobservado, string estadoemocionalgeral, string discursopensamentos, string usomedicacao, string tecnicasutilizadas, string questionamentosreflexoesabordadas, string exerciciostarefassugeridas, string diagnoosticohipotesediagnoostica, string objetivoscurtoprazo, string objetivoslongoprazo, string frequenciasugeridasessooes, string encaminhamentooutrosprofissionais, string informacoesrelevantesfuturasconsultas, string feedbackpacientesobreprocessoterapeeutico, int? id, int? servicoid, int? profissionalid )
                            {
                            var entity = new SesoesEntity(pacienteid, datainicio, datafim, status, movimentacaofinanceiraid, prontuario, queixaprincipal, registrodocumental, sintomasrelatados, mudancasdesdeultimasessaao, comportamentoobservado, estadoemocionalgeral, discursopensamentos, usomedicacao, tecnicasutilizadas, questionamentosreflexoesabordadas, exerciciostarefassugeridas, diagnoosticohipotesediagnoostica, objetivoscurtoprazo, objetivoslongoprazo, frequenciasugeridasessooes, encaminhamentooutrosprofissionais, informacoesrelevantesfuturasconsultas, feedbackpacientesobreprocessoterapeeutico, id, servicoid, profissionalid );


                            var decoratedEntity = new SesoesDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration