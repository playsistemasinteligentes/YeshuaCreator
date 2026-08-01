//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration

/*
 
   if (comand is Command.Write.SesoesCrudCommand c)
            {
                var rulesDictionary = new Dictionary<Type, ISessaoRule>
                {
                    { typeof(EmConciliacaoDeHorariosSpec), new EmConciliacaoDeHorariosRule() },
                    { typeof(ConfirmadaSpec), new ConfirmadaRule() },
                    { typeof(RealizadaSpec), new RealizadaRule() },
                    { typeof(CanceladaSpec), new CanceladaRule() }
                };

                var specs = new List<ISpecification<SesoesEntity>>
                {
                    new EmConciliacaoDeHorariosSpec(),
                    new ConfirmadaSpec(),
                    new RealizadaSpec(),
                    new CanceladaSpec()
                };

                var sesoes = new SesoesFactory(_logger).Create(c.PacienteId, c.DataInicio, c.DataFim, c.Status, c.MovimentacaoFinanceiraId, c.Prontuario, c.QueixaPrincipal, c.RegistroDocumental, c.SintomasRelatados, c.MudancasDesdeUltimaSessaao, c.ComportamentoObservado, c.EstadoEmocionalGeral, c.DiscursoPensamentos, c.UsoMedicacao, c.TecnicasUtilizadas, c.QuestionamentosReflexoesAbordadas, c.ExerciciosTarefasSugeridas, c.DiagnoosticoHipoteseDiagnoostica, c.ObjetivosCurtoPrazo, c.ObjetivosLongoPrazo, c.FrequenciaSugeridaSessooes, c.EncaminhamentoOutrosProfissionais, c.InformacoesRelevantesFuturasConsultas, c.FeedbackPacienteSobreProcessoTerapeeutico, c.Id, c.ServicoId, c.ProfissionalId);
                if (!sesoes.isValidUpdate())
                    return ValidationError(sesoes.getErroMensagens(), comand);


                // Encontrar a Spec que se aplica
                var matchedSpec = specs.FirstOrDefault(s => s.IsSatisfiedBy((SesoesEntity)sesoes));
                if (matchedSpec == null)
                    return ValidationError("Sessão em estado inválido", null);

                if (rulesDictionary.TryGetValue(matchedSpec.GetType(), out var rule))
                {
                    rule.Apply((SesoesEntity)sesoes);
                }


                try
                {
                    _repository.Update(sesoes);
                    return Success("OK", sesoes);
                }
                catch (Exception e)
                {
                    return Error(e, sesoes);
                }
            }
            else
            {
                return Error("ErroConversao", default);
            }
 */