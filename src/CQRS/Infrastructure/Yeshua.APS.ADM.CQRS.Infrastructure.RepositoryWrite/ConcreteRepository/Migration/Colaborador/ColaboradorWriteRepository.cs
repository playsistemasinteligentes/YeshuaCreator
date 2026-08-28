// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration
// </yeshua>

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

namespace Input.Repository.Colaborador
{
    public partial class ColaboradorWriteRepository : IColaboradorWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IColaboradorQueryWrite _query; 

        public ColaboradorWriteRepository(IUnitOfWork unitOfWork,IColaboradorQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IColaboradorEntity Colaborador)
        {
            var query = _query.InserirColaboradorQuery(Colaborador);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IColaboradorEntity Colaborador)
        {
            var query = _query.UpdateColaboradorQuery(Colaborador);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IColaboradorEntity Colaborador)
        {
            var query = _query.DeleteColaboradorQuery(Colaborador);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOL_NOME(string col_cpf, string value)
        {
            var query = _query.UpdateCOL_NOME(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOL_NASCIMENTO(string col_cpf, DateTime value)
        {
            var query = _query.UpdateCOL_NASCIMENTO(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOL_EMAIL(string col_cpf, string value)
        {
            var query = _query.UpdateCOL_EMAIL(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOL_MATRICULA(string col_cpf, string value)
        {
            var query = _query.UpdateCOL_MATRICULA(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_id(string col_cpf, string value)
        {
            var query = _query.UpdateTURM_id(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string col_cpf, int value)
        {
            var query = _query.UpdateTenantID(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string col_cpf, bool value)
        {
            var query = _query.UpdateDeleted(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string col_cpf, DateTime value)
        {
            var query = _query.UpdateChanged(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string col_cpf, int value)
        {
            var query = _query.UpdateUserId(col_cpf, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration