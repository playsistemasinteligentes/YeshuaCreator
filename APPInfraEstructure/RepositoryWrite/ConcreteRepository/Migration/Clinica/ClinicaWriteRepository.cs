using Dapper;
using Dominio.Entitys;
using Input.Querys.Clinica;
using Repositorio.Inputs.Repositorio.Clinica;
using RepositoryInterfaces.Services;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Repository.Clinica
{
    public class ClinicaWriteRepository : IClinicaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ClinicaWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(ClinicaEntity Clinica)
        {
            var query = new ClinicaWriteQuery().InserirClinicaQuery(Clinica);
        Clinica.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(ClinicaEntity Clinica)
        {
            var query = new ClinicaWriteQuery().UpdateClinicaQuery(Clinica);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(ClinicaEntity Clinica)
        {
            var query = new ClinicaWriteQuery().DeleteClinicaQuery(Clinica);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration