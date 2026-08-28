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

namespace Input.Repository.Calendario
{
    public partial class CalendarioWriteRepository : ICalendarioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICalendarioQueryWrite _query; 

        public CalendarioWriteRepository(IUnitOfWork unitOfWork,ICalendarioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICalendarioEntity Calendario)
        {
            var query = _query.InserirCalendarioQuery(Calendario);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ICalendarioEntity Calendario)
        {
            var query = _query.UpdateCalendarioQuery(Calendario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICalendarioEntity Calendario)
        {
            var query = _query.DeleteCalendarioQuery(Calendario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAL_DESCRICAO(int cal_id, string value)
        {
            var query = _query.UpdateCAL_DESCRICAO(cal_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAL_DIVIDE_DIA_EM(int cal_id, int value)
        {
            var query = _query.UpdateCAL_DIVIDE_DIA_EM(cal_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int cal_id, int value)
        {
            var query = _query.UpdateTenantID(cal_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int cal_id, bool value)
        {
            var query = _query.UpdateDeleted(cal_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int cal_id, DateTime value)
        {
            var query = _query.UpdateChanged(cal_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int cal_id, int value)
        {
            var query = _query.UpdateUserId(cal_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration