using Clinica.Atendimentos;
namespace IRepository.Write;
public partial interface ISesoesWriteRepository
{
    int AgendarAtendimento(int pacienteId, DateTime inicio, DateTime fim);
    void TransicionarAtendimento(int sessaoId, int versao, string acao);
    void SalvarAtendimento(RegistroInput registro, bool finalizar, bool corrigir);
    void VincularProfissional(int profissionalId, int usuarioId);
}
