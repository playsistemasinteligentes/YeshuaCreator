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
    public class SesoesWriteRepository : ISesoesWriteRepository
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
        public void UpdatePacienteId(ISesoesEntity entity)
        {
            var query = _query.UpdatePacienteId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataInicio(ISesoesEntity entity)
        {
            var query = _query.UpdateDataInicio(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataFim(ISesoesEntity entity)
        {
            var query = _query.UpdateDataFim(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatusAgendamento(ISesoesEntity entity)
        {
            var query = _query.UpdateStatusAgendamento(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatusProntuario(ISesoesEntity entity)
        {
            var query = _query.UpdateStatusProntuario(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProntuario(ISesoesEntity entity)
        {
            var query = _query.UpdateProntuario(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQueixaPrincipal(ISesoesEntity entity)
        {
            var query = _query.UpdateQueixaPrincipal(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRegistroDocumental(ISesoesEntity entity)
        {
            var query = _query.UpdateRegistroDocumental(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSintomasRelatados(ISesoesEntity entity)
        {
            var query = _query.UpdateSintomasRelatados(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMudancasDesdeUltimaSessaao(ISesoesEntity entity)
        {
            var query = _query.UpdateMudancasDesdeUltimaSessaao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateComportamentoObservado(ISesoesEntity entity)
        {
            var query = _query.UpdateComportamentoObservado(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEstadoEmocionalGeral(ISesoesEntity entity)
        {
            var query = _query.UpdateEstadoEmocionalGeral(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDiscursoPensamentos(ISesoesEntity entity)
        {
            var query = _query.UpdateDiscursoPensamentos(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUsoMedicacao(ISesoesEntity entity)
        {
            var query = _query.UpdateUsoMedicacao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTecnicasUtilizadas(ISesoesEntity entity)
        {
            var query = _query.UpdateTecnicasUtilizadas(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateQuestionamentosReflexoesAbordadas(ISesoesEntity entity)
        {
            var query = _query.UpdateQuestionamentosReflexoesAbordadas(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateExerciciosTarefasSugeridas(ISesoesEntity entity)
        {
            var query = _query.UpdateExerciciosTarefasSugeridas(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDiagnoosticoHipoteseDiagnoostica(ISesoesEntity entity)
        {
            var query = _query.UpdateDiagnoosticoHipoteseDiagnoostica(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObjetivosCurtoPrazo(ISesoesEntity entity)
        {
            var query = _query.UpdateObjetivosCurtoPrazo(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObjetivosLongoPrazo(ISesoesEntity entity)
        {
            var query = _query.UpdateObjetivosLongoPrazo(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFrequenciaSugeridaSessooes(ISesoesEntity entity)
        {
            var query = _query.UpdateFrequenciaSugeridaSessooes(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEncaminhamentoOutrosProfissionais(ISesoesEntity entity)
        {
            var query = _query.UpdateEncaminhamentoOutrosProfissionais(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateInformacoesRelevantesFuturasConsultas(ISesoesEntity entity)
        {
            var query = _query.UpdateInformacoesRelevantesFuturasConsultas(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFeedbackPacienteSobreProcessoTerapeeutico(ISesoesEntity entity)
        {
            var query = _query.UpdateFeedbackPacienteSobreProcessoTerapeeutico(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateServicoId(ISesoesEntity entity)
        {
            var query = _query.UpdateServicoId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMovimentacaoFinanceiraId(ISesoesEntity entity)
        {
            var query = _query.UpdateMovimentacaoFinanceiraId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProfissionalId(ISesoesEntity entity)
        {
            var query = _query.UpdateProfissionalId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(ISesoesEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(ISesoesEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(ISesoesEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(ISesoesEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration