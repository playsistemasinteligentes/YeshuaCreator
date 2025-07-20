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

namespace Input.Repository.Servico
{
    public class ServicoWriteRepository : IServicoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IServicoQueryWrite _query; 

        public ServicoWriteRepository(IUnitOfWork unitOfWork,IServicoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IServicoEntity Servico)
        {
            var query = _query.InserirServicoQuery(Servico);
        Servico.Id =  _UnitOfWork.Connection.ExecuteScalar<int>(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }

        public void Update(IServicoEntity Servico)
        {
            var query = _query.UpdateServicoQuery(Servico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void Delete(IServicoEntity Servico)
        {
            var query = _query.DeleteServicoQuery(Servico);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateGrupoServicoId(IServicoEntity entity)
        {
            var query = _query.UpdateGrupoServicoId(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateNome(IServicoEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
        public void UpdateValor(IServicoEntity entity)
        {
            var query = _query.UpdateValor(entity);
             _UnitOfWork.Connection.Execute(query.Query, query.Parameters,_UnitOfWork.Transaction);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration