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

namespace Input.Repository.GrupoMaquina
{
    public partial class GrupoMaquinaWriteRepository : IGrupoMaquinaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IGrupoMaquinaQueryWrite _query; 

        public GrupoMaquinaWriteRepository(IUnitOfWork unitOfWork,IGrupoMaquinaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IGrupoMaquinaEntity GrupoMaquina)
        {
            var query = _query.InserirGrupoMaquinaQuery(GrupoMaquina);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IGrupoMaquinaEntity GrupoMaquina)
        {
            var query = _query.UpdateGrupoMaquinaQuery(GrupoMaquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IGrupoMaquinaEntity GrupoMaquina)
        {
            var query = _query.DeleteGrupoMaquinaQuery(GrupoMaquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGMA_DESCRICAO(string gma_id, string value)
        {
            var query = _query.UpdateGMA_DESCRICAO(gma_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateGMA_STATUS(string gma_id, string value)
        {
            var query = _query.UpdateGMA_STATUS(gma_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string gma_id, int value)
        {
            var query = _query.UpdateTenantID(gma_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string gma_id, bool value)
        {
            var query = _query.UpdateDeleted(gma_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string gma_id, DateTime value)
        {
            var query = _query.UpdateChanged(gma_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string gma_id, int value)
        {
            var query = _query.UpdateUserId(gma_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration