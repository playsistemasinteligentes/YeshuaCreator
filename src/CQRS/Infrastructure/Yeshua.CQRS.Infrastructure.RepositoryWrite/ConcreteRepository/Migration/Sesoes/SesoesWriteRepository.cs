using Dapper;
using Dominio.Entitys;
using IRepository.Write;
using IQuery.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Sesoes
{
    public partial class SesoesWriteRepository : ISesoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ISesoesQueryWrite _query; 

        public SesoesWriteRepository(IUnitOfWork unitOfWork,ISesoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ISesoesEntity Sesoes)
        {
            var query = _query.InserirSesoesQuery(Sesoes);
        Sesoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ISesoesEntity Sesoes)
        {
            var query = _query.UpdateSesoesQuery(Sesoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ISesoesEntity Sesoes)
        {
            var query = _query.DeleteSesoesQuery(Sesoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePacienteId(int id, int value)
        {
            var query = _query.UpdatePacienteId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataInicio(int id, DateTime value)
        {
            var query = _query.UpdateDataInicio(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataFim(int id, DateTime value)
        {
            var query = _query.UpdateDataFim(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatusAgendamento(int id, int value)
        {
            var query = _query.UpdateStatusAgendamento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatusProntuario(int id, int value)
        {
            var query = _query.UpdateStatusProntuario(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProntuario(int id, string value)
        {
            var query = _query.UpdateProntuario(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQueixaPrincipal(int id, string value)
        {
            var query = _query.UpdateQueixaPrincipal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRegistroDocumental(int id, string value)
        {
            var query = _query.UpdateRegistroDocumental(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSintomasRelatados(int id, string value)
        {
            var query = _query.UpdateSintomasRelatados(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMudancasDesdeUltimaSessaao(int id, int value)
        {
            var query = _query.UpdateMudancasDesdeUltimaSessaao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateComportamentoObservado(int id, string value)
        {
            var query = _query.UpdateComportamentoObservado(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEstadoEmocionalGeral(int id, string value)
        {
            var query = _query.UpdateEstadoEmocionalGeral(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDiscursoPensamentos(int id, string value)
        {
            var query = _query.UpdateDiscursoPensamentos(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUsoMedicacao(int id, string value)
        {
            var query = _query.UpdateUsoMedicacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTecnicasUtilizadas(int id, string value)
        {
            var query = _query.UpdateTecnicasUtilizadas(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuestionamentosReflexoesAbordadas(int id, string value)
        {
            var query = _query.UpdateQuestionamentosReflexoesAbordadas(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExerciciosTarefasSugeridas(int id, string value)
        {
            var query = _query.UpdateExerciciosTarefasSugeridas(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDiagnoosticoHipoteseDiagnoostica(int id, string value)
        {
            var query = _query.UpdateDiagnoosticoHipoteseDiagnoostica(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObjetivosCurtoPrazo(int id, string value)
        {
            var query = _query.UpdateObjetivosCurtoPrazo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObjetivosLongoPrazo(int id, string value)
        {
            var query = _query.UpdateObjetivosLongoPrazo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFrequenciaSugeridaSessooes(int id, string value)
        {
            var query = _query.UpdateFrequenciaSugeridaSessooes(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEncaminhamentoOutrosProfissionais(int id, string value)
        {
            var query = _query.UpdateEncaminhamentoOutrosProfissionais(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateInformacoesRelevantesFuturasConsultas(int id, string value)
        {
            var query = _query.UpdateInformacoesRelevantesFuturasConsultas(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFeedbackPacienteSobreProcessoTerapeeutico(int id, string value)
        {
            var query = _query.UpdateFeedbackPacienteSobreProcessoTerapeeutico(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateServicoId(int id, int value)
        {
            var query = _query.UpdateServicoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMovimentacaoFinanceiraId(int id, int value)
        {
            var query = _query.UpdateMovimentacaoFinanceiraId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProfissionalId(int id, int value)
        {
            var query = _query.UpdateProfissionalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration