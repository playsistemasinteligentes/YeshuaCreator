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

namespace Input.Repository.TemplateTipoTeste
{
    public partial class TemplateTipoTesteWriteRepository : ITemplateTipoTesteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITemplateTipoTesteQueryWrite _query; 

        public TemplateTipoTesteWriteRepository(IUnitOfWork unitOfWork,ITemplateTipoTesteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITemplateTipoTesteEntity TemplateTipoTeste)
        {
            var query = _query.InserirTemplateTipoTesteQuery(TemplateTipoTeste);
        TemplateTipoTeste.TTT_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITemplateTipoTesteEntity TemplateTipoTeste)
        {
            var query = _query.UpdateTemplateTipoTesteQuery(TemplateTipoTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITemplateTipoTesteEntity TemplateTipoTeste)
        {
            var query = _query.DeleteTemplateTipoTesteQuery(TemplateTipoTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTT_ID(int ttt_id, int value)
        {
            var query = _query.UpdateTT_ID(ttt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(int ttt_id, int value)
        {
            var query = _query.UpdateTEM_ID(ttt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int ttt_id, int value)
        {
            var query = _query.UpdateTenantID(ttt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int ttt_id, bool value)
        {
            var query = _query.UpdateDeleted(ttt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int ttt_id, DateTime value)
        {
            var query = _query.UpdateChanged(ttt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int ttt_id, int value)
        {
            var query = _query.UpdateUserId(ttt_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration