using Dapper;
using Dominio.Entitys;
using Input.Querys.Sesoes;
using IRepository.Write;
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

        public SesoesWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(ISesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().InserirSesoesQuery(Sesoes);
        Sesoes.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(ISesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().UpdateSesoesQuery(Sesoes);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(ISesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().DeleteSesoesQuery(Sesoes);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePacienteId(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdatePacienteId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateProfissionalId(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateProfissionalId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateServicoId(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateServicoId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataInicio(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateDataInicio(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataFim(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateDataFim(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateStatus(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateStatus(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateMovimentacaoFinanceiraId(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateMovimentacaoFinanceiraId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateSinteseProntuario(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateSinteseProntuario(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateQueixaPrincipal(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateQueixaPrincipal(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateMotivoConsultaAtual(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateMotivoConsultaAtual(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateSintomasRelatados(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateSintomasRelatados(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateMudancasDesdeUltimaSessaao(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateMudancasDesdeUltimaSessaao(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateComportamentoObservado(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateComportamentoObservado(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEstadoEmocionalGeral(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateEstadoEmocionalGeral(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDiscursoPensamentos(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateDiscursoPensamentos(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTecnicasUtilizadas(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateTecnicasUtilizadas(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateQuestionamentosReflexoesAbordadas(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateQuestionamentosReflexoesAbordadas(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateExerciciosTarefasSugeridas(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateExerciciosTarefasSugeridas(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDiagnoosticoHipoteseDiagnoostica(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateDiagnoosticoHipoteseDiagnoostica(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateObjetivosCurtoPrazo(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateObjetivosCurtoPrazo(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateObjetivosLongoPrazo(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateObjetivosLongoPrazo(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateFrequenciaSugeridaSessooes(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateFrequenciaSugeridaSessooes(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEncaminhamentoOutrosProfissionais(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateEncaminhamentoOutrosProfissionais(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateInformacoesRelevantesFuturasConsultas(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateInformacoesRelevantesFuturasConsultas(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateFeedbackPacienteSobreProcessoTerapeeutico(ISesoesEntity entity)
        {
            var query = new SesoesWriteQuery().UpdateFeedbackPacienteSobreProcessoTerapeeutico(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration