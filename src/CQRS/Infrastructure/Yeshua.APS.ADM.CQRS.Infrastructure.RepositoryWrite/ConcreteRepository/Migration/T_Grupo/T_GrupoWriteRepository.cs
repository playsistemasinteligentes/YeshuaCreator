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

namespace Input.Repository.T_Grupo
{
    public partial class T_GrupoWriteRepository : IT_GrupoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_GrupoQueryWrite _query; 

        public T_GrupoWriteRepository(IUnitOfWork unitOfWork,IT_GrupoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_GrupoEntity T_Grupo)
        {
            var query = _query.InserirT_GrupoQuery(T_Grupo);
        T_Grupo.GRU_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_GrupoEntity T_Grupo)
        {
            var query = _query.UpdateT_GrupoQuery(T_Grupo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_GrupoEntity T_Grupo)
        {
            var query = _query.DeleteT_GrupoQuery(T_Grupo);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNOME(int gru_id, string value)
        {
            var query = _query.UpdateNOME(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEXIBELISTA(int gru_id, int value)
        {
            var query = _query.UpdateEXIBELISTA(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRU_DESCRICAO(int gru_id, string value)
        {
            var query = _query.UpdateGRU_DESCRICAO(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int gru_id, int value)
        {
            var query = _query.UpdateTenantID(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int gru_id, bool value)
        {
            var query = _query.UpdateDeleted(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int gru_id, DateTime value)
        {
            var query = _query.UpdateChanged(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int gru_id, int value)
        {
            var query = _query.UpdateUserId(gru_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration