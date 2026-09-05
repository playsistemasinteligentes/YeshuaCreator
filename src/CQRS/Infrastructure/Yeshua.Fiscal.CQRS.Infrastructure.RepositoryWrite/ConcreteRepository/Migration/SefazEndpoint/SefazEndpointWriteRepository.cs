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

namespace Input.Repository.SefazEndpoint
{
    public partial class SefazEndpointWriteRepository : ISefazEndpointWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ISefazEndpointQueryWrite _query; 

        public SefazEndpointWriteRepository(IUnitOfWork unitOfWork,ISefazEndpointQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ISefazEndpointEntity SefazEndpoint)
        {
            var query = _query.InserirSefazEndpointQuery(SefazEndpoint);
        SefazEndpoint.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ISefazEndpointEntity SefazEndpoint)
        {
            var query = _query.UpdateSefazEndpointQuery(SefazEndpoint);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ISefazEndpointEntity SefazEndpoint)
        {
            var query = _query.DeleteSefazEndpointQuery(SefazEndpoint);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateProdutoFiscal(int id, int value)
        {
            var query = _query.UpdateProdutoFiscal(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUF(int id, string value)
        {
            var query = _query.UpdateUF(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAmbiente(int id, int value)
        {
            var query = _query.UpdateAmbiente(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateServico(int id, string value)
        {
            var query = _query.UpdateServico(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVersao(int id, string value)
        {
            var query = _query.UpdateVersao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUrl(int id, string value)
        {
            var query = _query.UpdateUrl(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAtivo(int id, int value)
        {
            var query = _query.UpdateAtivo(id, value);
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