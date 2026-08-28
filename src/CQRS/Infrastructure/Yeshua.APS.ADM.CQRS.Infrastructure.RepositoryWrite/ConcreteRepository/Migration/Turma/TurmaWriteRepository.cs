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

namespace Input.Repository.Turma
{
    public partial class TurmaWriteRepository : ITurmaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITurmaQueryWrite _query; 

        public TurmaWriteRepository(IUnitOfWork unitOfWork,ITurmaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITurmaEntity Turma)
        {
            var query = _query.InserirTurmaQuery(Turma);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ITurmaEntity Turma)
        {
            var query = _query.UpdateTurmaQuery(Turma);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITurmaEntity Turma)
        {
            var query = _query.DeleteTurmaQuery(Turma);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(string id, string value)
        {
            var query = _query.UpdateDescricao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA1(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA1(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA1(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA1(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA2(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA2(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA3(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA3(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA4(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA4(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA4(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA4(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA5(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA5(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA5(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA5(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA6(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA6(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA6(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA6(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_INI_DIA7(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_INI_DIA7(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURM_HORA_FIM_DIA7(string id, DateTime value)
        {
            var query = _query.UpdateTURM_HORA_FIM_DIA7(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration