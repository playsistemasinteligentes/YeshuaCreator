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

namespace Input.Repository.SubOcorrencia
{
    public partial class SubOcorrenciaWriteRepository : ISubOcorrenciaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ISubOcorrenciaQueryWrite _query; 

        public SubOcorrenciaWriteRepository(IUnitOfWork unitOfWork,ISubOcorrenciaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ISubOcorrenciaEntity SubOcorrencia)
        {
            var query = _query.InserirSubOcorrenciaQuery(SubOcorrencia);
        SubOcorrencia.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ISubOcorrenciaEntity SubOcorrencia)
        {
            var query = _query.UpdateSubOcorrenciaQuery(SubOcorrencia);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ISubOcorrenciaEntity SubOcorrencia)
        {
            var query = _query.DeleteSubOcorrenciaQuery(SubOcorrencia);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSUB_ID(int id, string value)
        {
            var query = _query.UpdateSUB_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSUB_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateSUB_DESCRICAO(id, value);
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