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

namespace Input.Repository.TipoInspecaoItens
{
    public partial class TipoInspecaoItensWriteRepository : ITipoInspecaoItensWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoInspecaoItensQueryWrite _query; 

        public TipoInspecaoItensWriteRepository(IUnitOfWork unitOfWork,ITipoInspecaoItensQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoInspecaoItensEntity TipoInspecaoItens)
        {
            var query = _query.InserirTipoInspecaoItensQuery(TipoInspecaoItens);
        TipoInspecaoItens.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoInspecaoItensEntity TipoInspecaoItens)
        {
            var query = _query.UpdateTipoInspecaoItensQuery(TipoInspecaoItens);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoInspecaoItensEntity TipoInspecaoItens)
        {
            var query = _query.DeleteTipoInspecaoItensQuery(TipoInspecaoItens);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTII_ID(int id, int value)
        {
            var query = _query.UpdateTII_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIV_ID(int id, int value)
        {
            var query = _query.UpdateTIV_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITI_ID(int id, int value)
        {
            var query = _query.UpdateITI_ID(id, value);
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