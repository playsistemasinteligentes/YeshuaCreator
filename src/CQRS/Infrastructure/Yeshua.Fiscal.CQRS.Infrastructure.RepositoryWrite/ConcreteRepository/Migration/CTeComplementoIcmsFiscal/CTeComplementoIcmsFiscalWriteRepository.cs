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

namespace Input.Repository.CTeComplementoIcmsFiscal
{
    public partial class CTeComplementoIcmsFiscalWriteRepository : ICTeComplementoIcmsFiscalWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICTeComplementoIcmsFiscalQueryWrite _query; 

        public CTeComplementoIcmsFiscalWriteRepository(IUnitOfWork unitOfWork,ICTeComplementoIcmsFiscalQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICTeComplementoIcmsFiscalEntity CTeComplementoIcmsFiscal)
        {
            var query = _query.InserirCTeComplementoIcmsFiscalQuery(CTeComplementoIcmsFiscal);
        CTeComplementoIcmsFiscal.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICTeComplementoIcmsFiscalEntity CTeComplementoIcmsFiscal)
        {
            var query = _query.UpdateCTeComplementoIcmsFiscalQuery(CTeComplementoIcmsFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICTeComplementoIcmsFiscalEntity CTeComplementoIcmsFiscal)
        {
            var query = _query.DeleteCTeComplementoIcmsFiscalQuery(CTeComplementoIcmsFiscal);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCTeSolicitacaoFiscalId(int id, int value)
        {
            var query = _query.UpdateCTeSolicitacaoFiscalId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorPrestacaoComplementar(int id, Decimal value)
        {
            var query = _query.UpdateValorPrestacaoComplementar(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCST(int id, string value)
        {
            var query = _query.UpdateCST(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorBaseCalculo(int id, Decimal value)
        {
            var query = _query.UpdateValorBaseCalculo(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAliquotaICMS(int id, Decimal value)
        {
            var query = _query.UpdateAliquotaICMS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateValorICMS(int id, Decimal value)
        {
            var query = _query.UpdateValorICMS(id, value);
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
        public void UpdateOperationalEntityId(int id, string value)
        {
            var query = _query.UpdateOperationalEntityId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration