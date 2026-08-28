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

namespace Input.Repository.PoliticaOnduladeira
{
    public partial class PoliticaOnduladeiraWriteRepository : IPoliticaOnduladeiraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPoliticaOnduladeiraQueryWrite _query; 

        public PoliticaOnduladeiraWriteRepository(IUnitOfWork unitOfWork,IPoliticaOnduladeiraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPoliticaOnduladeiraEntity PoliticaOnduladeira)
        {
            var query = _query.InserirPoliticaOnduladeiraQuery(PoliticaOnduladeira);
        PoliticaOnduladeira.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPoliticaOnduladeiraEntity PoliticaOnduladeira)
        {
            var query = _query.UpdatePoliticaOnduladeiraQuery(PoliticaOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPoliticaOnduladeiraEntity PoliticaOnduladeira)
        {
            var query = _query.DeletePoliticaOnduladeiraQuery(PoliticaOnduladeira);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePOL_ID(int id, int value)
        {
            var query = _query.UpdatePOL_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePOL_NIVEL(int id, int value)
        {
            var query = _query.UpdatePOL_NIVEL(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePOL_PROMOCAO(int id, int value)
        {
            var query = _query.UpdatePOL_PROMOCAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePOL_DIAS_ANTECIPACAO(int id, int value)
        {
            var query = _query.UpdatePOL_DIAS_ANTECIPACAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePOL_METROS_LINEARES(int id, int value)
        {
            var query = _query.UpdatePOL_METROS_LINEARES(id, value);
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