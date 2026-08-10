using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface ISesoesWriteRepository
    {
        void Insert(ISesoesEntity sesoes);
        void Update(ISesoesEntity sesoes);
        void Delete(ISesoesEntity sesoes);
        void UpdatePacienteId(int id, int value);
        void UpdateDataInicio(int id, DateTime value);
        void UpdateDataFim(int id, DateTime value);
        void UpdateStatusAgendamento(int id, int value);
        void UpdateStatusProntuario(int id, int value);
        void UpdateProntuario(int id, string value);
        void UpdateQueixaPrincipal(int id, string value);
        void UpdateRegistroDocumental(int id, string value);
        void UpdateSintomasRelatados(int id, string value);
        void UpdateMudancasDesdeUltimaSessaao(int id, int value);
        void UpdateComportamentoObservado(int id, string value);
        void UpdateEstadoEmocionalGeral(int id, string value);
        void UpdateDiscursoPensamentos(int id, string value);
        void UpdateUsoMedicacao(int id, string value);
        void UpdateTecnicasUtilizadas(int id, string value);
        void UpdateQuestionamentosReflexoesAbordadas(int id, string value);
        void UpdateExerciciosTarefasSugeridas(int id, string value);
        void UpdateDiagnoosticoHipoteseDiagnoostica(int id, string value);
        void UpdateObjetivosCurtoPrazo(int id, string value);
        void UpdateObjetivosLongoPrazo(int id, string value);
        void UpdateFrequenciaSugeridaSessooes(int id, string value);
        void UpdateEncaminhamentoOutrosProfissionais(int id, string value);
        void UpdateInformacoesRelevantesFuturasConsultas(int id, string value);
        void UpdateFeedbackPacienteSobreProcessoTerapeeutico(int id, string value);
        void UpdateServicoId(int id, int value);
        void UpdateMovimentacaoFinanceiraId(int id, int value);
        void UpdateProfissionalId(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration