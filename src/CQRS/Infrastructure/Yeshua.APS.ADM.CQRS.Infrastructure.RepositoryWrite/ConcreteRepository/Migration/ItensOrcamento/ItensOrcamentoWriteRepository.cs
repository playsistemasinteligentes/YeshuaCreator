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

namespace Input.Repository.ItensOrcamento
{
    public partial class ItensOrcamentoWriteRepository : IItensOrcamentoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItensOrcamentoQueryWrite _query; 

        public ItensOrcamentoWriteRepository(IUnitOfWork unitOfWork,IItensOrcamentoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItensOrcamentoEntity ItensOrcamento)
        {
            var query = _query.InserirItensOrcamentoQuery(ItensOrcamento);
        ItensOrcamento.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItensOrcamentoEntity ItensOrcamento)
        {
            var query = _query.UpdateItensOrcamentoQuery(ItensOrcamento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItensOrcamentoEntity ItensOrcamento)
        {
            var query = _query.DeleteItensOrcamentoQuery(ItensOrcamento);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_ID(int id, int value)
        {
            var query = _query.UpdateITO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORC_ID(int id, int value)
        {
            var query = _query.UpdateORC_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(int id, int value)
        {
            var query = _query.UpdateTIP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int id, string value)
        {
            var query = _query.UpdatePRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_OBS(int id, string value)
        {
            var query = _query.UpdateITO_OBS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_QUANTIDADE(int id, Decimal value)
        {
            var query = _query.UpdateITO_QUANTIDADE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_CUSTO(int id, Decimal value)
        {
            var query = _query.UpdateITO_CUSTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_MARGEM(int id, Decimal value)
        {
            var query = _query.UpdateITO_MARGEM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_VALOR_UNITARIO(int id, Decimal value)
        {
            var query = _query.UpdateITO_VALOR_UNITARIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_VERSSAO_CUSTO(int id, DateTime value)
        {
            var query = _query.UpdateITO_VERSSAO_CUSTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_STATUS(int id, string value)
        {
            var query = _query.UpdateITO_STATUS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_ERP_CUSTOS_FIXOS(int id, Decimal value)
        {
            var query = _query.UpdateITO_ERP_CUSTOS_FIXOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_ERP_CUSTOS_VARIAVEIS(int id, Decimal value)
        {
            var query = _query.UpdateITO_ERP_CUSTOS_VARIAVEIS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_ERP_DESPESAS_VAR_VENDA(int id, Decimal value)
        {
            var query = _query.UpdateITO_ERP_DESPESAS_VAR_VENDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_ERP_IMPOSTOS(int id, Decimal value)
        {
            var query = _query.UpdateITO_ERP_IMPOSTOS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID_COMPOSICAO(int id, string value)
        {
            var query = _query.UpdateGRP_ID_COMPOSICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_LARGURA(int id, Decimal value)
        {
            var query = _query.UpdateITO_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITO_COMPRIMENTO(int id, Decimal value)
        {
            var query = _query.UpdateITO_COMPRIMENTO(id, value);
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