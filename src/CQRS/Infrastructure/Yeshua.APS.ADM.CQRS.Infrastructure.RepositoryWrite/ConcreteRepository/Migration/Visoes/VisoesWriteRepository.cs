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

namespace Input.Repository.Visoes
{
    public partial class VisoesWriteRepository : IVisoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IVisoesQueryWrite _query; 

        public VisoesWriteRepository(IUnitOfWork unitOfWork,IVisoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IVisoesEntity Visoes)
        {
            var query = _query.InserirVisoesQuery(Visoes);
        Visoes.VIS_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IVisoesEntity Visoes)
        {
            var query = _query.UpdateVisoesQuery(Visoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IVisoesEntity Visoes)
        {
            var query = _query.DeleteVisoesQuery(Visoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIS_PLANID(int vis_id, int value)
        {
            var query = _query.UpdateVIS_PLANID(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIS_FORMULA(int vis_id, string value)
        {
            var query = _query.UpdateVIS_FORMULA(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAB_ID(int vis_id, int value)
        {
            var query = _query.UpdateCAB_ID(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int vis_id, int value)
        {
            var query = _query.UpdateTenantID(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int vis_id, bool value)
        {
            var query = _query.UpdateDeleted(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int vis_id, DateTime value)
        {
            var query = _query.UpdateChanged(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int vis_id, int value)
        {
            var query = _query.UpdateUserId(vis_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration