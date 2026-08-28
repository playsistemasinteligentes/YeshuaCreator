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

namespace Input.Repository.Variavel
{
    public partial class VariavelWriteRepository : IVariavelWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IVariavelQueryWrite _query; 

        public VariavelWriteRepository(IUnitOfWork unitOfWork,IVariavelQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IVariavelEntity Variavel)
        {
            var query = _query.InserirVariavelQuery(Variavel);
        Variavel.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IVariavelEntity Variavel)
        {
            var query = _query.UpdateVariavelQuery(Variavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IVariavelEntity Variavel)
        {
            var query = _query.DeleteVariavelQuery(Variavel);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVAR_ID(int id, int value)
        {
            var query = _query.UpdateVAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVAR_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateVAR_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCON_ID(int id, int value)
        {
            var query = _query.UpdateCON_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVAR_MODO(int id, int value)
        {
            var query = _query.UpdateVAR_MODO(id, value);
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