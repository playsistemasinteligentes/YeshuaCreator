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
    public partial class PacienteWriteRepository : IPacienteWriteRepository
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
        public void UpdateNome(int id, string value)
        {
            var query = _query.UpdateNome(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefone(int id, string value)
        {
            var query = _query.UpdateTelefone(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataNascimento(int id, DateTime value)
        {
            var query = _query.UpdateDataNascimento(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGenero(int id, int value)
        {
            var query = _query.UpdateGenero(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEscolaridade(int id, string value)
        {
            var query = _query.UpdateEscolaridade(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProfissao(int id, string value)
        {
            var query = _query.UpdateProfissao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEndereco(int id, string value)
        {
            var query = _query.UpdateEndereco(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNomeResponsavel(int id, string value)
        {
            var query = _query.UpdateNomeResponsavel(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTelefoneResponsavel(int id, string value)
        {
            var query = _query.UpdateTelefoneResponsavel(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateObservacao(int id, string value)
        {
            var query = _query.UpdateObservacao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration