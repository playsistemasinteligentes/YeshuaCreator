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

namespace Input.Repository.PeriodicidadeTeste
{
    public partial class PeriodicidadeTesteWriteRepository : IPeriodicidadeTesteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPeriodicidadeTesteQueryWrite _query; 

        public PeriodicidadeTesteWriteRepository(IUnitOfWork unitOfWork,IPeriodicidadeTesteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPeriodicidadeTesteEntity PeriodicidadeTeste)
        {
            var query = _query.InserirPeriodicidadeTesteQuery(PeriodicidadeTeste);
        PeriodicidadeTeste.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPeriodicidadeTesteEntity PeriodicidadeTeste)
        {
            var query = _query.UpdatePeriodicidadeTesteQuery(PeriodicidadeTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPeriodicidadeTesteEntity PeriodicidadeTeste)
        {
            var query = _query.DeletePeriodicidadeTesteQuery(PeriodicidadeTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int id, int value)
        {
            var query = _query.UpdatePER_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_QTD(int id, string value)
        {
            var query = _query.UpdatePER_QTD(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(int id, string value)
        {
            var query = _query.UpdateUNI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID(int id, string value)
        {
            var query = _query.UpdateGRP_ID(id, value);
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