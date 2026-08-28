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

namespace Input.Repository.Perfil
{
    public partial class PerfilWriteRepository : IPerfilWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPerfilQueryWrite _query; 

        public PerfilWriteRepository(IUnitOfWork unitOfWork,IPerfilQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPerfilEntity Perfil)
        {
            var query = _query.InserirPerfilQuery(Perfil);
        Perfil.PER_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPerfilEntity Perfil)
        {
            var query = _query.UpdatePerfilQuery(Perfil);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPerfilEntity Perfil)
        {
            var query = _query.DeletePerfilQuery(Perfil);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePER_NOME(int per_id, string value)
        {
            var query = _query.UpdatePER_NOME(per_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int per_id, int value)
        {
            var query = _query.UpdateTenantID(per_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int per_id, bool value)
        {
            var query = _query.UpdateDeleted(per_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int per_id, DateTime value)
        {
            var query = _query.UpdateChanged(per_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int per_id, int value)
        {
            var query = _query.UpdateUserId(per_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration