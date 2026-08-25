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
        public void UpdateDescricao(string id, string value)
        {
            var query = _query.UpdateDescricao(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(string id, string value)
        {
            var query = _query.UpdateStatus(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string id, int value)
        {
            var query = _query.UpdateTenantID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string id, bool value)
        {
            var query = _query.UpdateDeleted(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string id, DateTime value)
        {
            var query = _query.UpdateChanged(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string id, int value)
        {
            var query = _query.UpdateUserId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration