using Dapper;
using Dominio.Entitys;
using Input.Querys.Servico;
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

namespace Input.Repository.Servico
{
    public class ServicoWriteRepository : IServicoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ServicoWriteRepository(IUnitOfWork unitOfWork)
        {
             _UnitOfWork= unitOfWork;
        }

        public void Insert(IServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().InserirServicoQuery(Servico);
        Servico.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().UpdateServicoQuery(Servico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IServicoEntity Servico)
        {
            var query = new ServicoWriteQuery().DeleteServicoQuery(Servico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGrupoServicoId(IServicoEntity entity)
        {
            var query = new ServicoWriteQuery().UpdateGrupoServicoId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IServicoEntity entity)
        {
            var query = new ServicoWriteQuery().UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValor(IServicoEntity entity)
        {
            var query = new ServicoWriteQuery().UpdateValor(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration