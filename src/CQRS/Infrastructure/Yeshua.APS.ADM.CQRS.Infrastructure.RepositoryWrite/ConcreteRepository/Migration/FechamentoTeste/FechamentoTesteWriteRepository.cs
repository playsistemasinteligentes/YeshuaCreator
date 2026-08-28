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

namespace Input.Repository.FechamentoTeste
{
    public partial class FechamentoTesteWriteRepository : IFechamentoTesteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IFechamentoTesteQueryWrite _query; 

        public FechamentoTesteWriteRepository(IUnitOfWork unitOfWork,IFechamentoTesteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IFechamentoTesteEntity FechamentoTeste)
        {
            var query = _query.InserirFechamentoTesteQuery(FechamentoTeste);
        FechamentoTeste.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IFechamentoTesteEntity FechamentoTeste)
        {
            var query = _query.UpdateFechamentoTesteQuery(FechamentoTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IFechamentoTesteEntity FechamentoTeste)
        {
            var query = _query.DeleteFechamentoTesteQuery(FechamentoTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFEC_ID(int id, int value)
        {
            var query = _query.UpdateFEC_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFEC_QTD(int id, int value)
        {
            var query = _query.UpdateFEC_QTD(id, value);
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