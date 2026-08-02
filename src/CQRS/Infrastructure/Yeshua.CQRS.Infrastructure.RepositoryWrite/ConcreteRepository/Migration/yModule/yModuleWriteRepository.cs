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

namespace Input.Repository.yModule
{
    public partial class yModuleWriteRepository : IyModuleWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IyModuleQueryWrite _query; 

        public yModuleWriteRepository(IUnitOfWork unitOfWork,IyModuleQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IyModuleEntity yModule)
        {
            var query = _query.InseriryModuleQuery(yModule);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IyModuleEntity yModule)
        {
            var query = _query.UpdateyModuleQuery(yModule);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IyModuleEntity yModule)
        {
            var query = _query.DeleteyModuleQuery(yModule);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescription(string id, string value)
        {
            var query = _query.UpdateDescription(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration