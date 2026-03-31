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

namespace Input.Repository.Paciente
{
    public class PacienteWriteRepository : IPacienteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPacienteQueryWrite _query; 

        public PacienteWriteRepository(IUnitOfWork unitOfWork,IPacienteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPacienteEntity Paciente)
        {
            var query = _query.InserirPacienteQuery(Paciente);
        Paciente.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPacienteEntity Paciente)
        {
            var query = _query.UpdatePacienteQuery(Paciente);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPacienteEntity Paciente)
        {
            var query = _query.DeletePacienteQuery(Paciente);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(IPacienteEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefone(IPacienteEntity entity)
        {
            var query = _query.UpdateTelefone(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataNascimento(IPacienteEntity entity)
        {
            var query = _query.UpdateDataNascimento(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGenero(IPacienteEntity entity)
        {
            var query = _query.UpdateGenero(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEscolaridade(IPacienteEntity entity)
        {
            var query = _query.UpdateEscolaridade(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProfissao(IPacienteEntity entity)
        {
            var query = _query.UpdateProfissao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEndereco(IPacienteEntity entity)
        {
            var query = _query.UpdateEndereco(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNomeResponsavel(IPacienteEntity entity)
        {
            var query = _query.UpdateNomeResponsavel(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefoneResponsavel(IPacienteEntity entity)
        {
            var query = _query.UpdateTelefoneResponsavel(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObservacao(IPacienteEntity entity)
        {
            var query = _query.UpdateObservacao(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IPacienteEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IPacienteEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IPacienteEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IPacienteEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration