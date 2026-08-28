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

namespace Input.Repository.Plotagem
{
    public partial class PlotagemWriteRepository : IPlotagemWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPlotagemQueryWrite _query; 

        public PlotagemWriteRepository(IUnitOfWork unitOfWork,IPlotagemQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPlotagemEntity Plotagem)
        {
            var query = _query.InserirPlotagemQuery(Plotagem);
        Plotagem.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPlotagemEntity Plotagem)
        {
            var query = _query.UpdatePlotagemQuery(Plotagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPlotagemEntity Plotagem)
        {
            var query = _query.DeletePlotagemQuery(Plotagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_ID(int id, int value)
        {
            var query = _query.UpdatePLO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_NOME(int id, string value)
        {
            var query = _query.UpdatePLO_NOME(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_DIMENSAO(int id, string value)
        {
            var query = _query.UpdatePLO_DIMENSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_X(int id, string value)
        {
            var query = _query.UpdatePLO_X(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_Y(int id, string value)
        {
            var query = _query.UpdatePLO_Y(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_Z(int id, string value)
        {
            var query = _query.UpdatePLO_Z(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_GRAFICO(int id, string value)
        {
            var query = _query.UpdatePLO_GRAFICO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCON_ID(int id, int value)
        {
            var query = _query.UpdateCON_ID(id, value);
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