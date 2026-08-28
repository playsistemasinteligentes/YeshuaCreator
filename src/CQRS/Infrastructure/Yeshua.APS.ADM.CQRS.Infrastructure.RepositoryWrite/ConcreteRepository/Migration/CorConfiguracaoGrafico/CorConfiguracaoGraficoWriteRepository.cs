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

namespace Input.Repository.CorConfiguracaoGrafico
{
    public partial class CorConfiguracaoGraficoWriteRepository : ICorConfiguracaoGraficoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICorConfiguracaoGraficoQueryWrite _query; 

        public CorConfiguracaoGraficoWriteRepository(IUnitOfWork unitOfWork,ICorConfiguracaoGraficoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico)
        {
            var query = _query.InserirCorConfiguracaoGraficoQuery(CorConfiguracaoGrafico);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico)
        {
            var query = _query.UpdateCorConfiguracaoGraficoQuery(CorConfiguracaoGrafico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICorConfiguracaoGraficoEntity CorConfiguracaoGrafico)
        {
            var query = _query.DeleteCorConfiguracaoGraficoQuery(CorConfiguracaoGrafico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_PERCENTUAL_INI(string cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_PERCENTUAL_INI(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_PERCENTUAL_FIM(string cor_id, Decimal value)
        {
            var query = _query.UpdateCOR_PERCENTUAL_FIM(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOR_DESCRICAO(string cor_id, string value)
        {
            var query = _query.UpdateCOR_DESCRICAO(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string cor_id, int value)
        {
            var query = _query.UpdateTenantID(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string cor_id, bool value)
        {
            var query = _query.UpdateDeleted(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string cor_id, DateTime value)
        {
            var query = _query.UpdateChanged(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string cor_id, int value)
        {
            var query = _query.UpdateUserId(cor_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration