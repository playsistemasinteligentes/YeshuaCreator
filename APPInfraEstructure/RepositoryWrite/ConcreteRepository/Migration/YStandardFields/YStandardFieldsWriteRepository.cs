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

namespace Input.Repository.YStandardFields
{
    public class YStandardFieldsWriteRepository : IYStandardFieldsWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IYStandardFieldsQueryWrite _query; 

        public YStandardFieldsWriteRepository(IUnitOfWork unitOfWork,IYStandardFieldsQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IYStandardFieldsEntity YStandardFields)
        {
            var query = _query.InserirYStandardFieldsQuery(YStandardFields);
                _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IYStandardFieldsEntity YStandardFields)
        {
            var query = _query.UpdateYStandardFieldsQuery(YStandardFields);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IYStandardFieldsEntity YStandardFields)
        {
            var query = _query.DeleteYStandardFieldsQuery(YStandardFields);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration