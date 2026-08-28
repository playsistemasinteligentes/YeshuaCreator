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

namespace Input.Repository.Equipe
{
    public partial class EquipeWriteRepository : IEquipeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEquipeQueryWrite _query; 

        public EquipeWriteRepository(IUnitOfWork unitOfWork,IEquipeQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEquipeEntity Equipe)
        {
            var query = _query.InserirEquipeQuery(Equipe);
        Equipe.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IEquipeEntity Equipe)
        {
            var query = _query.UpdateEquipeQuery(Equipe);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEquipeEntity Equipe)
        {
            var query = _query.DeleteEquipeQuery(Equipe);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEQU_ID(int id, string value)
        {
            var query = _query.UpdateEQU_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEQU_HIERARQUIA_SEQ_TRANSFORMACAO(int id, Decimal value)
        {
            var query = _query.UpdateEQU_HIERARQUIA_SEQ_TRANSFORMACAO(id, value);
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