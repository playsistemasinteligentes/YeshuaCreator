
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class SesoesEntity : ISesoesEntity
{
    public int? PacienteId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public int? StatusAgendamento { get; set; }
    public int? StatusProntuario { get; set; }
    public string Prontuario { get; set; }
    public string QueixaPrincipal { get; set; }
    public string RegistroDocumental { get; set; }
    public string SintomasRelatados { get; set; }
    public int? MudancasDesdeUltimaSessaao { get; set; }
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
    private List<string> _erroMensagem = null;
 internal SesoesEntity(int? pacienteid, DateTime datainicio, DateTime datafim, int? statusagendamento, int? statusprontuario, string prontuario, string queixaprincipal, string registrodocumental, string sintomasrelatados, int? mudancasdesdeultimasessaao, string comportamentoobservado, string estadoemocionalgeral, string discursopensamentos, string usomedicacao, string tecnicasutilizadas, string questionamentosreflexoesabordadas, string exerciciostarefassugeridas, string diagnoosticohipotesediagnoostica, string objetivoscurtoprazo, string objetivoslongoprazo, string frequenciasugeridasessooes, string encaminhamentooutrosprofissionais, string informacoesrelevantesfuturasconsultas, string feedbackpacientesobreprocessoterapeeutico, int? id, int? servicoid, int? movimentacaofinanceiraid, int? profissionalid ){
 PacienteId = pacienteid; 
 DataInicio = (datainicio < (new DateTime(1800, 1, 1))) ? DateTime.Now : datainicio; 
 DataFim = (datafim < (new DateTime(1800, 1, 1))) ? DateTime.Now : datafim; 
 StatusAgendamento = statusagendamento; 
 StatusProntuario = statusprontuario; 
 Prontuario = prontuario; 
 QueixaPrincipal = queixaprincipal; 
 RegistroDocumental = registrodocumental; 
 SintomasRelatados = sintomasrelatados; 
 MudancasDesdeUltimaSessaao = mudancasdesdeultimasessaao; 
 ComportamentoObservado = comportamentoobservado; 
 EstadoEmocionalGeral = estadoemocionalgeral; 
 DiscursoPensamentos = discursopensamentos; 
 UsoMedicacao = usomedicacao; 
 TecnicasUtilizadas = tecnicasutilizadas; 
 QuestionamentosReflexoesAbordadas = questionamentosreflexoesabordadas; 
 ExerciciosTarefasSugeridas = exerciciostarefassugeridas; 
 DiagnoosticoHipoteseDiagnoostica = diagnoosticohipotesediagnoostica; 
 ObjetivosCurtoPrazo = objetivoscurtoprazo; 
 ObjetivosLongoPrazo = objetivoslongoprazo; 
 FrequenciaSugeridaSessooes = frequenciasugeridasessooes; 
 EncaminhamentoOutrosProfissionais = encaminhamentooutrosprofissionais; 
 InformacoesRelevantesFuturasConsultas = informacoesrelevantesfuturasconsultas; 
 FeedbackPacienteSobreProcessoTerapeeutico = feedbackpacientesobreprocessoterapeeutico; 
 Id = id; 
 ServicoId = servicoid; 
 MovimentacaoFinanceiraId = movimentacaofinanceiraid; 
 ProfissionalId = profissionalid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (DataInicio == null || DataInicio < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Data Inicio deve ser informado.");
   if (DataFim == null || DataFim < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Data Fim deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration