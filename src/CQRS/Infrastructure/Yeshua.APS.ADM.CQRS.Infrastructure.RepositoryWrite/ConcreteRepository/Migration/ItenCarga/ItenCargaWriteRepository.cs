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

namespace Input.Repository.ItenCarga
{
    public partial class ItenCargaWriteRepository : IItenCargaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItenCargaQueryWrite _query; 

        public ItenCargaWriteRepository(IUnitOfWork unitOfWork,IItenCargaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItenCargaEntity ItenCarga)
        {
            var query = _query.InserirItenCargaQuery(ItenCarga);
        ItenCarga.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItenCargaEntity ItenCarga)
        {
            var query = _query.UpdateItenCargaQuery(ItenCarga);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItenCargaEntity ItenCarga)
        {
            var query = _query.DeleteItenCargaQuery(ItenCarga);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCAR_ID(int id, string value)
        {
            var query = _query.UpdateCAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITC_ENTREGA_PLANEJADA(int id, DateTime value)
        {
            var query = _query.UpdateITC_ENTREGA_PLANEJADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITC_ENTREGA_REALIZADA(int id, DateTime value)
        {
            var query = _query.UpdateITC_ENTREGA_REALIZADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITC_ORDEM_ENTREGA(int id, int value)
        {
            var query = _query.UpdateITC_ORDEM_ENTREGA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITC_QTD_PLANEJADA(int id, Decimal value)
        {
            var query = _query.UpdateITC_QTD_PLANEJADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITC_QTD_REALIZADA(int id, Decimal value)
        {
            var query = _query.UpdateITC_QTD_REALIZADA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_HASH_KEY(int id, string value)
        {
            var query = _query.UpdateORD_HASH_KEY(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNOT_ID(int id, string value)
        {
            var query = _query.UpdateNOT_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNOT_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateNOT_EMISSAO(id, value);
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