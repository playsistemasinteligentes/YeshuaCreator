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

namespace Input.Repository.T_AGENDA_SCHEDULE
{
    public partial class T_AGENDA_SCHEDULEWriteRepository : IT_AGENDA_SCHEDULEWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IT_AGENDA_SCHEDULEQueryWrite _query; 

        public T_AGENDA_SCHEDULEWriteRepository(IUnitOfWork unitOfWork,IT_AGENDA_SCHEDULEQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE)
        {
            var query = _query.InserirT_AGENDA_SCHEDULEQuery(T_AGENDA_SCHEDULE);
        T_AGENDA_SCHEDULE.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE)
        {
            var query = _query.UpdateT_AGENDA_SCHEDULEQuery(T_AGENDA_SCHEDULE);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IT_AGENDA_SCHEDULEEntity T_AGENDA_SCHEDULE)
        {
            var query = _query.DeleteT_AGENDA_SCHEDULEQuery(T_AGENDA_SCHEDULE);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_ID(int id, int value)
        {
            var query = _query.UpdateAGE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_DATA_ESPECIFICA(int id, DateTime value)
        {
            var query = _query.UpdateAGE_DATA_ESPECIFICA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_HORARIO_INICIO(int id, string value)
        {
            var query = _query.UpdateAGE_HORARIO_INICIO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_HORARIO_FIM(int id, string value)
        {
            var query = _query.UpdateAGE_HORARIO_FIM(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_SEGUNDA(int id, string value)
        {
            var query = _query.UpdateAGE_SEGUNDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_TERCA(int id, string value)
        {
            var query = _query.UpdateAGE_TERCA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_QUARTA(int id, string value)
        {
            var query = _query.UpdateAGE_QUARTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_QUINTA(int id, string value)
        {
            var query = _query.UpdateAGE_QUINTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_SEXTA(int id, string value)
        {
            var query = _query.UpdateAGE_SEXTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_SABADO(int id, string value)
        {
            var query = _query.UpdateAGE_SABADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_DOMINGO(int id, string value)
        {
            var query = _query.UpdateAGE_DOMINGO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_INTERVALO(int id, Decimal value)
        {
            var query = _query.UpdateAGE_INTERVALO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_ORDEM_EXECUCAO(int id, string value)
        {
            var query = _query.UpdateAGE_ORDEM_EXECUCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_PARAMETROS(int id, string value)
        {
            var query = _query.UpdateAGE_PARAMETROS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_EXCECAO(int id, string value)
        {
            var query = _query.UpdateAGE_EXCECAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAGE_DESCRICAO(int id, string value)
        {
            var query = _query.UpdateAGE_DESCRICAO(id, value);
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