using Dapper;
using Dominio.Entitys;
using Input.Querys.DisponibilidadeAgenda;
using Repositorio.Inputs.Repositorio.DisponibilidadeAgenda;
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

        public void Insert(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().InserirDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
        DisponibilidadeAgenda.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().UpdateDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
        public void Delete(DisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = new DisponibilidadeAgendaWriteQuery().DeleteDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration