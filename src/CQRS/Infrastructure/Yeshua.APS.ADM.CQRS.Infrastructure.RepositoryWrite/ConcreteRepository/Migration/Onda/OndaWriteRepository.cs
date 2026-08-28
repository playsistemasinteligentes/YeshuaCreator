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

namespace Input.Repository.Onda
{
    public partial class OndaWriteRepository : IOndaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IOndaQueryWrite _query; 

        public OndaWriteRepository(IUnitOfWork unitOfWork,IOndaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IOndaEntity Onda)
        {
            var query = _query.InserirOndaQuery(Onda);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IOndaEntity Onda)
        {
            var query = _query.UpdateOndaQuery(Onda);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IOndaEntity Onda)
        {
            var query = _query.DeleteOndaQuery(Onda);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_ESPESSURA(string ond_id, Decimal value)
        {
            var query = _query.UpdateOND_ESPESSURA(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_PESO_COLA(string ond_id, Decimal value)
        {
            var query = _query.UpdateOND_PESO_COLA(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_RENDIMENTO_ONDA_1(string ond_id, Decimal value)
        {
            var query = _query.UpdateOND_RENDIMENTO_ONDA_1(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_RENDIMENTO_ONDA_2(string ond_id, Decimal value)
        {
            var query = _query.UpdateOND_RENDIMENTO_ONDA_2(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_PROFUNDIDADE_VINCO(string ond_id, int value)
        {
            var query = _query.UpdateOND_PROFUNDIDADE_VINCO(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOND_ID_INTEGRACAO(string ond_id, string value)
        {
            var query = _query.UpdateOND_ID_INTEGRACAO(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIN_ID(string ond_id, int value)
        {
            var query = _query.UpdateVIN_ID(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string ond_id, int value)
        {
            var query = _query.UpdateTenantID(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string ond_id, bool value)
        {
            var query = _query.UpdateDeleted(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string ond_id, DateTime value)
        {
            var query = _query.UpdateChanged(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string ond_id, int value)
        {
            var query = _query.UpdateUserId(ond_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration