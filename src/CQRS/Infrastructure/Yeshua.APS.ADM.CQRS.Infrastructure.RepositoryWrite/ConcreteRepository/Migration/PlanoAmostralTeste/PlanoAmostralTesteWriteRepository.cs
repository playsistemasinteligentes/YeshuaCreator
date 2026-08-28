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

namespace Input.Repository.PlanoAmostralTeste
{
    public partial class PlanoAmostralTesteWriteRepository : IPlanoAmostralTesteWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPlanoAmostralTesteQueryWrite _query; 

        public PlanoAmostralTesteWriteRepository(IUnitOfWork unitOfWork,IPlanoAmostralTesteQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPlanoAmostralTesteEntity PlanoAmostralTeste)
        {
            var query = _query.InserirPlanoAmostralTesteQuery(PlanoAmostralTeste);
        PlanoAmostralTeste.PAT_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPlanoAmostralTesteEntity PlanoAmostralTeste)
        {
            var query = _query.UpdatePlanoAmostralTesteQuery(PlanoAmostralTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPlanoAmostralTesteEntity PlanoAmostralTeste)
        {
            var query = _query.DeletePlanoAmostralTesteQuery(PlanoAmostralTeste);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_TIPO(int pat_id, Decimal value)
        {
            var query = _query.UpdateGRP_TIPO(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int pat_id, int value)
        {
            var query = _query.UpdateTenantID(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int pat_id, bool value)
        {
            var query = _query.UpdateDeleted(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int pat_id, DateTime value)
        {
            var query = _query.UpdateChanged(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int pat_id, int value)
        {
            var query = _query.UpdateUserId(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAT_QTD_CAIXAS_DE(int pat_id, int value)
        {
            var query = _query.UpdatePAT_QTD_CAIXAS_DE(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAT_QTD_CAIXAS_ATE(int pat_id, int value)
        {
            var query = _query.UpdatePAT_QTD_CAIXAS_ATE(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAT_N_AMOSTRAGEM(int pat_id, int value)
        {
            var query = _query.UpdatePAT_N_AMOSTRAGEM(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePAT_PERCENT_ESPECIF(int pat_id, Decimal value)
        {
            var query = _query.UpdatePAT_PERCENT_ESPECIF(pat_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration