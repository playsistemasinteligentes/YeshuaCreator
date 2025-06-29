using Dapper;
using Dominio.Entitys;
using Input.Querys.Y_Permtions;
using Repositorio.Inputs.Repositorio.Y_Permtions;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_Permtions
{
    public class Y_PermtionsWriteRepository : IY_PermtionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Y_PermtionsWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IY_PermtionsEntity Y_Permtions)
        {
            var query = new Y_PermtionsWriteQuery().InserirY_PermtionsQuery(Y_Permtions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IY_PermtionsEntity Y_Permtions)
        {
            var query = new Y_PermtionsWriteQuery().UpdateY_PermtionsQuery(Y_Permtions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IY_PermtionsEntity Y_Permtions)
        {
            var query = new Y_PermtionsWriteQuery().DeleteY_PermtionsQuery(Y_Permtions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration