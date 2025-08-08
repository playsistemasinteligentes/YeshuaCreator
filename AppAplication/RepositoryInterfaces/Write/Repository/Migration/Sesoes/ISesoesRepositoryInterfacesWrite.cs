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
        public void UpdatePacienteId(ISesoesEntity entity);
        public void UpdateProfissionalId(ISesoesEntity entity);
        public void UpdateServicoId(ISesoesEntity entity);
        public void UpdateDataInicio(ISesoesEntity entity);
        public void UpdateDataFim(ISesoesEntity entity);
        public void UpdateStatus(ISesoesEntity entity);
        public void UpdateMovimentacaoFinanceiraId(ISesoesEntity entity);
        public void UpdateSinteseProntuario(ISesoesEntity entity);
        public void UpdateQueixaPrincipal(ISesoesEntity entity);
        public void UpdateMotivoConsultaAtual(ISesoesEntity entity);
        public void UpdateSintomasRelatados(ISesoesEntity entity);
        public void UpdateMudancasDesdeUltimaSessaao(ISesoesEntity entity);
        public void UpdateComportamentoObservado(ISesoesEntity entity);
        public void UpdateEstadoEmocionalGeral(ISesoesEntity entity);
        public void UpdateDiscursoPensamentos(ISesoesEntity entity);
        public void UpdateTecnicasUtilizadas(ISesoesEntity entity);
        public void UpdateQuestionamentosReflexoesAbordadas(ISesoesEntity entity);
        public void UpdateExerciciosTarefasSugeridas(ISesoesEntity entity);
        public void UpdateDiagnoosticoHipoteseDiagnoostica(ISesoesEntity entity);
        public void UpdateObjetivosCurtoPrazo(ISesoesEntity entity);
        public void UpdateObjetivosLongoPrazo(ISesoesEntity entity);
        public void UpdateFrequenciaSugeridaSessooes(ISesoesEntity entity);
        public void UpdateEncaminhamentoOutrosProfissionais(ISesoesEntity entity);
        public void UpdateInformacoesRelevantesFuturasConsultas(ISesoesEntity entity);
        public void UpdateFeedbackPacienteSobreProcessoTerapeeutico(ISesoesEntity entity);
        public void UpdateTenantID(ISesoesEntity entity);
        public void UpdateDeleted(ISesoesEntity entity);
        public void UpdateChanged(ISesoesEntity entity);
        public void UpdateUserId(ISesoesEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration