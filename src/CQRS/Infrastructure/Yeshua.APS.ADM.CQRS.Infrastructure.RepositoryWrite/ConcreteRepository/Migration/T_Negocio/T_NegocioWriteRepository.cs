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

namespace Input.Repository.T_Negocio
{
    public partial class T_NegocioWriteRepository : IT_NegocioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_NegocioQueryWrite _query; 

        public T_NegocioWriteRepository(IUnitOfWork unitOfWork,IT_NegocioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_NegocioEntity T_Negocio)
        {
            var query = _query.InserirT_NegocioQuery(T_Negocio);
        T_Negocio.NEG_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_NegocioEntity T_Negocio)
        {
            var query = _query.UpdateT_NegocioQuery(T_Negocio);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_NegocioEntity T_Negocio)
        {
            var query = _query.DeleteT_NegocioQuery(T_Negocio);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNEG_DESCRICAO(int neg_id, string value)
        {
            var query = _query.UpdateNEG_DESCRICAO(neg_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int neg_id, int value)
        {
            var query = _query.UpdateTenantID(neg_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int neg_id, bool value)
        {
            var query = _query.UpdateDeleted(neg_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int neg_id, DateTime value)
        {
            var query = _query.UpdateChanged(neg_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int neg_id, int value)
        {
            var query = _query.UpdateUserId(neg_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration