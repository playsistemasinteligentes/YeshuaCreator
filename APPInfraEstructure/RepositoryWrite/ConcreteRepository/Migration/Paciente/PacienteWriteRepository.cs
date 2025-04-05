using Dapper;
using Dominio.Entitys.Paciente;
using Input.Querys.Paciente;
using Repositorio.Inputs.Repositorio.Paciente;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Paciente
{
    public class PacienteWriteRepository : IPacienteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public PacienteWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(PacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().InserirPacienteQuery(Paciente);
        Paciente.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(PacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().UpdatePacienteQuery(Paciente);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(PacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().DeletePacienteQuery(Paciente);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration