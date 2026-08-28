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

namespace Input.Repository.Usuario
{
    public partial class UsuarioWriteRepository : IUsuarioWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IUsuarioQueryWrite _query; 

        public UsuarioWriteRepository(IUnitOfWork unitOfWork,IUsuarioQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IUsuarioEntity Usuario)
        {
            var query = _query.InserirUsuarioQuery(Usuario);
        Usuario.USE_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IUsuarioEntity Usuario)
        {
            var query = _query.UpdateUsuarioQuery(Usuario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IUsuarioEntity Usuario)
        {
            var query = _query.DeleteUsuarioQuery(Usuario);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_NOME(int use_id, string value)
        {
            var query = _query.UpdateUSE_NOME(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_EMAIL(int use_id, string value)
        {
            var query = _query.UpdateUSE_EMAIL(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_SENHA(int use_id, string value)
        {
            var query = _query.UpdateUSE_SENHA(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_ID(int use_id, string value)
        {
            var query = _query.UpdateTURM_ID(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_ATIVO(int use_id, int value)
        {
            var query = _query.UpdateUSE_ATIVO(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSE_CODERP(int use_id, string value)
        {
            var query = _query.UpdateUSE_CODERP(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int use_id, int value)
        {
            var query = _query.UpdateTenantID(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int use_id, bool value)
        {
            var query = _query.UpdateDeleted(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int use_id, DateTime value)
        {
            var query = _query.UpdateChanged(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int use_id, int value)
        {
            var query = _query.UpdateUserId(use_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration