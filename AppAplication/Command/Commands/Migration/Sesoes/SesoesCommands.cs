using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
namespace Command.Commands
{
    public class SesoesCrudCommand : ICommand
    {
        public int? Id { get; set; }
        public int? PacienteId { get; set; }
        public int? ProfissionalId { get; set; }
        public int? ServicoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int? Status { get; set; }
        public int? MovimentacaoFinanceiraId { get; set; }
        public string SinteseProntuario { get; set; }
        public string QueixaPrincipal { get; set; }
        public string MotivoConsultaAtual { get; set; }
        public string SintomasRelatados { get; set; }
        public int? MudancasDesdeUltimaSessaao { get; set; }
        public string ComportamentoObservado { get; set; }
        public string EstadoEmocionalGeral { get; set; }
        public string DiscursoPensamentos { get; set; }
        public string TecnicasUtilizadas { get; set; }
        public string QuestionamentosReflexoesAbordadas { get; set; }
        public string ExerciciosTarefasSugeridas { get; set; }
        public string DiagnoosticoHipoteseDiagnoostica { get; set; }
        public string ObjetivosCurtoPrazo { get; set; }
        public string ObjetivosLongoPrazo { get; set; }
        public string FrequenciaSugeridaSessooes { get; set; }
        public string EncaminhamentoOutrosProfissionais { get; set; }
        public string InformacoesRelevantesFuturasConsultas { get; set; }
        public string FeedbackPacienteSobreProcessoTerapeeutico { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration