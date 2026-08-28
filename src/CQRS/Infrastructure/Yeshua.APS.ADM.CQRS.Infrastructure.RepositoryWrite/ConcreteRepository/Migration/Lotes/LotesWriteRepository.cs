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

namespace Input.Repository.Lotes
{
    public partial class LotesWriteRepository : ILotesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ILotesQueryWrite _query; 

        public LotesWriteRepository(IUnitOfWork unitOfWork,ILotesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ILotesEntity Lotes)
        {
            var query = _query.InserirLotesQuery(Lotes);
        Lotes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ILotesEntity Lotes)
        {
            var query = _query.UpdateLotesQuery(Lotes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ILotesEntity Lotes)
        {
            var query = _query.DeleteLotesQuery(Lotes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_LOTE(int id, string value)
        {
            var query = _query.UpdateMOV_LOTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_SUB_LOTE(int id, string value)
        {
            var query = _query.UpdateMOV_SUB_LOTE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOT_LARGURA(int id, Decimal value)
        {
            var query = _query.UpdateLOT_LARGURA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOT_COMPRIMENTO(int id, Decimal value)
        {
            var query = _query.UpdateLOT_COMPRIMENTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLOT_DIAMETRO(int id, Decimal value)
        {
            var query = _query.UpdateLOT_DIAMETRO(id, value);
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