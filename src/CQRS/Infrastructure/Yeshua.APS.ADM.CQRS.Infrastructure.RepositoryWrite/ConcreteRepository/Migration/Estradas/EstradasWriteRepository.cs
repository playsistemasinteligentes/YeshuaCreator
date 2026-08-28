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

namespace Input.Repository.Estradas
{
    public partial class EstradasWriteRepository : IEstradasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEstradasQueryWrite _query; 

        public EstradasWriteRepository(IUnitOfWork unitOfWork,IEstradasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEstradasEntity Estradas)
        {
            var query = _query.InserirEstradasQuery(Estradas);
        Estradas.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEstradasEntity Estradas)
        {
            var query = _query.UpdateEstradasQuery(Estradas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEstradasEntity Estradas)
        {
            var query = _query.DeleteEstradasQuery(Estradas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_ID(int id, int value)
        {
            var query = _query.UpdateEST_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateEST_DESCRICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_ID_LIGACAO_PONTO_A(int id, int value)
        {
            var query = _query.UpdateEST_ID_LIGACAO_PONTO_A(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEST_ID_LIGACAO_PONTO_B(int id, int value)
        {
            var query = _query.UpdateEST_ID_LIGACAO_PONTO_B(id, value);
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