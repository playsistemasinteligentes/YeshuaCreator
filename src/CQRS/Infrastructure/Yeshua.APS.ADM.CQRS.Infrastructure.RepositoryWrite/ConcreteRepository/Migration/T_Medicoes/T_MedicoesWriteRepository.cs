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

namespace Input.Repository.T_Medicoes
{
    public partial class T_MedicoesWriteRepository : IT_MedicoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_MedicoesQueryWrite _query; 

        public T_MedicoesWriteRepository(IUnitOfWork unitOfWork,IT_MedicoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_MedicoesEntity T_Medicoes)
        {
            var query = _query.InserirT_MedicoesQuery(T_Medicoes);
        T_Medicoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_MedicoesEntity T_Medicoes)
        {
            var query = _query.UpdateT_MedicoesQuery(T_Medicoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_MedicoesEntity T_Medicoes)
        {
            var query = _query.DeleteT_MedicoesQuery(T_Medicoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_ID(int id, int value)
        {
            var query = _query.UpdateMED_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_ID(int id, int value)
        {
            var query = _query.UpdateIND_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_ID(int id, int value)
        {
            var query = _query.UpdateMET_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(int id, int value)
        {
            var query = _query.UpdateUNI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_DATA(int id, DateTime value)
        {
            var query = _query.UpdateMED_DATA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_VALOR(int id, string value)
        {
            var query = _query.UpdateMED_VALOR(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_AC_ANO(int id, string value)
        {
            var query = _query.UpdateMED_AC_ANO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_DATAMEDICAO(int id, string value)
        {
            var query = _query.UpdateMED_DATAMEDICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_PONDERACAO(int id, Decimal value)
        {
            var query = _query.UpdateMED_PONDERACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_ID(int id, string value)
        {
            var query = _query.UpdateDIM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateDIM_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_SUBDIMENSAO_ID(int id, string value)
        {
            var query = _query.UpdateDIM_SUBDIMENSAO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_SUB_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateDIM_SUB_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int id, string value)
        {
            var query = _query.UpdatePER_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_DESCRICAO(int id, string value)
        {
            var query = _query.UpdatePER_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFAT_ID(int id, string value)
        {
            var query = _query.UpdateFAT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFAT_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateFAT_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_SQL(int id, string value)
        {
            var query = _query.UpdateMED_SQL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDOM_EMPRESA(int id, string value)
        {
            var query = _query.UpdateDOM_EMPRESA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDOM_FILIAL(int id, string value)
        {
            var query = _query.UpdateDOM_FILIAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMED_VALOR_DISPER(int id, string value)
        {
            var query = _query.UpdateMED_VALOR_DISPER(id, value);
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