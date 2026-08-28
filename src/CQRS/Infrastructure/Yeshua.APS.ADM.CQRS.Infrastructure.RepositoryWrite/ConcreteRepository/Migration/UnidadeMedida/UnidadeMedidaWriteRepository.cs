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

namespace Input.Repository.UnidadeMedida
{
    public partial class UnidadeMedidaWriteRepository : IUnidadeMedidaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IUnidadeMedidaQueryWrite _query; 

        public UnidadeMedidaWriteRepository(IUnitOfWork unitOfWork,IUnidadeMedidaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IUnidadeMedidaEntity UnidadeMedida)
        {
            var query = _query.InserirUnidadeMedidaQuery(UnidadeMedida);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IUnidadeMedidaEntity UnidadeMedida)
        {
            var query = _query.UpdateUnidadeMedidaQuery(UnidadeMedida);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IUnidadeMedidaEntity UnidadeMedida)
        {
            var query = _query.DeleteUnidadeMedidaQuery(UnidadeMedida);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_DESCRICAO(string uni_id, string value)
        {
            var query = _query.UpdateUNI_DESCRICAO(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUNI_ESCALA_TEMPO(string uni_id, string value)
        {
            var query = _query.UpdateUNI_ESCALA_TEMPO(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string uni_id, int value)
        {
            var query = _query.UpdateTenantID(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string uni_id, bool value)
        {
            var query = _query.UpdateDeleted(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string uni_id, DateTime value)
        {
            var query = _query.UpdateChanged(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string uni_id, int value)
        {
            var query = _query.UpdateUserId(uni_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration