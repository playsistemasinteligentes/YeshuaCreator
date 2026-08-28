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

namespace Input.Repository.ItensCalendario
{
    public partial class ItensCalendarioWriteRepository : IItensCalendarioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItensCalendarioQueryWrite _query; 

        public ItensCalendarioWriteRepository(IUnitOfWork unitOfWork,IItensCalendarioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItensCalendarioEntity ItensCalendario)
        {
            var query = _query.InserirItensCalendarioQuery(ItensCalendario);
        ItensCalendario.ICA_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItensCalendarioEntity ItensCalendario)
        {
            var query = _query.UpdateItensCalendarioQuery(ItensCalendario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItensCalendarioEntity ItensCalendario)
        {
            var query = _query.DeleteItensCalendarioQuery(ItensCalendario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateICA_DATA_DE(int ica_id, DateTime value)
        {
            var query = _query.UpdateICA_DATA_DE(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateICA_DATA_ATE(int ica_id, DateTime value)
        {
            var query = _query.UpdateICA_DATA_ATE(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateICA_OBSERVACAO(int ica_id, string value)
        {
            var query = _query.UpdateICA_OBSERVACAO(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateICA_TIPO(int ica_id, int value)
        {
            var query = _query.UpdateICA_TIPO(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateURM_ID(int ica_id, string value)
        {
            var query = _query.UpdateURM_ID(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateURN_ID(int ica_id, string value)
        {
            var query = _query.UpdateURN_ID(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAL_ID(int ica_id, int value)
        {
            var query = _query.UpdateCAL_ID(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int ica_id, string value)
        {
            var query = _query.UpdateMAQ_ID(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int ica_id, string value)
        {
            var query = _query.UpdatePRO_ID(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateICA_LIMPESA_MAQUINA(int ica_id, int value)
        {
            var query = _query.UpdateICA_LIMPESA_MAQUINA(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int ica_id, int value)
        {
            var query = _query.UpdateTenantID(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int ica_id, bool value)
        {
            var query = _query.UpdateDeleted(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int ica_id, DateTime value)
        {
            var query = _query.UpdateChanged(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int ica_id, int value)
        {
            var query = _query.UpdateUserId(ica_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration