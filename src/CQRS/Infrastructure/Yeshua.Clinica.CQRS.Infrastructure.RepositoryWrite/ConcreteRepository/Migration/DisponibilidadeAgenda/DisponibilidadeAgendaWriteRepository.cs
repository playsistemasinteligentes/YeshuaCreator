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

namespace Input.Repository.DisponibilidadeAgenda
{
    public partial class DisponibilidadeAgendaWriteRepository : IDisponibilidadeAgendaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IDisponibilidadeAgendaQueryWrite _query; 

        public DisponibilidadeAgendaWriteRepository(IUnitOfWork unitOfWork,IDisponibilidadeAgendaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = _query.InserirDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
        DisponibilidadeAgenda.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = _query.UpdateDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = _query.DeleteDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProfissionalId(int id, int value)
        {
            var query = _query.UpdateProfissionalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDataHora(int id, DateTime value)
        {
            var query = _query.UpdateDataHora(id, value);
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