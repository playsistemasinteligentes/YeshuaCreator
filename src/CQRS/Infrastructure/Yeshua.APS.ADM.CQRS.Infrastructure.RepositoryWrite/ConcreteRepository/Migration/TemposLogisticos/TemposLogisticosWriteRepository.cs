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

namespace Input.Repository.TemposLogisticos
{
    public partial class TemposLogisticosWriteRepository : ITemposLogisticosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITemposLogisticosQueryWrite _query; 

        public TemposLogisticosWriteRepository(IUnitOfWork unitOfWork,ITemposLogisticosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITemposLogisticosEntity TemposLogisticos)
        {
            var query = _query.InserirTemposLogisticosQuery(TemposLogisticos);
        TemposLogisticos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITemposLogisticosEntity TemposLogisticos)
        {
            var query = _query.UpdateTemposLogisticosQuery(TemposLogisticos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITemposLogisticosEntity TemposLogisticos)
        {
            var query = _query.DeleteTemposLogisticosQuery(TemposLogisticos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTMP_TIPO_TEMPO(int id, string value)
        {
            var query = _query.UpdateTMP_TIPO_TEMPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTMP_TIPO_CARGA(int id, string value)
        {
            var query = _query.UpdateTMP_TIPO_CARGA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTMP_TEMPO_MEDIO_UNITARIO(int id, Decimal value)
        {
            var query = _query.UpdateTMP_TEMPO_MEDIO_UNITARIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(int id, string value)
        {
            var query = _query.UpdateCLI_ID(id, value);
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