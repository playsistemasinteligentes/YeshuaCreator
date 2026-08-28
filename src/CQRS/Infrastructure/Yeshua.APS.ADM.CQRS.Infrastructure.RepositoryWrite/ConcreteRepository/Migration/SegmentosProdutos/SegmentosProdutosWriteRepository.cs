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

namespace Input.Repository.SegmentosProdutos
{
    public partial class SegmentosProdutosWriteRepository : ISegmentosProdutosWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ISegmentosProdutosQueryWrite _query; 

        public SegmentosProdutosWriteRepository(IUnitOfWork unitOfWork,ISegmentosProdutosQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ISegmentosProdutosEntity SegmentosProdutos)
        {
            var query = _query.InserirSegmentosProdutosQuery(SegmentosProdutos);
        SegmentosProdutos.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ISegmentosProdutosEntity SegmentosProdutos)
        {
            var query = _query.UpdateSegmentosProdutosQuery(SegmentosProdutos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ISegmentosProdutosEntity SegmentosProdutos)
        {
            var query = _query.DeleteSegmentosProdutosQuery(SegmentosProdutos);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGRS_ID(int id, string value)
        {
            var query = _query.UpdateGRS_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePRO_ID(int id, string value)
        {
            var query = _query.UpdatePRO_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSEG_ID(int id, string value)
        {
            var query = _query.UpdateSEG_ID(id, value);
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