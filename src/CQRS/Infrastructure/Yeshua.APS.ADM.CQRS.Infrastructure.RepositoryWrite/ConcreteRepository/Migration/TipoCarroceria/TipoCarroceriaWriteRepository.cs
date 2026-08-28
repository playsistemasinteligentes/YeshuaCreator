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

namespace Input.Repository.TipoCarroceria
{
    public partial class TipoCarroceriaWriteRepository : ITipoCarroceriaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoCarroceriaQueryWrite _query; 

        public TipoCarroceriaWriteRepository(IUnitOfWork unitOfWork,ITipoCarroceriaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoCarroceriaEntity TipoCarroceria)
        {
            var query = _query.InserirTipoCarroceriaQuery(TipoCarroceria);
        TipoCarroceria.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoCarroceriaEntity TipoCarroceria)
        {
            var query = _query.UpdateTipoCarroceriaQuery(TipoCarroceria);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoCarroceriaEntity TipoCarroceria)
        {
            var query = _query.DeleteTipoCarroceriaQuery(TipoCarroceria);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTCA_ID(int id, string value)
        {
            var query = _query.UpdateTCA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTCA_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateTCA_DESCRICAO(id, value);
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