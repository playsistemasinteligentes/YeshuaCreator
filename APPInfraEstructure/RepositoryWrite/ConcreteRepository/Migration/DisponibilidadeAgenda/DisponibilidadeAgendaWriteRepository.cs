using Dapper;
using Dominio.Entitys;
using Input.Querys.DisponibilidadeAgenda;
using IRepository.Write;
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
    public class DisponibilidadeAgendaWriteRepository : IDisponibilidadeAgendaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public DisponibilidadeAgendaWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().InserirDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
        DisponibilidadeAgenda.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().UpdateDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().DeleteDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateProfissionalId(IDisponibilidadeAgendaEntity entity)
        {
            var query = new DisponibilidadeAgendaWriteQuery().UpdateProfissionalId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataHora(IDisponibilidadeAgendaEntity entity)
        {
            var query = new DisponibilidadeAgendaWriteQuery().UpdateDataHora(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration