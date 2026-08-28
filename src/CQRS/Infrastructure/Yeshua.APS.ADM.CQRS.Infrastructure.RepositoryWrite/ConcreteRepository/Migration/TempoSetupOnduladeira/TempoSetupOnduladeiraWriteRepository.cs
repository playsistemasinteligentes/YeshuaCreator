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

namespace Input.Repository.TempoSetupOnduladeira
{
    public partial class TempoSetupOnduladeiraWriteRepository : ITempoSetupOnduladeiraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITempoSetupOnduladeiraQueryWrite _query; 

        public TempoSetupOnduladeiraWriteRepository(IUnitOfWork unitOfWork,ITempoSetupOnduladeiraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira)
        {
            var query = _query.InserirTempoSetupOnduladeiraQuery(TempoSetupOnduladeira);
        TempoSetupOnduladeira.TEM_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira)
        {
            var query = _query.UpdateTempoSetupOnduladeiraQuery(TempoSetupOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira)
        {
            var query = _query.DeleteTempoSetupOnduladeiraQuery(TempoSetupOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_ID_DE(int tem_id, string value)
        {
            var query = _query.UpdateOND_ID_DE(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_ID_PARA(int tem_id, string value)
        {
            var query = _query.UpdateOND_ID_PARA(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_RESINA_DE(int tem_id, string value)
        {
            var query = _query.UpdateTEM_RESINA_DE(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_RESINA_PARA(int tem_id, string value)
        {
            var query = _query.UpdateTEM_RESINA_PARA(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTEM_TEMPO(int tem_id, int value)
        {
            var query = _query.UpdateTEM_TEMPO(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int tem_id, int value)
        {
            var query = _query.UpdateTenantID(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int tem_id, bool value)
        {
            var query = _query.UpdateDeleted(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int tem_id, DateTime value)
        {
            var query = _query.UpdateChanged(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int tem_id, int value)
        {
            var query = _query.UpdateUserId(tem_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration