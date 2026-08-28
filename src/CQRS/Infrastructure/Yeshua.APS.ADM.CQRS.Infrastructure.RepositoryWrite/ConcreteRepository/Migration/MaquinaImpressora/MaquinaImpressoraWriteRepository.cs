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

namespace Input.Repository.MaquinaImpressora
{
    public partial class MaquinaImpressoraWriteRepository : IMaquinaImpressoraWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMaquinaImpressoraQueryWrite _query; 

        public MaquinaImpressoraWriteRepository(IUnitOfWork unitOfWork,IMaquinaImpressoraQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMaquinaImpressoraEntity MaquinaImpressora)
        {
            var query = _query.InserirMaquinaImpressoraQuery(MaquinaImpressora);
        MaquinaImpressora.MAQ_IMP_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMaquinaImpressoraEntity MaquinaImpressora)
        {
            var query = _query.UpdateMaquinaImpressoraQuery(MaquinaImpressora);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMaquinaImpressoraEntity MaquinaImpressora)
        {
            var query = _query.DeleteMaquinaImpressoraQuery(MaquinaImpressora);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int maq_imp_id, string value)
        {
            var query = _query.UpdateMAQ_ID(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateIMP_ID(int maq_imp_id, int value)
        {
            var query = _query.UpdateIMP_ID(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAI_FACAO(int maq_imp_id, int value)
        {
            var query = _query.UpdateMAI_FACAO(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int maq_imp_id, int value)
        {
            var query = _query.UpdateTenantID(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int maq_imp_id, bool value)
        {
            var query = _query.UpdateDeleted(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int maq_imp_id, DateTime value)
        {
            var query = _query.UpdateChanged(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int maq_imp_id, int value)
        {
            var query = _query.UpdateUserId(maq_imp_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration