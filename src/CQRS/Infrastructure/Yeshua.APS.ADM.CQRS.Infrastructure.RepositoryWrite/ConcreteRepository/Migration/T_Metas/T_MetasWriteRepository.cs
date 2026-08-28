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

namespace Input.Repository.T_Metas
{
    public partial class T_MetasWriteRepository : IT_MetasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_MetasQueryWrite _query; 

        public T_MetasWriteRepository(IUnitOfWork unitOfWork,IT_MetasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_MetasEntity T_Metas)
        {
            var query = _query.InserirT_MetasQuery(T_Metas);
        T_Metas.MET_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_MetasEntity T_Metas)
        {
            var query = _query.UpdateT_MetasQuery(T_Metas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_MetasEntity T_Metas)
        {
            var query = _query.DeleteT_MetasQuery(T_Metas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_DTINICIO(int met_id, string value)
        {
            var query = _query.UpdateMET_DTINICIO(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_DTFIM(int met_id, string value)
        {
            var query = _query.UpdateMET_DTFIM(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_ALVO(int met_id, string value)
        {
            var query = _query.UpdateMET_ALVO(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_TIPOALVO(int met_id, int value)
        {
            var query = _query.UpdateMET_TIPOALVO(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_ID(int met_id, int value)
        {
            var query = _query.UpdateIND_ID(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_RANGE01(int met_id, Decimal value)
        {
            var query = _query.UpdateMET_RANGE01(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_RANGE02(int met_id, Decimal value)
        {
            var query = _query.UpdateMET_RANGE02(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_RANGE03(int met_id, Decimal value)
        {
            var query = _query.UpdateMET_RANGE03(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_ID(int met_id, int value)
        {
            var query = _query.UpdateDIM_ID(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFAT_ID(int met_id, string value)
        {
            var query = _query.UpdateFAT_ID(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_SUBDIMENSAO_ID(int met_id, string value)
        {
            var query = _query.UpdateDIM_SUBDIMENSAO_ID(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int met_id, string value)
        {
            var query = _query.UpdatePER_ID(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDOM_EMPRESA(int met_id, string value)
        {
            var query = _query.UpdateDOM_EMPRESA(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDOM_FILIAL(int met_id, string value)
        {
            var query = _query.UpdateDOM_FILIAL(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int met_id, int value)
        {
            var query = _query.UpdateTenantID(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int met_id, bool value)
        {
            var query = _query.UpdateDeleted(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int met_id, DateTime value)
        {
            var query = _query.UpdateChanged(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int met_id, int value)
        {
            var query = _query.UpdateUserId(met_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration