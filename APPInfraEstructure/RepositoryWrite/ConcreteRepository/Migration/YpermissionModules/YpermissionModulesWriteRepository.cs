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

namespace Input.Repository.YpermissionModules
{
    public class YpermissionModulesWriteRepository : IYpermissionModulesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYpermissionModulesQueryWrite _query; 

        public YpermissionModulesWriteRepository(IUnitOfWork unitOfWork,IYpermissionModulesQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYpermissionModulesEntity YpermissionModules)
        {
            var query = _query.InserirYpermissionModulesQuery(YpermissionModules);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYpermissionModulesEntity YpermissionModules)
        {
            var query = _query.UpdateYpermissionModulesQuery(YpermissionModules);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYpermissionModulesEntity YpermissionModules)
        {
            var query = _query.DeleteYpermissionModulesQuery(YpermissionModules);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IYpermissionModulesEntity entity)
        {
            var query = _query.UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration