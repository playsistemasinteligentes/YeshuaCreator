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

namespace Input.Repository.IndicadoresDimencoes
{
    public partial class IndicadoresDimencoesWriteRepository : IIndicadoresDimencoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IIndicadoresDimencoesQueryWrite _query; 

        public IndicadoresDimencoesWriteRepository(IUnitOfWork unitOfWork,IIndicadoresDimencoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IIndicadoresDimencoesEntity IndicadoresDimencoes)
        {
            var query = _query.InserirIndicadoresDimencoesQuery(IndicadoresDimencoes);
        IndicadoresDimencoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IIndicadoresDimencoesEntity IndicadoresDimencoes)
        {
            var query = _query.UpdateIndicadoresDimencoesQuery(IndicadoresDimencoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IIndicadoresDimencoesEntity IndicadoresDimencoes)
        {
            var query = _query.DeleteIndicadoresDimencoesQuery(IndicadoresDimencoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_ID(int id, int value)
        {
            var query = _query.UpdateDIM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_ID(int id, int value)
        {
            var query = _query.UpdateIND_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateDIM_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_SQL(int id, string value)
        {
            var query = _query.UpdateDIM_SQL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_CONEXAO(int id, string value)
        {
            var query = _query.UpdateDIM_CONEXAO(id, value);
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