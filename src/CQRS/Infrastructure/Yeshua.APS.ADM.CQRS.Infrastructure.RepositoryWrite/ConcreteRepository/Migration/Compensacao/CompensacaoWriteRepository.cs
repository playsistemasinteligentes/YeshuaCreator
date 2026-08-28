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

namespace Input.Repository.Compensacao
{
    public partial class CompensacaoWriteRepository : ICompensacaoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ICompensacaoQueryWrite _query; 

        public CompensacaoWriteRepository(IUnitOfWork unitOfWork,ICompensacaoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ICompensacaoEntity Compensacao)
        {
            var query = _query.InserirCompensacaoQuery(Compensacao);
        Compensacao.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ICompensacaoEntity Compensacao)
        {
            var query = _query.UpdateCompensacaoQuery(Compensacao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ICompensacaoEntity Compensacao)
        {
            var query = _query.DeleteCompensacaoQuery(Compensacao);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_ID(int id, int value)
        {
            var query = _query.UpdateCOM_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRP_ID(int id, string value)
        {
            var query = _query.UpdateGRP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_ID(int id, string value)
        {
            var query = _query.UpdateOND_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO1_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO1_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO2_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO2_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO3_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO3_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO4_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO4_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO5_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO5_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO6_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO6_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO7_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO7_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO8_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO8_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO9_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO9_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO10_OND(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO10_OND(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO1_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO1_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO2_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO2_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO3_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO3_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO4_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO4_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO5_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO5_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO6_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO6_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO7_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO7_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO8_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO8_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO9_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO9_CONVERSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCOM_VINCO10_CONVERSAO(int id, int value)
        {
            var query = _query.UpdateCOM_VINCO10_CONVERSAO(id, value);
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