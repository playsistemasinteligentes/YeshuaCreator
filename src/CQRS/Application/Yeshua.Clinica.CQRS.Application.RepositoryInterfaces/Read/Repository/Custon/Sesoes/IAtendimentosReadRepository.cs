using Clinica.Atendimentos;
namespace IRepository.Read;
public partial interface ISesoesReadRepository
{
    PainelOutput ConsultarPainel(DateTime dia, int sessaoId);
    IReadOnlyList<ServicoAgendamentoInfo> ConsultarServicosAgendamento();
    RegistroAtendimentoInfo ExigirAtendimento(int sessaoId);
    bool PodeGravarAtendimento(int sessaoId);
}
