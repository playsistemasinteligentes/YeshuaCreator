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

namespace Input.Repository.OptAlteracaoDimencoes
{
    public partial class OptAlteracaoDimencoesWriteRepository : IOptAlteracaoDimencoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOptAlteracaoDimencoesQueryWrite _query; 

        public OptAlteracaoDimencoesWriteRepository(IUnitOfWork unitOfWork,IOptAlteracaoDimencoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOptAlteracaoDimencoesEntity OptAlteracaoDimencoes)
        {
            var query = _query.InserirOptAlteracaoDimencoesQuery(OptAlteracaoDimencoes);
        OptAlteracaoDimencoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IOptAlteracaoDimencoesEntity OptAlteracaoDimencoes)
        {
            var query = _query.UpdateOptAlteracaoDimencoesQuery(OptAlteracaoDimencoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOptAlteracaoDimencoesEntity OptAlteracaoDimencoes)
        {
            var query = _query.DeleteOptAlteracaoDimencoesQuery(OptAlteracaoDimencoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOAD_ID(int id, int value)
        {
            var query = _query.UpdateOAD_ID(id, value);
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