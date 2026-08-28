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

namespace Input.Repository.Enderecos
{
    public partial class EnderecosWriteRepository : IEnderecosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IEnderecosQueryWrite _query; 

        public EnderecosWriteRepository(IUnitOfWork unitOfWork,IEnderecosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IEnderecosEntity Enderecos)
        {
            var query = _query.InserirEnderecosQuery(Enderecos);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IEnderecosEntity Enderecos)
        {
            var query = _query.UpdateEnderecosQuery(Enderecos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IEnderecosEntity Enderecos)
        {
            var query = _query.DeleteEnderecosQuery(Enderecos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateEND_GRUPO(string end_id, string value)
        {
            var query = _query.UpdateEND_GRUPO(end_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string end_id, int value)
        {
            var query = _query.UpdateTenantID(end_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string end_id, bool value)
        {
            var query = _query.UpdateDeleted(end_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string end_id, DateTime value)
        {
            var query = _query.UpdateChanged(end_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string end_id, int value)
        {
            var query = _query.UpdateUserId(end_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration