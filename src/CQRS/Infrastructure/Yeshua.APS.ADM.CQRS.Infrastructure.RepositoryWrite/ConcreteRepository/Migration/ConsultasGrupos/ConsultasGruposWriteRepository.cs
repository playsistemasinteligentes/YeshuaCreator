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

namespace Input.Repository.ConsultasGrupos
{
    public partial class ConsultasGruposWriteRepository : IConsultasGruposWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IConsultasGruposQueryWrite _query; 

        public ConsultasGruposWriteRepository(IUnitOfWork unitOfWork,IConsultasGruposQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IConsultasGruposEntity ConsultasGrupos)
        {
            var query = _query.InserirConsultasGruposQuery(ConsultasGrupos);
        ConsultasGrupos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IConsultasGruposEntity ConsultasGrupos)
        {
            var query = _query.UpdateConsultasGruposQuery(ConsultasGrupos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IConsultasGruposEntity ConsultasGrupos)
        {
            var query = _query.DeleteConsultasGruposQuery(ConsultasGrupos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCON_ID(int id, int value)
        {
            var query = _query.UpdateCON_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRU_ID(int id, int value)
        {
            var query = _query.UpdateGRU_ID(id, value);
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