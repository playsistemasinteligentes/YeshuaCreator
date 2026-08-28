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

namespace Input.Repository.IndicadoresPeriodosDimencoes
{
    public partial class IndicadoresPeriodosDimencoesWriteRepository : IIndicadoresPeriodosDimencoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IIndicadoresPeriodosDimencoesQueryWrite _query; 

        public IndicadoresPeriodosDimencoesWriteRepository(IUnitOfWork unitOfWork,IIndicadoresPeriodosDimencoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes)
        {
            var query = _query.InserirIndicadoresPeriodosDimencoesQuery(IndicadoresPeriodosDimencoes);
        IndicadoresPeriodosDimencoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes)
        {
            var query = _query.UpdateIndicadoresPeriodosDimencoesQuery(IndicadoresPeriodosDimencoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IIndicadoresPeriodosDimencoesEntity IndicadoresPeriodosDimencoes)
        {
            var query = _query.DeleteIndicadoresPeriodosDimencoesQuery(IndicadoresPeriodosDimencoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int id, string value)
        {
            var query = _query.UpdatePER_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_ID(int id, int value)
        {
            var query = _query.UpdateIND_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_ID(int id, int value)
        {
            var query = _query.UpdateDIM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_DESCRICAO(int id, string value)
        {
            var query = _query.UpdatePER_DESCRICAO(id, value);
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