using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Command.UseCase;
using Clinica.Atendimentos;
namespace Command.Receivers.UseCase;
public partial class ConsultarAtendimentosHandler
{
    private readonly ISesoesReadRepository _read;
    private readonly ISesoesWriteRepository _write;
    private readonly IUnitOfWork _uow;
    public ConsultarAtendimentosHandler(ILogger logger,IExecutionContext context,ISesoesReadRepository read,ISesoesWriteRepository write,IUnitOfWork uow):base(logger,context)
    { _logger=logger;_executionContext=context;_read=read;_write=write;_uow=uow; }
    protected partial Task<State<ConsultarAtendimentosOutputCommand>> CustomActionHookAsync(State<ConsultarAtendimentosOutputCommand> state,ConsultarAtendimentosInputCommand comand,CancellationToken cancellationToken)
    {
        try
        {
            if(!DateTime.TryParseExact(comand.Data,"yyyy-MM-dd",System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None,out var dia))
                throw new AtendimentoException("Informe a data da agenda.");
            // A data representa o dia de São Paulo; os registros de horário são UTC.
            var zone=TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            var p=_read.ConsultarPainel(TimeZoneInfo.ConvertTimeToUtc(dia,zone),comand.SessaoId);
            var result=new ConsultarAtendimentosOutputCommand { ProfissionalId=p.ProfissionalId,ProfissionalNome=p.ProfissionalNome,
            ServicoHabitualId=p.ServicoHabitualId,ServicoHabitualNome=p.ServicoHabitualNome,ModeloConsultaHabitual=p.ModeloConsultaHabitual,VersaoModeloConsultaHabitual=p.VersaoModeloConsultaHabitual,
            Agenda=p.Agenda.Select(x=>new Command.UseCase.AgendaAtendimentoInfo { Id=x.Id,Paciente=x.Paciente,DataInicio=x.DataInicio,DataFim=x.DataFim,StatusAgendamento=x.StatusAgendamento,StatusProntuario=x.StatusProntuario,Pendente=x.Pendente }).ToList(),
            Pacientes=p.Pacientes.Select(x=>new Command.UseCase.PacienteAtendimentoInfo { Id=x.Id,Nome=x.Nome }).ToList(),
            Atual=p.Atual.Select(x=>new Command.UseCase.RegistroAtendimentoInfo { Id=x.Id,PacienteId=x.PacienteId,Paciente=x.Paciente,DataNascimento=x.DataNascimento,DataInicio=x.DataInicio,DataFim=x.DataFim,StatusAgendamento=x.StatusAgendamento,StatusProntuario=x.StatusProntuario,Versao=x.Versao,AtendimentoIniciadoEm=x.AtendimentoIniciadoEm,AtendimentoEncerradoEm=x.AtendimentoEncerradoEm,RegistroFinalizadoEm=x.RegistroFinalizadoEm,Prontuario=x.Prontuario,QueixaPrincipal=x.QueixaPrincipal,RegistroDocumental=x.RegistroDocumental,ObjetivosCurtoPrazo=x.ObjetivosCurtoPrazo,ObjetivosLongoPrazo=x.ObjetivosLongoPrazo,ExerciciosTarefasSugeridas=x.ExerciciosTarefasSugeridas,EncaminhamentoOutrosProfissionais=x.EncaminhamentoOutrosProfissionais,FrequenciaSugeridaSessooes=x.FrequenciaSugeridaSessooes,InformacoesRelevantesFuturasConsultas=x.InformacoesRelevantesFuturasConsultas,SugestoesIncorporadas=x.SugestoesIncorporadas,ServicoId=x.ServicoId,ServicoNome=x.ServicoNome,ModeloConsulta=x.ModeloConsulta,VersaoModeloConsulta=x.VersaoModeloConsulta }).ToList(),
            Historico=p.Historico.Select(x=>new Command.UseCase.RegistroAtendimentoInfo { Id=x.Id,PacienteId=x.PacienteId,Paciente=x.Paciente,DataNascimento=x.DataNascimento,DataInicio=x.DataInicio,DataFim=x.DataFim,StatusAgendamento=x.StatusAgendamento,StatusProntuario=x.StatusProntuario,Versao=x.Versao,AtendimentoIniciadoEm=x.AtendimentoIniciadoEm,AtendimentoEncerradoEm=x.AtendimentoEncerradoEm,RegistroFinalizadoEm=x.RegistroFinalizadoEm,Prontuario=x.Prontuario,QueixaPrincipal=x.QueixaPrincipal,RegistroDocumental=x.RegistroDocumental,ObjetivosCurtoPrazo=x.ObjetivosCurtoPrazo,ObjetivosLongoPrazo=x.ObjetivosLongoPrazo,ExerciciosTarefasSugeridas=x.ExerciciosTarefasSugeridas,EncaminhamentoOutrosProfissionais=x.EncaminhamentoOutrosProfissionais,FrequenciaSugeridaSessooes=x.FrequenciaSugeridaSessooes,InformacoesRelevantesFuturasConsultas=x.InformacoesRelevantesFuturasConsultas,SugestoesIncorporadas=x.SugestoesIncorporadas,ServicoId=x.ServicoId,ServicoNome=x.ServicoNome,ModeloConsulta=x.ModeloConsulta,VersaoModeloConsulta=x.VersaoModeloConsulta }).ToList(),
            Audios=p.Audios.Select(x=>new Command.UseCase.AudioAtendimentoInfo { SagaId=x.SagaId,Data=x.Data,Status=x.Status,Transcricao=x.Transcricao,Prontuario=x.Prontuario,QueixaPrincipal=x.QueixaPrincipal,RegistroDocumental=x.RegistroDocumental,StepFalhouId=x.StepFalhouId }).ToList() };
            return Task.FromResult(Success("Operação concluída.",result));
        }
        catch(AtendimentoException e) { return Task.FromResult(new State<ConsultarAtendimentosOutputCommand>(e.Status,e.Message,new())); }
    }
}
