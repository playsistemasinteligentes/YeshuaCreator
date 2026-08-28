// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

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

namespace Input.Repository.Observacoes
{
    public partial class ObservacoesWriteRepository : IObservacoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IObservacoesQueryWrite _query; 

        public ObservacoesWriteRepository(IUnitOfWork unitOfWork,IObservacoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IObservacoesEntity Observacoes)
        {
            var query = _query.InserirObservacoesQuery(Observacoes);
        Observacoes.OBS_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IObservacoesEntity Observacoes)
        {
            var query = _query.UpdateObservacoesQuery(Observacoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IObservacoesEntity Observacoes)
        {
            var query = _query.DeleteObservacoesQuery(Observacoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBS_TIPO(int obs_id, string value)
        {
            var query = _query.UpdateOBS_TIPO(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBS_DESCRICAO(int obs_id, string value)
        {
            var query = _query.UpdateOBS_DESCRICAO(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(int obs_id, string value)
        {
            var query = _query.UpdateCLI_ID(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int obs_id, string value)
        {
            var query = _query.UpdateMAQ_ID(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int obs_id, string value)
        {
            var query = _query.UpdatePRO_ID(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANFORMACAO(int obs_id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANFORMACAO(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOBS_INTEGRACAO(int obs_id, string value)
        {
            var query = _query.UpdateOBS_INTEGRACAO(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int obs_id, int value)
        {
            var query = _query.UpdateTenantID(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int obs_id, bool value)
        {
            var query = _query.UpdateDeleted(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int obs_id, DateTime value)
        {
            var query = _query.UpdateChanged(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int obs_id, int value)
        {
            var query = _query.UpdateUserId(obs_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration