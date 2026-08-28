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

namespace Input.Repository.CorridasOnduladeira
{
    public partial class CorridasOnduladeiraWriteRepository : ICorridasOnduladeiraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICorridasOnduladeiraQueryWrite _query; 

        public CorridasOnduladeiraWriteRepository(IUnitOfWork unitOfWork,ICorridasOnduladeiraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICorridasOnduladeiraEntity CorridasOnduladeira)
        {
            var query = _query.InserirCorridasOnduladeiraQuery(CorridasOnduladeira);
        CorridasOnduladeira.COR_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICorridasOnduladeiraEntity CorridasOnduladeira)
        {
            var query = _query.UpdateCorridasOnduladeiraQuery(CorridasOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICorridasOnduladeiraEntity CorridasOnduladeira)
        {
            var query = _query.DeleteCorridasOnduladeiraQuery(CorridasOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID(int cor_id, string value)
        {
            var query = _query.UpdateBOL_ID(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateBOL_ID_ORIGEM(int cor_id, string value)
        {
            var query = _query.UpdateBOL_ID_ORIGEM(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_PECA(int cor_id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_PECA(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_LARGURA_PECA_PROGRAMADO(int cor_id, Decimal value)
        {
            var query = _query.UpdatePRO_LARGURA_PECA_PROGRAMADO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_PECA(int cor_id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_PECA(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int cor_id, Decimal value)
        {
            var query = _query.UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int cor_id, Decimal value)
        {
            var query = _query.UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_VINCOS_RECALCULADOS(int cor_id, string value)
        {
            var query = _query.UpdatePRO_VINCOS_RECALCULADOS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SOLVER(int cor_id, string value)
        {
            var query = _query.UpdateCOR_SOLVER(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_CUSTO_RESINA_PROGRAMADOS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_TOLERANCIA_MENOS(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_TOLERANCIA_MENOS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_TOLERANCIA_MAIS(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_TOLERANCIA_MAIS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_PILHAS_POR_PALETE(int cor_id, int value)
        {
            var query = _query.UpdateCOR_PILHAS_POR_PALETE(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_COR_FILA(int cor_id, string value)
        {
            var query = _query.UpdateCOR_COR_FILA(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_M_LINEAR_REALIZADO(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_M_LINEAR_REALIZADO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID_PALETE(int cor_id, string value)
        {
            var query = _query.UpdatePRO_ID_PALETE(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_STATUS_PALETE(int cor_id, string value)
        {
            var query = _query.UpdateCOR_STATUS_PALETE(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_GRUPO_PRODUTIVO(int cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_GRUPO_PRODUTIVO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int cor_id, int value)
        {
            var query = _query.UpdateTenantID(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int cor_id, bool value)
        {
            var query = _query.UpdateDeleted(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int cor_id, DateTime value)
        {
            var query = _query.UpdateChanged(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int cor_id, int value)
        {
            var query = _query.UpdateUserId(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_STATUS(int cor_id, string value)
        {
            var query = _query.UpdateCOR_STATUS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_STATUS_INTERFACE(int cor_id, string value)
        {
            var query = _query.UpdateCOR_STATUS_INTERFACE(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int cor_id, string value)
        {
            var query = _query.UpdateMAQ_ID(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_ID_INTERFACE(int cor_id, int value)
        {
            var query = _query.UpdateCOR_ID_INTERFACE(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA(int cor_id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_SEQUENCIA_ORIGEM(int cor_id, int value)
        {
            var query = _query.UpdateCOR_SEQUENCIA_ORIGEM(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int cor_id, string value)
        {
            var query = _query.UpdateORD_ID(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int cor_id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANFORMACAO(int cor_id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANFORMACAO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_FACAO(int cor_id, int value)
        {
            var query = _query.UpdateCOR_FACAO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_FORMATO_BOBINA(int cor_id, int value)
        {
            var query = _query.UpdateCOR_FORMATO_BOBINA(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_INICIO_PREVISTO(int cor_id, DateTime value)
        {
            var query = _query.UpdateCOR_INICIO_PREVISTO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_FIM_PREVISTO(int cor_id, DateTime value)
        {
            var query = _query.UpdateCOR_FIM_PREVISTO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int cor_id, string value)
        {
            var query = _query.UpdatePRO_ID(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_QTD_PLANEJADO(int cor_id, int value)
        {
            var query = _query.UpdateCOR_QTD_PLANEJADO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_QTD_PACAS(int cor_id, int value)
        {
            var query = _query.UpdatePRO_QTD_PACAS(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_PECAS_LARGURA(int cor_id, int value)
        {
            var query = _query.UpdateCOR_PECAS_LARGURA(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration