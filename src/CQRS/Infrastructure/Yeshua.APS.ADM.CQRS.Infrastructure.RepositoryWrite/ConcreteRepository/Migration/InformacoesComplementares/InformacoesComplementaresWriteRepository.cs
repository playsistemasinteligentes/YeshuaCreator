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

namespace Input.Repository.InformacoesComplementares
{
    public partial class InformacoesComplementaresWriteRepository : IInformacoesComplementaresWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IInformacoesComplementaresQueryWrite _query; 

        public InformacoesComplementaresWriteRepository(IUnitOfWork unitOfWork,IInformacoesComplementaresQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IInformacoesComplementaresEntity InformacoesComplementares)
        {
            var query = _query.InserirInformacoesComplementaresQuery(InformacoesComplementares);
        InformacoesComplementares.INF_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IInformacoesComplementaresEntity InformacoesComplementares)
        {
            var query = _query.UpdateInformacoesComplementaresQuery(InformacoesComplementares);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IInformacoesComplementaresEntity InformacoesComplementares)
        {
            var query = _query.DeleteInformacoesComplementaresQuery(InformacoesComplementares);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateINF_DESCRICAO(int inf_id, string value)
        {
            var query = _query.UpdateINF_DESCRICAO(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateINF_VALOR(int inf_id, Decimal value)
        {
            var query = _query.UpdateINF_VALOR(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMET_ID(int inf_id, int value)
        {
            var query = _query.UpdateMET_ID(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateINF_DATA(int inf_id, string value)
        {
            var query = _query.UpdateINF_DATA(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int inf_id, int value)
        {
            var query = _query.UpdateTenantID(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int inf_id, bool value)
        {
            var query = _query.UpdateDeleted(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int inf_id, DateTime value)
        {
            var query = _query.UpdateChanged(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int inf_id, int value)
        {
            var query = _query.UpdateUserId(inf_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration