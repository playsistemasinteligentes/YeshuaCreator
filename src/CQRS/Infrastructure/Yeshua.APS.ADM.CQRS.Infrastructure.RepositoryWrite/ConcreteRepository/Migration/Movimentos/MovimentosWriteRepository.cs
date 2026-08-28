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

namespace Input.Repository.Movimentos
{
    public partial class MovimentosWriteRepository : IMovimentosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMovimentosQueryWrite _query; 

        public MovimentosWriteRepository(IUnitOfWork unitOfWork,IMovimentosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMovimentosEntity Movimentos)
        {
            var query = _query.InserirMovimentosQuery(Movimentos);
        Movimentos.MOV_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMovimentosEntity Movimentos)
        {
            var query = _query.UpdateMovimentosQuery(Movimentos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMovimentosEntity Movimentos)
        {
            var query = _query.DeleteMovimentosQuery(Movimentos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_DATA(int mov_id, string value)
        {
            var query = _query.UpdateMOV_DATA(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_VALOR(int mov_id, Decimal value)
        {
            var query = _query.UpdateMOV_VALOR(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_PLAID(int mov_id, int value)
        {
            var query = _query.UpdateMOV_PLAID(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMOV_UNID(int mov_id, int value)
        {
            var query = _query.UpdateMOV_UNID(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTr_Unidade_UNI_ID(int mov_id, int value)
        {
            var query = _query.UpdateTr_Unidade_UNI_ID(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int mov_id, int value)
        {
            var query = _query.UpdateTenantID(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int mov_id, bool value)
        {
            var query = _query.UpdateDeleted(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int mov_id, DateTime value)
        {
            var query = _query.UpdateChanged(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int mov_id, int value)
        {
            var query = _query.UpdateUserId(mov_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration