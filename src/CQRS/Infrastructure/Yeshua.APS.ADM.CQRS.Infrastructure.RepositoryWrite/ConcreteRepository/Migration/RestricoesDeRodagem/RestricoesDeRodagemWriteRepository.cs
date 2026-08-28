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

namespace Input.Repository.RestricoesDeRodagem
{
    public partial class RestricoesDeRodagemWriteRepository : IRestricoesDeRodagemWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IRestricoesDeRodagemQueryWrite _query; 

        public RestricoesDeRodagemWriteRepository(IUnitOfWork unitOfWork,IRestricoesDeRodagemQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IRestricoesDeRodagemEntity RestricoesDeRodagem)
        {
            var query = _query.InserirRestricoesDeRodagemQuery(RestricoesDeRodagem);
        RestricoesDeRodagem.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IRestricoesDeRodagemEntity RestricoesDeRodagem)
        {
            var query = _query.UpdateRestricoesDeRodagemQuery(RestricoesDeRodagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IRestricoesDeRodagemEntity RestricoesDeRodagem)
        {
            var query = _query.DeleteRestricoesDeRodagemQuery(RestricoesDeRodagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRES_ID(int id, int value)
        {
            var query = _query.UpdateRES_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRES_TIPO(int id, string value)
        {
            var query = _query.UpdateRES_TIPO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRES_HORA_INI(int id, string value)
        {
            var query = _query.UpdateRES_HORA_INI(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRES_HORA_FIM(int id, string value)
        {
            var query = _query.UpdateRES_HORA_FIM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateRES_VELOCIDADE_HORA_RUSH(int id, Decimal value)
        {
            var query = _query.UpdateRES_VELOCIDADE_HORA_RUSH(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTVE_ID(int id, int value)
        {
            var query = _query.UpdateTVE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAP_ID(int id, int value)
        {
            var query = _query.UpdateMAP_ID(id, value);
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