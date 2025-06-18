using Dapper;
using Dominio.Entitys;
using Input.Querys.Especialidade;
using Repositorio.Inputs.Repositorio.Especialidade;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Especialidade
{
    public class EspecialidadeWriteRepository : IEspecialidadeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public EspecialidadeWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(EspecialidadeEntity Especialidade)
        {
            var query = new EspecialidadeWriteQuery().InserirEspecialidadeQuery(Especialidade);
        Especialidade.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(EspecialidadeEntity Especialidade)
        {
            var query = new EspecialidadeWriteQuery().UpdateEspecialidadeQuery(Especialidade);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(EspecialidadeEntity Especialidade)
        {
            var query = new EspecialidadeWriteQuery().DeleteEspecialidadeQuery(Especialidade);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration