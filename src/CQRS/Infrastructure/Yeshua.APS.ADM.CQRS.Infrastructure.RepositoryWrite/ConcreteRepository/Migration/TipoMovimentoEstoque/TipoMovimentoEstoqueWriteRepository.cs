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

namespace Input.Repository.TipoMovimentoEstoque
{
    public partial class TipoMovimentoEstoqueWriteRepository : ITipoMovimentoEstoqueWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoMovimentoEstoqueQueryWrite _query; 

        public TipoMovimentoEstoqueWriteRepository(IUnitOfWork unitOfWork,ITipoMovimentoEstoqueQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque)
        {
            var query = _query.InserirTipoMovimentoEstoqueQuery(TipoMovimentoEstoque);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque)
        {
            var query = _query.UpdateTipoMovimentoEstoqueQuery(TipoMovimentoEstoque);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque)
        {
            var query = _query.DeleteTipoMovimentoEstoqueQuery(TipoMovimentoEstoque);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_DESCRICAO(string tip_id, string value)
        {
            var query = _query.UpdateTIP_DESCRICAO(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_TYPE(string tip_id, int value)
        {
            var query = _query.UpdateTIP_TYPE(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSPR(string tip_id, int value)
        {
            var query = _query.UpdateSPR(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string tip_id, int value)
        {
            var query = _query.UpdateTenantID(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string tip_id, bool value)
        {
            var query = _query.UpdateDeleted(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string tip_id, DateTime value)
        {
            var query = _query.UpdateChanged(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string tip_id, int value)
        {
            var query = _query.UpdateUserId(tip_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration