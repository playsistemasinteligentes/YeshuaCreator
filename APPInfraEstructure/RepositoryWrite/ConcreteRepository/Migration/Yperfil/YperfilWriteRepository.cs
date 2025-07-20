using Dapper;
using Dominio.Entitys;
using Input.Querys.Yperfil;
using IRepository.Write;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Yperfil
{
    public class YperfilWriteRepository : IYperfilWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public YperfilWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IYperfilEntity Yperfil)
        {
            var query = new YperfilWriteQuery().InserirYperfilQuery(Yperfil);
        Yperfil.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYperfilEntity Yperfil)
        {
            var query = new YperfilWriteQuery().UpdateYperfilQuery(Yperfil);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYperfilEntity Yperfil)
        {
            var query = new YperfilWriteQuery().DeleteYperfilQuery(Yperfil);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IYperfilEntity entity)
        {
            var query = new YperfilWriteQuery().UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration