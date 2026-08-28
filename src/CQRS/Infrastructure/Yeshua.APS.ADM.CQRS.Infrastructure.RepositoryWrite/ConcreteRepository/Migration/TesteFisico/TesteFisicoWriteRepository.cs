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

namespace Input.Repository.TesteFisico
{
    public partial class TesteFisicoWriteRepository : ITesteFisicoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITesteFisicoQueryWrite _query; 

        public TesteFisicoWriteRepository(IUnitOfWork unitOfWork,ITesteFisicoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITesteFisicoEntity TesteFisico)
        {
            var query = _query.InserirTesteFisicoQuery(TesteFisico);
        TesteFisico.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITesteFisicoEntity TesteFisico)
        {
            var query = _query.UpdateTesteFisicoQuery(TesteFisico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITesteFisicoEntity TesteFisico)
        {
            var query = _query.DeleteTesteFisicoQuery(TesteFisico);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_ID(int id, int value)
        {
            var query = _query.UpdateTES_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateITE_ID(int id, int value)
        {
            var query = _query.UpdateITE_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUSR_ID(int id, int value)
        {
            var query = _query.UpdateUSR_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_NOME_TECNICO(int id, string value)
        {
            var query = _query.UpdateTES_NOME_TECNICO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_AMOSTRA(int id, int value)
        {
            var query = _query.UpdateTES_AMOSTRA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_OP(int id, string value)
        {
            var query = _query.UpdateTES_OP(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_VALOR_NUMERICO(int id, Decimal value)
        {
            var query = _query.UpdateTES_VALOR_NUMERICO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_VALOR_DATA(int id, DateTime value)
        {
            var query = _query.UpdateTES_VALOR_DATA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_VALOR_TEXTO(int id, string value)
        {
            var query = _query.UpdateTES_VALOR_TEXTO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTES_EMISSAO(int id, DateTime value)
        {
            var query = _query.UpdateTES_EMISSAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateORD_ID(int id, string value)
        {
            var query = _query.UpdateORD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int id, string value)
        {
            var query = _query.UpdatePRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int id, string value)
        {
            var query = _query.UpdateMAQ_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            var query = _query.UpdateFPR_SEQ_REPETICAO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFPR_SEQ_TRANFORMACAO(int id, int value)
        {
            var query = _query.UpdateFPR_SEQ_TRANFORMACAO(id, value);
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