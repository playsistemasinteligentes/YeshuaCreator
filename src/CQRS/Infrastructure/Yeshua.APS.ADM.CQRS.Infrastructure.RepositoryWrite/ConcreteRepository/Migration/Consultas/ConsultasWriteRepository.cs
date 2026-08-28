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

namespace Input.Repository.Consultas
{
    public partial class ConsultasWriteRepository : IConsultasWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IConsultasQueryWrite _query; 

        public ConsultasWriteRepository(IUnitOfWork unitOfWork,IConsultasQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IConsultasEntity Consultas)
        {
            var query = _query.InserirConsultasQuery(Consultas);
        Consultas.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IConsultasEntity Consultas)
        {
            var query = _query.UpdateConsultasQuery(Consultas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IConsultasEntity Consultas)
        {
            var query = _query.DeleteConsultasQuery(Consultas);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCON_CASAS_DECIMAIS(int id, string value)
        {
            var query = _query.UpdateCON_CASAS_DECIMAIS(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCON_CONEXAO(int id, string value)
        {
            var query = _query.UpdateCON_CONEXAO(id, value);
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