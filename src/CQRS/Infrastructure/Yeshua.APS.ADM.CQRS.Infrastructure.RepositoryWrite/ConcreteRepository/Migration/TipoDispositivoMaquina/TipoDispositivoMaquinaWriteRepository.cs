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

namespace Input.Repository.TipoDispositivoMaquina
{
    public partial class TipoDispositivoMaquinaWriteRepository : ITipoDispositivoMaquinaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly ITipoDispositivoMaquinaQueryWrite _query; 

        public TipoDispositivoMaquinaWriteRepository(IUnitOfWork unitOfWork,ITipoDispositivoMaquinaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina)
        {
            var query = _query.InserirTipoDispositivoMaquinaQuery(TipoDispositivoMaquina);
        TipoDispositivoMaquina.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina)
        {
            var query = _query.UpdateTipoDispositivoMaquinaQuery(TipoDispositivoMaquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina)
        {
            var query = _query.DeleteTipoDispositivoMaquinaQuery(TipoDispositivoMaquina);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTDI_ID(int id, string value)
        {
            var query = _query.UpdateTDI_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAQ_ID(int id, string value)
        {
            var query = _query.UpdateMAQ_ID(id, value);
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