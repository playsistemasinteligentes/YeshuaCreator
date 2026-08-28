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

namespace Input.Repository.Meses
{
    public partial class MesesWriteRepository : IMesesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMesesQueryWrite _query; 

        public MesesWriteRepository(IUnitOfWork unitOfWork,IMesesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMesesEntity Meses)
        {
            var query = _query.InserirMesesQuery(Meses);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IMesesEntity Meses)
        {
            var query = _query.UpdateMesesQuery(Meses);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMesesEntity Meses)
        {
            var query = _query.DeleteMesesQuery(Meses);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Updatefator(string mes, int value)
        {
            var query = _query.Updatefator(mes, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string mes, int value)
        {
            var query = _query.UpdateTenantID(mes, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string mes, bool value)
        {
            var query = _query.UpdateDeleted(mes, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string mes, DateTime value)
        {
            var query = _query.UpdateChanged(mes, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string mes, int value)
        {
            var query = _query.UpdateUserId(mes, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration