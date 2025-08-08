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
        Paciente.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IPacienteEntity Paciente)
        {
            var query = _query.UpdatePacienteQuery(Paciente);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IPacienteEntity Paciente)
        {
            var query = _query.DeletePacienteQuery(Paciente);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IPacienteEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefone(IPacienteEntity entity)
        {
            var query = _query.UpdateTelefone(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataNascimento(IPacienteEntity entity)
        {
            var query = _query.UpdateDataNascimento(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGenero(IPacienteEntity entity)
        {
            var query = _query.UpdateGenero(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEscolaridade(IPacienteEntity entity)
        {
            var query = _query.UpdateEscolaridade(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateProfissao(IPacienteEntity entity)
        {
            var query = _query.UpdateProfissao(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEndereco(IPacienteEntity entity)
        {
            var query = _query.UpdateEndereco(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNomeResponsavel(IPacienteEntity entity)
        {
            var query = _query.UpdateNomeResponsavel(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefoneResponsavel(IPacienteEntity entity)
        {
            var query = _query.UpdateTelefoneResponsavel(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePrincipaisQueixas(IPacienteEntity entity)
        {
            var query = _query.UpdatePrincipaisQueixas(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateObservacaoAdicional(IPacienteEntity entity)
        {
            var query = _query.UpdateObservacaoAdicional(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTenantID(IPacienteEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDeleted(IPacienteEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateChanged(IPacienteEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateUserId(IPacienteEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration