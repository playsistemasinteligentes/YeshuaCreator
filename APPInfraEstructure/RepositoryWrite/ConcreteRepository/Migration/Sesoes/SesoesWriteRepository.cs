using Dapper;
using Dominio.Entitys;
using Input.Querys.Sesoes;
using Repositorio.Inputs.Repositorio.Sesoes;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Sesoes
{
    public class SesoesWriteRepository : ISesoesWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public SesoesWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(SesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().InserirSesoesQuery(Sesoes);
        Sesoes.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(SesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().UpdateSesoesQuery(Sesoes);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(SesoesEntity Sesoes)
        {
            var query = new SesoesWriteQuery().DeleteSesoesQuery(Sesoes);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration