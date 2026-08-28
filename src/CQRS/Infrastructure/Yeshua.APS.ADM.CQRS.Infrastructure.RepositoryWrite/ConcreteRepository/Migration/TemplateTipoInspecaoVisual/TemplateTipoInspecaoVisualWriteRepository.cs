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

namespace Input.Repository.TemplateTipoInspecaoVisual
{
    public partial class TemplateTipoInspecaoVisualWriteRepository : ITemplateTipoInspecaoVisualWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITemplateTipoInspecaoVisualQueryWrite _query; 

        public TemplateTipoInspecaoVisualWriteRepository(IUnitOfWork unitOfWork,ITemplateTipoInspecaoVisualQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual)
        {
            var query = _query.InserirTemplateTipoInspecaoVisualQuery(TemplateTipoInspecaoVisual);
        TemplateTipoInspecaoVisual.TTI_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual)
        {
            var query = _query.UpdateTemplateTipoInspecaoVisualQuery(TemplateTipoInspecaoVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITemplateTipoInspecaoVisualEntity TemplateTipoInspecaoVisual)
        {
            var query = _query.DeleteTemplateTipoInspecaoVisualQuery(TemplateTipoInspecaoVisual);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_ID(int tti_id, int value)
        {
            var query = _query.UpdateTIV_ID(tti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_ID(int tti_id, int value)
        {
            var query = _query.UpdateTEM_ID(tti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int tti_id, int value)
        {
            var query = _query.UpdateTenantID(tti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int tti_id, bool value)
        {
            var query = _query.UpdateDeleted(tti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int tti_id, DateTime value)
        {
            var query = _query.UpdateChanged(tti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int tti_id, int value)
        {
            var query = _query.UpdateUserId(tti_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration