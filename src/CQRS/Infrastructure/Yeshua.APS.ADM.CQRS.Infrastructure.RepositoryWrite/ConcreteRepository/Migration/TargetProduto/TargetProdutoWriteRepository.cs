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

namespace Input.Repository.TargetProduto
{
    public partial class TargetProdutoWriteRepository : ITargetProdutoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITargetProdutoQueryWrite _query; 

        public TargetProdutoWriteRepository(IUnitOfWork unitOfWork,ITargetProdutoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITargetProdutoEntity TargetProduto)
        {
            var query = _query.InserirTargetProdutoQuery(TargetProduto);
        TargetProduto.TAR_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITargetProdutoEntity TargetProduto)
        {
            var query = _query.UpdateTargetProdutoQuery(TargetProduto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITargetProdutoEntity TargetProduto)
        {
            var query = _query.DeleteTargetProdutoQuery(TargetProduto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_ID(int tar_id, int value)
        {
            var query = _query.UpdateMOV_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int tar_id, string value)
        {
            var query = _query.UpdateORD_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int tar_id, string value)
        {
            var query = _query.UpdatePRO_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int tar_id, string value)
        {
            var query = _query.UpdateMAQ_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ID(int tar_id, string value)
        {
            var query = _query.UpdateUNI_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_ID(int tar_id, string value)
        {
            var query = _query.UpdateTURM_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_ID(int tar_id, string value)
        {
            var query = _query.UpdateTURN_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ID(int tar_id, int value)
        {
            var query = _query.UpdateUSE_ID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_DIA_TURMA(int tar_id, string value)
        {
            var query = _query.UpdateTAR_DIA_TURMA(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_META_PERFORMANCE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_META_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_REALIZADO_PERFORMANCE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_REALIZADO_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PERCENTUAL_REALIZADO_PERFORMANCE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PERCENTUAL_REALIZADO_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PROXIMA_META_PERFORMANCE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PROXIMA_META_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_META_TEMPO_SETUP(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_META_TEMPO_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_REALIZADO_TEMPO_SETUP(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_REALIZADO_TEMPO_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PROXIMA_META_TEMPO_SETUP(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PROXIMA_META_TEMPO_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_META_TEMPO_SETUP_AJUSTE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_REALIZADO_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_REALIZADO_TEMPO_SETUP_AJUSTE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PROXIMA_META_TEMPO_SETUP_AJUSTE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID_PERFORMANCE(int tar_id, string value)
        {
            var query = _query.UpdateOCO_ID_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_OBS_PERFORMANCE(int tar_id, string value)
        {
            var query = _query.UpdateTAR_OBS_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID_SETUP(int tar_id, string value)
        {
            var query = _query.UpdateOCO_ID_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_OBS_SETUP(int tar_id, string value)
        {
            var query = _query.UpdateTAR_OBS_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID_SETUPA(int tar_id, string value)
        {
            var query = _query.UpdateOCO_ID_SETUPA(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_OBS_SETUPA(int tar_id, string value)
        {
            var query = _query.UpdateTAR_OBS_SETUPA(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_TIPO_FEEDBACK_PERFORMANCE(int tar_id, string value)
        {
            var query = _query.UpdateTAR_TIPO_FEEDBACK_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_TIPO_FEEDBACK_SETUP(int tar_id, string value)
        {
            var query = _query.UpdateTAR_TIPO_FEEDBACK_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_TIPO_FEEDBACK_SETUP_AJUSTE(int tar_id, string value)
        {
            var query = _query.UpdateTAR_TIPO_FEEDBACK_SETUP_AJUSTE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_QTD_SETUP_AJUSTE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_QTD_SETUP_AJUSTE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_QTD(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_QTD(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(int tar_id, int value)
        {
            var query = _query.UpdateTAR_PARAMETRO_TIME_WORK_STOP_MACHINE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(int tar_id, int value)
        {
            var query = _query.UpdateTAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANFORMACAO(int tar_id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANFORMACAO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int tar_id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PERFORMANCE_MAX_VERDE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PERFORMANCE_MAX_VERDE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PERFORMANCE_MIN_VERDE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PERFORMANCE_MIN_VERDE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_SETUP_MAX_VERDE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_SETUP_MAX_VERDE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_SETUP_MIN_VERDE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_SETUP_MIN_VERDE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_SETUPA_MAX_VERDE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_SETUPA_MAX_VERDE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_SETUPA_MIN_VERDE(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_SETUPA_MIN_VERDE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_PERFORMANCE_MIN_AMARELO(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_PERFORMANCE_MIN_AMARELO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_SETUP_MAX_AMARELO(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_SETUP_MAX_AMARELO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_SETUPA_MAX_AMARELO(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_SETUPA_MAX_AMARELO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_OBS_OP_PARCIAL(int tar_id, string value)
        {
            var query = _query.UpdateTAR_OBS_OP_PARCIAL(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_OCO_ID_OP_PARCIAL(int tar_id, string value)
        {
            var query = _query.UpdateTAR_OCO_ID_OP_PARCIAL(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_COR_PERFORMANCE(int tar_id, string value)
        {
            var query = _query.UpdateTAR_COR_PERFORMANCE(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_COR_SETUP_GERAL(int tar_id, string value)
        {
            var query = _query.UpdateTAR_COR_SETUP_GERAL(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_COR_SETUP(int tar_id, string value)
        {
            var query = _query.UpdateTAR_COR_SETUP(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_COR_SETUPA(int tar_id, string value)
        {
            var query = _query.UpdateTAR_COR_SETUPA(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_DIA_TURMA_D(int tar_id, DateTime value)
        {
            var query = _query.UpdateTAR_DIA_TURMA_D(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFEE_QTD_PECAS_POR_PULSO(int tar_id, Decimal value)
        {
            var query = _query.UpdateFEE_QTD_PECAS_POR_PULSO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_QTD_PERDAS(int tar_id, Decimal value)
        {
            var query = _query.UpdateTAR_QTD_PERDAS(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_DATA_INICIAL(int tar_id, DateTime value)
        {
            var query = _query.UpdateTAR_DATA_INICIAL(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_DATA_FINAL(int tar_id, DateTime value)
        {
            var query = _query.UpdateTAR_DATA_FINAL(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_APROVADO(int tar_id, string value)
        {
            var query = _query.UpdateTAR_APROVADO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTAR_TEMPO_PRODUZINDO(int tar_id, int value)
        {
            var query = _query.UpdateTAR_TEMPO_PRODUZINDO(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int tar_id, int value)
        {
            var query = _query.UpdateTenantID(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int tar_id, bool value)
        {
            var query = _query.UpdateDeleted(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int tar_id, DateTime value)
        {
            var query = _query.UpdateChanged(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int tar_id, int value)
        {
            var query = _query.UpdateUserId(tar_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration