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

namespace Input.Repository.CalendarioDisponibilidadeVeiculos
{
    public partial class CalendarioDisponibilidadeVeiculosWriteRepository : ICalendarioDisponibilidadeVeiculosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICalendarioDisponibilidadeVeiculosQueryWrite _query; 

        public CalendarioDisponibilidadeVeiculosWriteRepository(IUnitOfWork unitOfWork,ICalendarioDisponibilidadeVeiculosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos)
        {
            var query = _query.InserirCalendarioDisponibilidadeVeiculosQuery(CalendarioDisponibilidadeVeiculos);
        CalendarioDisponibilidadeVeiculos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos)
        {
            var query = _query.UpdateCalendarioDisponibilidadeVeiculosQuery(CalendarioDisponibilidadeVeiculos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICalendarioDisponibilidadeVeiculosEntity CalendarioDisponibilidadeVeiculos)
        {
            var query = _query.DeleteCalendarioDisponibilidadeVeiculosQuery(CalendarioDisponibilidadeVeiculos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_ID(int id, int value)
        {
            var query = _query.UpdateCDV_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_DATA_DE(int id, DateTime value)
        {
            var query = _query.UpdateCDV_DATA_DE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_DATA_ATE(int id, DateTime value)
        {
            var query = _query.UpdateCDV_DATA_ATE(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_SEGUNDA(int id, int value)
        {
            var query = _query.UpdateCDV_SEGUNDA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_TERCA(int id, int value)
        {
            var query = _query.UpdateCDV_TERCA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_QUARTA(int id, int value)
        {
            var query = _query.UpdateCDV_QUARTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_QUINTA(int id, int value)
        {
            var query = _query.UpdateCDV_QUINTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_SEXTA(int id, int value)
        {
            var query = _query.UpdateCDV_SEXTA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_SABADO(int id, int value)
        {
            var query = _query.UpdateCDV_SABADO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_DOMINGO(int id, int value)
        {
            var query = _query.UpdateCDV_DOMINGO(id, value);
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