
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface ISesoesEntity
{
    int? Id { get; set; }
    int? PacienteId { get; set; }
    int? ProfissionalId { get; set; }
    int? ServicoId { get; set; }
    DateTime DataInicio { get; set; }
    DateTime DataFim { get; set; }
    int? Status { get; set; }
    int? MovimentacaoFinanceiraId { get; set; }
    string SinteseProntuario { get; set; }
    string QueixaPrincipal { get; set; }
    string MotivoConsultaAtual { get; set; }
    string SintomasRelatados { get; set; }
    int? MudancasDesdeUltimaSessaao { get; set; }
    string ComportamentoObservado { get; set; }
    string EstadoEmocionalGeral { get; set; }
    string DiscursoPensamentos { get; set; }
    string TecnicasUtilizadas { get; set; }
    string QuestionamentosReflexoesAbordadas { get; set; }
    string ExerciciosTarefasSugeridas { get; set; }
    string DiagnoosticoHipoteseDiagnoostica { get; set; }
    string ObjetivosCurtoPrazo { get; set; }
    string ObjetivosLongoPrazo { get; set; }
    string FrequenciaSugeridaSessooes { get; set; }
    string EncaminhamentoOutrosProfissionais { get; set; }
    string InformacoesRelevantesFuturasConsultas { get; set; }
    string FeedbackPacienteSobreProcessoTerapeeutico { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration