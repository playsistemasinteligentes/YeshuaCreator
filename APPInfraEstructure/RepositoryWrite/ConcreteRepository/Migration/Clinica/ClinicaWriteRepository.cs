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
    public partial class ClinicaWriteRepository : IClinicaWriteRepository
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
        Clinica.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IClinicaEntity Clinica)
        {
            var query = _query.UpdateClinicaQuery(Clinica);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IClinicaEntity Clinica)
        {
            var query = _query.DeleteClinicaQuery(Clinica);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(IClinicaEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEndereco(IClinicaEntity entity)
        {
            var query = _query.UpdateEndereco(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefone(IClinicaEntity entity)
        {
            var query = _query.UpdateTelefone(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IClinicaEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IClinicaEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IClinicaEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IClinicaEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration