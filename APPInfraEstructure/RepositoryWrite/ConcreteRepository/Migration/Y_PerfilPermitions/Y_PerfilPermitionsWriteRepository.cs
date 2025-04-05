using Dapper;
using Dominio.Entitys.Y_PerfilPermitions;
using Input.Querys.Y_PerfilPermitions;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Y_PerfilPermitions
{
    public class Y_PerfilPermitionsWriteRepository : IY_PerfilPermitionsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public Y_PerfilPermitionsWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(Y_PerfilPermitionsEntity Y_PerfilPermitions)
        {
            var query = new Y_PerfilPermitionsWriteQuery().InserirY_PerfilPermitionsQuery(Y_PerfilPermitions);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }

        public void Update(Y_PerfilPermitionsEntity Y_PerfilPermitions)
        {
            var query = new Y_PerfilPermitionsWriteQuery().UpdateY_PerfilPermitionsQuery(Y_PerfilPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(Y_PerfilPermitionsEntity Y_PerfilPermitions)
        {
            var query = new Y_PerfilPermitionsWriteQuery().DeleteY_PerfilPermitionsQuery(Y_PerfilPermitions);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration