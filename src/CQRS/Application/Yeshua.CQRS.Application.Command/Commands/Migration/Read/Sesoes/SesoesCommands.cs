using RepositoryInterfaces.Patterns.Command;
namespace Command.Read
{
    public struct SesoesReadCommand : ICommandRead
    {
        public int? PacienteId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public List<int> StatusAgendamento { get; set; }
        public List<int> StatusProntuario { get; set; }
        public string Prontuario { get; set; }
        public string QueixaPrincipal { get; set; }
        public string RegistroDocumental { get; set; }
        public string SintomasRelatados { get; set; }
        public List<int> MudancasDesdeUltimaSessaao { get; set; }
        public string ComportamentoObservado { get; set; }
        public string EstadoEmocionalGeral { get; set; }
        public string DiscursoPensamentos { get; set; }
        public string UsoMedicacao { get; set; }
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
        public int? Id { get; set; }
        public int? ServicoId { get; set; }
        public int? MovimentacaoFinanceiraId { get; set; }
        public int? ProfissionalId { get; set; }
        public int? TenantID { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
 public Pagination Paginacao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandCommandsMigration