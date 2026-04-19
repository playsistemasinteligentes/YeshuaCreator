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
    public partial class ServicoWriteRepository : IServicoWriteRepository
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
        Servico.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IServicoEntity Servico)
        {
            var query = _query.UpdateServicoQuery(Servico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IServicoEntity Servico)
        {
            var query = _query.DeleteServicoQuery(Servico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGrupoServicoId(IServicoEntity entity)
        {
            var query = _query.UpdateGrupoServicoId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateNome(IServicoEntity entity)
        {
            var query = _query.UpdateNome(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValor(IServicoEntity entity)
        {
            var query = _query.UpdateValor(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(IServicoEntity entity)
        {
            var query = _query.UpdateTenantID(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(IServicoEntity entity)
        {
            var query = _query.UpdateDeleted(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(IServicoEntity entity)
        {
            var query = _query.UpdateChanged(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(IServicoEntity entity)
        {
            var query = _query.UpdateUserId(entity);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration