

                            namespace Dominio.Entitys
                            {
                                public class SesoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public SesoesFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public ISesoesEntity Create(int? id, int? pacienteid, int? profissionalid, int? servicoid, DateTime datainicio, DateTime datafim, int? status, int? movimentacaofinanceiraid, string sinteseprontuario, string queixaprincipal, string motivoconsultaatual, string sintomasrelatados, int? mudancasdesdeultimasessaao, string comportamentoobservado, string estadoemocionalgeral, string discursopensamentos, string tecnicasutilizadas, string questionamentosreflexoesabordadas, string exerciciostarefassugeridas, string diagnoosticohipotesediagnoostica, string objetivoscurtoprazo, string objetivoslongoprazo, string frequenciasugeridasessooes, string encaminhamentooutrosprofissionais, string informacoesrelevantesfuturasconsultas, string feedbackpacientesobreprocessoterapeeutico )
                            {
                            var entity = new SesoesEntity(id, pacienteid, profissionalid, servicoid, datainicio, datafim, status, movimentacaofinanceiraid, sinteseprontuario, queixaprincipal, motivoconsultaatual, sintomasrelatados, mudancasdesdeultimasessaao, comportamentoobservado, estadoemocionalgeral, discursopensamentos, tecnicasutilizadas, questionamentosreflexoesabordadas, exerciciostarefassugeridas, diagnoosticohipotesediagnoostica, objetivoscurtoprazo, objetivoslongoprazo, frequenciasugeridasessooes, encaminhamentooutrosprofissionais, informacoesrelevantesfuturasconsultas, feedbackpacientesobreprocessoterapeeutico );


                            var decoratedEntity = new SesoesDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration