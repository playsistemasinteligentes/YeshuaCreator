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

namespace Input.Repository.Maquina
{
    public partial class MaquinaWriteRepository : IMaquinaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMaquinaQueryWrite _query; 

        public MaquinaWriteRepository(IUnitOfWork unitOfWork,IMaquinaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMaquinaEntity Maquina)
        {
            var query = _query.InserirMaquinaQuery(Maquina);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IMaquinaEntity Maquina)
        {
            var query = _query.UpdateMaquinaQuery(Maquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMaquinaEntity Maquina)
        {
            var query = _query.DeleteMaquinaQuery(Maquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_DESCRICAO(string maq_id, string value)
        {
            var query = _query.UpdateMAQ_DESCRICAO(maq_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_STATUS(string maq_id, string value)
        {
            var query = _query.UpdateMAQ_STATUS(maq_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string maq_id, int value)
        {
            var query = _query.UpdateTenantID(maq_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string maq_id, bool value)
        {
            var query = _query.UpdateDeleted(maq_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string maq_id, DateTime value)
        {
            var query = _query.UpdateChanged(maq_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string maq_id, int value)
        {
            var query = _query.UpdateUserId(maq_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration