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

namespace Input.Repository.T_HORARIO_RECEBIMENTO
{
    public partial class T_HORARIO_RECEBIMENTOWriteRepository : IT_HORARIO_RECEBIMENTOWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_HORARIO_RECEBIMENTOQueryWrite _query; 

        public T_HORARIO_RECEBIMENTOWriteRepository(IUnitOfWork unitOfWork,IT_HORARIO_RECEBIMENTOQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO)
        {
            var query = _query.InserirT_HORARIO_RECEBIMENTOQuery(T_HORARIO_RECEBIMENTO);
        T_HORARIO_RECEBIMENTO.HRE_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO)
        {
            var query = _query.UpdateT_HORARIO_RECEBIMENTOQuery(T_HORARIO_RECEBIMENTO);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO)
        {
            var query = _query.DeleteT_HORARIO_RECEBIMENTOQuery(T_HORARIO_RECEBIMENTO);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHRE_DIA_DA_SEMANA(int hre_id, int value)
        {
            var query = _query.UpdateHRE_DIA_DA_SEMANA(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHRE_HORA_INICIAL(int hre_id, DateTime value)
        {
            var query = _query.UpdateHRE_HORA_INICIAL(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateHRE_HORA_FINAL(int hre_id, DateTime value)
        {
            var query = _query.UpdateHRE_HORA_FINAL(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCLI_ID(int hre_id, string value)
        {
            var query = _query.UpdateCLI_ID(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int hre_id, int value)
        {
            var query = _query.UpdateTenantID(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int hre_id, bool value)
        {
            var query = _query.UpdateDeleted(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int hre_id, DateTime value)
        {
            var query = _query.UpdateChanged(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int hre_id, int value)
        {
            var query = _query.UpdateUserId(hre_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration