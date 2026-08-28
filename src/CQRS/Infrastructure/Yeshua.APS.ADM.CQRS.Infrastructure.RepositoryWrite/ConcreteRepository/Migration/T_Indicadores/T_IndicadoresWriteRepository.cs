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

namespace Input.Repository.T_Indicadores
{
    public partial class T_IndicadoresWriteRepository : IT_IndicadoresWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_IndicadoresQueryWrite _query; 

        public T_IndicadoresWriteRepository(IUnitOfWork unitOfWork,IT_IndicadoresQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_IndicadoresEntity T_Indicadores)
        {
            var query = _query.InserirT_IndicadoresQuery(T_Indicadores);
        T_Indicadores.IND_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_IndicadoresEntity T_Indicadores)
        {
            var query = _query.UpdateT_IndicadoresQuery(T_Indicadores);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_IndicadoresEntity T_Indicadores)
        {
            var query = _query.DeleteT_IndicadoresQuery(T_Indicadores);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_DESCRICAO(int ind_id, string value)
        {
            var query = _query.UpdateIND_DESCRICAO(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNEG_ID(int ind_id, int value)
        {
            var query = _query.UpdateNEG_ID(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDESC_CALCULO(int ind_id, string value)
        {
            var query = _query.UpdateDESC_CALCULO(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_TIPOCOMPARADOR(int ind_id, int value)
        {
            var query = _query.UpdateIND_TIPOCOMPARADOR(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_GRAFICO(int ind_id, int value)
        {
            var query = _query.UpdateIND_GRAFICO(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_CONEXAO(int ind_id, string value)
        {
            var query = _query.UpdateIND_CONEXAO(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIND_DTCRIACAO(int ind_id, DateTime value)
        {
            var query = _query.UpdateIND_DTCRIACAO(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRESPOSAVELIND(int ind_id, string value)
        {
            var query = _query.UpdateRESPOSAVELIND(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRESPOSAVELCARGA(int ind_id, string value)
        {
            var query = _query.UpdateRESPOSAVELCARGA(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePROCEXTRACAO(int ind_id, string value)
        {
            var query = _query.UpdatePROCEXTRACAO(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_ID(int ind_id, string value)
        {
            var query = _query.UpdatePER_ID(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDIM_ID(int ind_id, string value)
        {
            var query = _query.UpdateDIM_ID(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDOM_EMPRESA(int ind_id, string value)
        {
            var query = _query.UpdateDOM_EMPRESA(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDOM_FILIAL(int ind_id, string value)
        {
            var query = _query.UpdateDOM_FILIAL(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int ind_id, int value)
        {
            var query = _query.UpdateTenantID(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int ind_id, bool value)
        {
            var query = _query.UpdateDeleted(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int ind_id, DateTime value)
        {
            var query = _query.UpdateChanged(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int ind_id, int value)
        {
            var query = _query.UpdateUserId(ind_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration