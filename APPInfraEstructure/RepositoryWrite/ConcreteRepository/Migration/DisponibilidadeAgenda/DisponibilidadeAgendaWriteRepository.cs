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
    public class DisponibilidadeAgendaWriteRepository : IDisponibilidadeAgendaWriteRepository
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
        DisponibilidadeAgenda.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = _query.UpdateDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IDisponibilidadeAgendaEntity DisponibilidadeAgenda)
        {
            var query = _query.DeleteDisponibilidadeAgendaQuery(DisponibilidadeAgenda);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateProfissionalId(IDisponibilidadeAgendaEntity entity)
        {
            var query = _query.UpdateProfissionalId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateDataHora(IDisponibilidadeAgendaEntity entity)
        {
            var query = _query.UpdateDataHora(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration