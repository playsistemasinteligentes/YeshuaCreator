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

namespace Input.Repository.PontosMapa
{
    public partial class PontosMapaWriteRepository : IPontosMapaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPontosMapaQueryWrite _query; 

        public PontosMapaWriteRepository(IUnitOfWork unitOfWork,IPontosMapaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPontosMapaEntity PontosMapa)
        {
            var query = _query.InserirPontosMapaQuery(PontosMapa);
                _UnitOfWork.Execute(query.Query, query.Parameters);
        }

        public void Update(IPontosMapaEntity PontosMapa)
        {
            var query = _query.UpdatePontosMapaQuery(PontosMapa);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPontosMapaEntity PontosMapa)
        {
            var query = _query.DeletePontosMapaQuery(PontosMapa);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_DESCRICAO(string pon_id, string value)
        {
            var query = _query.UpdatePON_DESCRICAO(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_TIPO(string pon_id, string value)
        {
            var query = _query.UpdatePON_TIPO(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_LATITUDE(string pon_id, Decimal value)
        {
            var query = _query.UpdatePON_LATITUDE(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_LONGITUDE(string pon_id, Decimal value)
        {
            var query = _query.UpdatePON_LONGITUDE(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_DISTANCIA_KM(string pon_id, Decimal value)
        {
            var query = _query.UpdatePON_DISTANCIA_KM(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateTenantID(string pon_id, int value)
        {
            var query = _query.UpdateTenantID(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateDeleted(string pon_id, bool value)
        {
            var query = _query.UpdateDeleted(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateChanged(string pon_id, DateTime value)
        {
            var query = _query.UpdateChanged(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateUserId(string pon_id, int value)
        {
            var query = _query.UpdateUserId(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMUN_ID(string pon_id, string value)
        {
            var query = _query.UpdateMUN_ID(pon_id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteConcreteRepositoryMigration