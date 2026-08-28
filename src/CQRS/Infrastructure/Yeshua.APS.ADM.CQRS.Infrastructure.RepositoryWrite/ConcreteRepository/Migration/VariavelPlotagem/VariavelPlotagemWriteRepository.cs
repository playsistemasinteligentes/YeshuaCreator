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

namespace Input.Repository.VariavelPlotagem
{
    public partial class VariavelPlotagemWriteRepository : IVariavelPlotagemWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IVariavelPlotagemQueryWrite _query; 

        public VariavelPlotagemWriteRepository(IUnitOfWork unitOfWork,IVariavelPlotagemQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IVariavelPlotagemEntity VariavelPlotagem)
        {
            var query = _query.InserirVariavelPlotagemQuery(VariavelPlotagem);
        VariavelPlotagem.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IVariavelPlotagemEntity VariavelPlotagem)
        {
            var query = _query.UpdateVariavelPlotagemQuery(VariavelPlotagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IVariavelPlotagemEntity VariavelPlotagem)
        {
            var query = _query.DeleteVariavelPlotagemQuery(VariavelPlotagem);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVAR_ID(int id, int value)
        {
            var query = _query.UpdateVAR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePLO_ID(int id, int value)
        {
            var query = _query.UpdatePLO_ID(id, value);
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