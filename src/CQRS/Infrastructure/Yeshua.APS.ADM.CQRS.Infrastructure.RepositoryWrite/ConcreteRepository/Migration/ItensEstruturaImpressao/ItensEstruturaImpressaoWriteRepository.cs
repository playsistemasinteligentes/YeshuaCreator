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

namespace Input.Repository.ItensEstruturaImpressao
{
    public partial class ItensEstruturaImpressaoWriteRepository : IItensEstruturaImpressaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItensEstruturaImpressaoQueryWrite _query; 

        public ItensEstruturaImpressaoWriteRepository(IUnitOfWork unitOfWork,IItensEstruturaImpressaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItensEstruturaImpressaoEntity ItensEstruturaImpressao)
        {
            var query = _query.InserirItensEstruturaImpressaoQuery(ItensEstruturaImpressao);
        ItensEstruturaImpressao.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItensEstruturaImpressaoEntity ItensEstruturaImpressao)
        {
            var query = _query.UpdateItensEstruturaImpressaoQuery(ItensEstruturaImpressao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItensEstruturaImpressaoEntity ItensEstruturaImpressao)
        {
            var query = _query.DeleteItensEstruturaImpressaoQuery(ItensEstruturaImpressao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIES_CUSTOM_FONT_SIZE(int id, int value)
        {
            var query = _query.UpdateIES_CUSTOM_FONT_SIZE(id, value);
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