using Dapper;
using Dominio.Entitys;
using Input.Querys.Yuser;
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

namespace Input.Repository.Yuser
{
    public class YuserWriteRepository : IYuserWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public YuserWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IYuserEntity Yuser)
        {
            var query = new YuserWriteQuery().InserirYuserQuery(Yuser);
        Yuser.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYuserEntity Yuser)
        {
            var query = new YuserWriteQuery().UpdateYuserQuery(Yuser);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYuserEntity Yuser)
        {
            var query = new YuserWriteQuery().DeleteYuserQuery(Yuser);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IYuserEntity entity)
        {
            var query = new YuserWriteQuery().UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEmail(IYuserEntity entity)
        {
            var query = new YuserWriteQuery().UpdateEmail(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateSenha(IYuserEntity entity)
        {
            var query = new YuserWriteQuery().UpdateSenha(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IYuserEntity entity)
        {
            var query = new YuserWriteQuery().UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration