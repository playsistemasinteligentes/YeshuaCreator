using Clinica.Atendimentos;
namespace IRepository.Write;
public partial interface ISesoesWriteRepository
{
    int AgendarAtendimento(int pacienteId, DateTime inicio, DateTime fim, int servicoId, int modeloConsulta, int versaoModeloConsulta);
    ServicoAgendamentoInfo DefinirServicoHabitual(int servicoId);
    void TransicionarAtendimento(int sessaoId, int versao, string acao);
    void SalvarAtendimento(RegistroInput registro, bool finalizar, bool corrigir);
    void VincularProfissional(int profissionalId, int usuarioId);
}
