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

namespace Input.Repository.Unidade_Unidade
{
    public partial class Unidade_UnidadeWriteRepository : IUnidade_UnidadeWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IUnidade_UnidadeQueryWrite _query; 

        public Unidade_UnidadeWriteRepository(IUnitOfWork unitOfWork,IUnidade_UnidadeQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IUnidade_UnidadeEntity Unidade_Unidade)
        {
            var query = _query.InserirUnidade_UnidadeQuery(Unidade_Unidade);
        Unidade_Unidade.UNI_ID =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IUnidade_UnidadeEntity Unidade_Unidade)
        {
            var query = _query.UpdateUnidade_UnidadeQuery(Unidade_Unidade);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IUnidade_UnidadeEntity Unidade_Unidade)
        {
            var query = _query.DeleteUnidade_UnidadeQuery(Unidade_Unidade);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_DESCRICAO(int uni_id, string value)
        {
            var query = _query.UpdateUNI_DESCRICAO(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int uni_id, int value)
        {
            var query = _query.UpdateTenantID(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int uni_id, bool value)
        {
            var query = _query.UpdateDeleted(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int uni_id, DateTime value)
        {
            var query = _query.UpdateChanged(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int uni_id, int value)
        {
            var query = _query.UpdateUserId(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration