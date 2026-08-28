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

namespace Input.Repository.FilaProducao
{
    public partial class FilaProducaoWriteRepository : IFilaProducaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IFilaProducaoQueryWrite _query; 

        public FilaProducaoWriteRepository(IUnitOfWork unitOfWork,IFilaProducaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IFilaProducaoEntity FilaProducao)
        {
            var query = _query.InserirFilaProducaoQuery(FilaProducao);
        FilaProducao.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IFilaProducaoEntity FilaProducao)
        {
            var query = _query.UpdateFilaProducaoQuery(FilaProducao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IFilaProducaoEntity FilaProducao)
        {
            var query = _query.DeleteFilaProducaoQuery(FilaProducao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_PRO_ID(int id, string value)
        {
            var query = _query.UpdateROT_PRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_QUANTIDADE_PREVISTA(int id, Decimal value)
        {
            var query = _query.UpdateFPR_QUANTIDADE_PREVISTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_MAQ_ID(int id, string value)
        {
            var query = _query.UpdateROT_MAQ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_INICIO_PREVISTA(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_INICIO_PREVISTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_FIM_PREVISTA(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_FIM_PREVISTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_FIM_MAXIMA(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_FIM_MAXIMA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANFORMACAO(int id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANFORMACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_OBS_PRODUCAO(int id, string value)
        {
            var query = _query.UpdateFPR_OBS_PRODUCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_STATUS(int id, string value)
        {
            var query = _query.UpdateFPR_STATUS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_DECORRIDO_SETUP(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_DECORRIDO_SETUP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_DECORRIDO_SETUPA(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_DECORRIDO_SETUPA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_DECORRIDO_PERFORMANC(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_DECORRIDO_PERFORMANC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_DECO_PEQUENA_PARADA(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_DECO_PEQUENA_PARADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_QTD_PERFORMANCE(int id, Decimal value)
        {
            var query = _query.UpdateFPR_QTD_PERFORMANCE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_QTD_SETUP(int id, Decimal value)
        {
            var query = _query.UpdateFPR_QTD_SETUP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_QTD_PRODUZIDA(int id, Decimal value)
        {
            var query = _query.UpdateFPR_QTD_PRODUZIDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_TEORICO_PERFORMANCE(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_TEORICO_PERFORMANCE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_RESTANTE_PERFORMANC(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_RESTANTE_PERFORMANC(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_VELOCIDADE_P_ATINGIR_META(int id, Decimal value)
        {
            var query = _query.UpdateFPR_VELOCIDADE_P_ATINGIR_META(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_QTD_RESTANTE(int id, Decimal value)
        {
            var query = _query.UpdateFPR_QTD_RESTANTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_VELO_ATU_PC_SEGUNDO(int id, Decimal value)
        {
            var query = _query.UpdateFPR_VELO_ATU_PC_SEGUNDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_PERFORMANCE_PROJETADA(int id, Decimal value)
        {
            var query = _query.UpdateFPR_PERFORMANCE_PROJETADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TEMPO_RESTANTE_TOTAL(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TEMPO_RESTANTE_TOTAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_FIM_PREVISTO_ATUAL(int id, DateTime value)
        {
            var query = _query.UpdateFPR_FIM_PREVISTO_ATUAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_PRODUZINDO(int id, int value)
        {
            var query = _query.UpdateFPR_PRODUZINDO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ORDEM_NA_FILA(int id, Decimal value)
        {
            var query = _query.UpdateFPR_ORDEM_NA_FILA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ID_INTEGRACAO(int id, string value)
        {
            var query = _query.UpdateFPR_ID_INTEGRACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TRUNCADO(int id, string value)
        {
            var query = _query.UpdateFPR_TRUNCADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_TRUNC_INI(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_TRUNC_INI(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_TRUNC_FIM(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_TRUNC_FIM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ID(int id, int value)
        {
            var query = _query.UpdateFPR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_COR_FILA(int id, string value)
        {
            var query = _query.UpdateFPR_COR_FILA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID_MANUAL(int id, string value)
        {
            var query = _query.UpdateMAQ_ID_MANUAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID_RESTRINGIDA(int id, string value)
        {
            var query = _query.UpdateMAQ_ID_RESTRINGIDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_PREVISAO_MATERIA_PRIMA(int id, DateTime value)
        {
            var query = _query.UpdateFPR_PREVISAO_MATERIA_PRIMA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_NECESSIDADE_INICIO_PRODUCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_NECESSIDADE_FIM_PRODUCAO(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_NECESSIDADE_FIM_PRODUCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            var query = _query.UpdateFPR_GRUPO_PRODUTIVO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_INICIO_GRUPO_PRODUTIVO(int id, DateTime value)
        {
            var query = _query.UpdateFPR_INICIO_GRUPO_PRODUTIVO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_FIM_GRUPO_PRODUTIVO(int id, DateTime value)
        {
            var query = _query.UpdateFPR_FIM_GRUPO_PRODUTIVO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_COR_BICO1(int id, string value)
        {
            var query = _query.UpdateFPR_COR_BICO1(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_COR_BICO2(int id, string value)
        {
            var query = _query.UpdateFPR_COR_BICO2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_COR_BICO3(int id, string value)
        {
            var query = _query.UpdateFPR_COR_BICO3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_COR_BICO4(int id, string value)
        {
            var query = _query.UpdateFPR_COR_BICO4(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_COR_BICO5(int id, string value)
        {
            var query = _query.UpdateFPR_COR_BICO5(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_META_SETUP(int id, Decimal value)
        {
            var query = _query.UpdateFPR_META_SETUP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ORD_ID_REPROGRAMADO(int id, string value)
        {
            var query = _query.UpdateFPR_ORD_ID_REPROGRAMADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_PRIORIDADE(int id, int value)
        {
            var query = _query.UpdateFPR_PRIORIDADE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_INCLUSAO_FILA(int id, int value)
        {
            var query = _query.UpdateFPR_SEQ_INCLUSAO_FILA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_HIERARQUIA_SEQ_TRANSFORMACAO(int id, int value)
        {
            var query = _query.UpdateFPR_HIERARQUIA_SEQ_TRANSFORMACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_ID_ORIGEM(int id, int value)
        {
            var query = _query.UpdateFPR_ID_ORIGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_ENTREGA(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_ENTREGA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEQU_ID(int id, string value)
        {
            var query = _query.UpdateEQU_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_GRUPO_PRODUTIVO_MANUAL(int id, Decimal value)
        {
            var query = _query.UpdateFPR_GRUPO_PRODUTIVO_MANUAL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateFPR_EMISSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_MOTIVO_PULA_FILA(int id, string value)
        {
            var query = _query.UpdateFPR_MOTIVO_PULA_FILA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOCO_ID(int id, string value)
        {
            var query = _query.UpdateOCO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TOLERANCIA_MENOS(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TOLERANCIA_MENOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_TOLERANCIA_MAIS(int id, Decimal value)
        {
            var query = _query.UpdateFPR_TOLERANCIA_MAIS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_DATA_ENCERRAMENTO(int id, DateTime value)
        {
            var query = _query.UpdateFPR_DATA_ENCERRAMENTO(id, value);
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