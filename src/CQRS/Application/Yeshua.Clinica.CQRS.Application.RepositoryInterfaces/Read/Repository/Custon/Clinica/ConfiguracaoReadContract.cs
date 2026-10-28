using Clinica.Atendimentos;
namespace IRepository.Read;
public partial interface IClinicaReadRepository
{
    ConfiguracaoOpcoes ConsultarOpcoesConfiguracao();
    bool ConfiguracaoEstaPronta();
}
