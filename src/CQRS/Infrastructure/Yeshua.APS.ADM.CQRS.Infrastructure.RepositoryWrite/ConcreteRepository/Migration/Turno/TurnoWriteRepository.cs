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

namespace Input.Repository.Turno
{
    public partial class TurnoWriteRepository : ITurnoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITurnoQueryWrite _query; 

        public TurnoWriteRepository(IUnitOfWork unitOfWork,ITurnoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITurnoEntity Turno)
        {
            var query = _query.InserirTurnoQuery(Turno);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ITurnoEntity Turno)
        {
            var query = _query.UpdateTurnoQuery(Turno);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITurnoEntity Turno)
        {
            var query = _query.DeleteTurnoQuery(Turno);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDescricao(string id, string value)
        {
            var query = _query.UpdateDescricao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_PRIORIDADE(string id, int value)
        {
            var query = _query.UpdateTURN_PRIORIDADE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA1(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA1(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA1(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA1(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA2(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA2(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA2(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA3(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA3(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA3(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA4(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA4(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA4(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA4(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA5(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA5(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA5(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA5(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA6(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA6(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA6(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA6(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_INI_DIA7(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_INI_DIA7(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTURN_HORA_FIM_DIA7(string id, DateTime value)
        {
            var query = _query.UpdateTURN_HORA_FIM_DIA7(id, value);
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