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

namespace Input.Repository.Vinco
{
    public partial class VincoWriteRepository : IVincoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IVincoQueryWrite _query; 

        public VincoWriteRepository(IUnitOfWork unitOfWork,IVincoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IVincoEntity Vinco)
        {
            var query = _query.InserirVincoQuery(Vinco);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IVincoEntity Vinco)
        {
            var query = _query.UpdateVincoQuery(Vinco);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IVincoEntity Vinco)
        {
            var query = _query.DeleteVincoQuery(Vinco);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIN_DESCRICAO(int vin_id, string value)
        {
            var query = _query.UpdateVIN_DESCRICAO(vin_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVIN_ID_DESLOCAMENTO(int vin_id, string value)
        {
            var query = _query.UpdateVIN_ID_DESLOCAMENTO(vin_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(int vin_id, int value)
        {
            var query = _query.UpdateTenantID(vin_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(int vin_id, bool value)
        {
            var query = _query.UpdateDeleted(vin_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(int vin_id, DateTime value)
        {
            var query = _query.UpdateChanged(vin_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(int vin_id, int value)
        {
            var query = _query.UpdateUserId(vin_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration