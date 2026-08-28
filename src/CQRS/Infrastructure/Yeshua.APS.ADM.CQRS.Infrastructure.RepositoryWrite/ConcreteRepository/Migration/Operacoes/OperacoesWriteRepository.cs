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

namespace Input.Repository.Operacoes
{
    public partial class OperacoesWriteRepository : IOperacoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOperacoesQueryWrite _query; 

        public OperacoesWriteRepository(IUnitOfWork unitOfWork,IOperacoesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOperacoesEntity Operacoes)
        {
            var query = _query.InserirOperacoesQuery(Operacoes);
        Operacoes.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IOperacoesEntity Operacoes)
        {
            var query = _query.UpdateOperacoesQuery(Operacoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOperacoesEntity Operacoes)
        {
            var query = _query.DeleteOperacoesQuery(Operacoes);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOPE_TIPO_REGISTRO(int id, string value)
        {
            var query = _query.UpdateOPE_TIPO_REGISTRO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOPE_ID(int id, string value)
        {
            var query = _query.UpdateOPE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGMA_ID(int id, string value)
        {
            var query = _query.UpdateGMA_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int id, string value)
        {
            var query = _query.UpdateMAQ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int id, string value)
        {
            var query = _query.UpdatePRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOPE_EXCECAO(int id, string value)
        {
            var query = _query.UpdateOPE_EXCECAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROT_SEQ_TRANFORMACAO(int id, int value)
        {
            var query = _query.UpdateROT_SEQ_TRANFORMACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(id, value);
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