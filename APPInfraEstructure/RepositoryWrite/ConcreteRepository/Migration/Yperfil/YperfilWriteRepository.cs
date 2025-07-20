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

namespace Input.Repository.Yperfil
{
    public class YperfilWriteRepository : IYperfilWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYperfilQueryWrite _query; 

        public YperfilWriteRepository(IUnitOfWork unitOfWork,IYperfilQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYperfilEntity Yperfil)
        {
            var query = _query.InserirYperfilQuery(Yperfil);
        Yperfil.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYperfilEntity Yperfil)
        {
            var query = _query.UpdateYperfilQuery(Yperfil);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYperfilEntity Yperfil)
        {
            var query = _query.DeleteYperfilQuery(Yperfil);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDescription(IYperfilEntity entity)
        {
            var query = _query.UpdateDescription(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration