
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class SesoesEntity
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
    private List<string> _erroMensagem = null;
 public SesoesEntity(int? id, int? pacienteid, int? profissionalid, int? servicoid, DateTime datainicio, DateTime datafim, int? status, int? movimentacaofinanceiraid, string sinteseprontuario, string queixaprincipal, string motivoconsultaatual, string sintomasrelatados, int? mudancasdesdeultimasessaao, string comportamentoobservado, string estadoemocionalgeral, string discursopensamentos, string tecnicasutilizadas, string questionamentosreflexoesabordadas, string exerciciostarefassugeridas, string diagnoosticohipotesediagnoostica, string objetivoscurtoprazo, string objetivoslongoprazo, string frequenciasugeridasessooes, string encaminhamentooutrosprofissionais, string informacoesrelevantesfuturasconsultas, string feedbackpacientesobreprocessoterapeeutico ){
 Id = id; 
 PacienteId = pacienteid; 
 ProfissionalId = profissionalid; 
 ServicoId = servicoid; 
 DataInicio = (datainicio < (new DateTime(1800, 1, 1))) ? DateTime.Now : datainicio; 
 DataFim = (datafim < (new DateTime(1800, 1, 1))) ? DateTime.Now : datafim; 
 Status = status; 
 MovimentacaoFinanceiraId = movimentacaofinanceiraid; 
 SinteseProntuario = sinteseprontuario; 
 QueixaPrincipal = queixaprincipal; 
 MotivoConsultaAtual = motivoconsultaatual; 
 SintomasRelatados = sintomasrelatados; 
 MudancasDesdeUltimaSessaao = mudancasdesdeultimasessaao; 
 ComportamentoObservado = comportamentoobservado; 
 EstadoEmocionalGeral = estadoemocionalgeral; 
 DiscursoPensamentos = discursopensamentos; 
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

                public bool isValidInsert()
                {
                    return isValidData();
                }
                public bool isValidUpdate()
                {
                    return isValidData();
                }
                public bool isValidDelete()
                {
                    return true;
                }
                public List<string> getErroMensagens()
                {
                    return this._erroMensagem;
                }
            }
        }//Dominio.Schemas.CQRS.SourceCodeEntityMigration