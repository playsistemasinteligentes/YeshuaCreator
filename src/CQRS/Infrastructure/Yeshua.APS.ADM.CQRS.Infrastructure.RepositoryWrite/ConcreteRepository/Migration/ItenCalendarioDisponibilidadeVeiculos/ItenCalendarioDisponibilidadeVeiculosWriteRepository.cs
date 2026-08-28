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

namespace Input.Repository.ItenCalendarioDisponibilidadeVeiculos
{
    public partial class ItenCalendarioDisponibilidadeVeiculosWriteRepository : IItenCalendarioDisponibilidadeVeiculosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IItenCalendarioDisponibilidadeVeiculosQueryWrite _query; 

        public ItenCalendarioDisponibilidadeVeiculosWriteRepository(IUnitOfWork unitOfWork,IItenCalendarioDisponibilidadeVeiculosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos)
        {
            var query = _query.InserirItenCalendarioDisponibilidadeVeiculosQuery(ItenCalendarioDisponibilidadeVeiculos);
        ItenCalendarioDisponibilidadeVeiculos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos)
        {
            var query = _query.UpdateItenCalendarioDisponibilidadeVeiculosQuery(ItenCalendarioDisponibilidadeVeiculos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IItenCalendarioDisponibilidadeVeiculosEntity ItenCalendarioDisponibilidadeVeiculos)
        {
            var query = _query.DeleteItenCalendarioDisponibilidadeVeiculosQuery(ItenCalendarioDisponibilidadeVeiculos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCDV_ID(int id, int value)
        {
            var query = _query.UpdateCDV_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTIP_ID(int id, int value)
        {
            var query = _query.UpdateTIP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIDV_QTD(int id, int value)
        {
            var query = _query.UpdateIDV_QTD(id, value);
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