using Dapper;
using Dominio.Entitys;
using Input.Querys.Paciente;
using Repositorio.Inputs.Repositorio.Paciente;
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

        public PacienteWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IPacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().InserirPacienteQuery(Paciente);
        Paciente.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IPacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().UpdatePacienteQuery(Paciente);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IPacienteEntity Paciente)
        {
            var query = new PacienteWriteQuery().DeletePacienteQuery(Paciente);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefone(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateTelefone(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataNascimento(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateDataNascimento(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGenero(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateGenero(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEscolaridade(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateEscolaridade(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateProfissao(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateProfissao(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateEndereco(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateEndereco(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNomeResponsavel(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateNomeResponsavel(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateTelefoneResponsavel(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateTelefoneResponsavel(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdatePrincipaisQueixas(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdatePrincipaisQueixas(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateObservacaoAdicional(IPacienteEntity entity)
        {
            var query = new PacienteWriteQuery().UpdateObservacaoAdicional(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration