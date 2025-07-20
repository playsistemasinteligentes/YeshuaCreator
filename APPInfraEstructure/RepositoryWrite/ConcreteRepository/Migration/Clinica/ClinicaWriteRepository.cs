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

namespace Input.Repository.Clinica
{
    public class ClinicaWriteRepository : IClinicaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IClinicaQueryWrite _query; 

        public ClinicaWriteRepository(IUnitOfWork unitOfWork,IClinicaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IClinicaEntity Clinica)
        {
            var query = _query.InserirClinicaQuery(Clinica);
        Clinica.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IClinicaEntity Clinica)
        {
            var query = _query.UpdateClinicaQuery(Clinica);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IClinicaEntity Clinica)
        {
            var query = _query.DeleteClinicaQuery(Clinica);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IClinicaEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEndereco(IClinicaEntity entity)
        {
            var query = _query.UpdateEndereco(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefone(IClinicaEntity entity)
        {
            var query = _query.UpdateTelefone(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration