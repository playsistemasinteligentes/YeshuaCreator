using Clinica.Atendimentos;
namespace IRepository.Write;
public partial interface IClinicaWriteRepository
{
    int ReservarConfiguracao();
    EtapaConfiguracao ExigirEtapaConfiguracao(int sagaId,int sagaStepId,string stepKey,string inputHash);
    void SelecionarClinicaInicial(int id,int tipoEstrutura);
    void ExigirConfiguracaoPronta();
    ConfiguracaoAceita ConfirmarEtapaConfiguracao(EtapaConfiguracao etapa,int cadastroId,string inputHash);
}
