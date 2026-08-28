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

namespace Input.Repository.Cotas
{
    public partial class CotasWriteRepository : ICotasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICotasQueryWrite _query; 

        public CotasWriteRepository(IUnitOfWork unitOfWork,ICotasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICotasEntity Cotas)
        {
            var query = _query.InserirCotasQuery(Cotas);
        Cotas.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICotasEntity Cotas)
        {
            var query = _query.UpdateCotasQuery(Cotas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICotasEntity Cotas)
        {
            var query = _query.DeleteCotasQuery(Cotas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOT_ID(int id, int value)
        {
            var query = _query.UpdateCOT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOT_DATA_DE(int id, DateTime value)
        {
            var query = _query.UpdateCOT_DATA_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOT_DATA_ATE(int id, DateTime value)
        {
            var query = _query.UpdateCOT_DATA_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOT_VALOR(int id, Decimal value)
        {
            var query = _query.UpdateCOT_VALOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOT_OCUPADO(int id, Decimal value)
        {
            var query = _query.UpdateCOT_OCUPADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateREP_ID(int id, int value)
        {
            var query = _query.UpdateREP_ID(id, value);
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