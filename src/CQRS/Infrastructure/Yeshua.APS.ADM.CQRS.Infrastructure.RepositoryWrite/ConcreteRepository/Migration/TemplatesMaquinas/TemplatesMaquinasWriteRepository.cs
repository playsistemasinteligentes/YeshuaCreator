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

namespace Input.Repository.TemplatesMaquinas
{
    public partial class TemplatesMaquinasWriteRepository : ITemplatesMaquinasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITemplatesMaquinasQueryWrite _query; 

        public TemplatesMaquinasWriteRepository(IUnitOfWork unitOfWork,ITemplatesMaquinasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITemplatesMaquinasEntity TemplatesMaquinas)
        {
            var query = _query.InserirTemplatesMaquinasQuery(TemplatesMaquinas);
        TemplatesMaquinas.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITemplatesMaquinasEntity TemplatesMaquinas)
        {
            var query = _query.UpdateTemplatesMaquinasQuery(TemplatesMaquinas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITemplatesMaquinasEntity TemplatesMaquinas)
        {
            var query = _query.DeleteTemplatesMaquinasQuery(TemplatesMaquinas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(int id, int value)
        {
            var query = _query.UpdateTEM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int id, string value)
        {
            var query = _query.UpdateMAQ_ID(id, value);
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