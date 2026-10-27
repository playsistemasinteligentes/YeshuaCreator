using Clinica.Atendimentos;
namespace IRepository.Read;
public partial interface ISesoesReadRepository
{
    PainelOutput ConsultarPainel(DateTime dia, int sessaoId);
    RegistroAtendimentoInfo ExigirAtendimento(int sessaoId);
    bool PodeGravarAtendimento(int sessaoId);
}
