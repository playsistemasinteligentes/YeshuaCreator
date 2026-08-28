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

namespace Input.Repository.Mapa
{
    public partial class MapaWriteRepository : IMapaWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IMapaQueryWrite _query; 

        public MapaWriteRepository(IUnitOfWork unitOfWork,IMapaQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IMapaEntity Mapa)
        {
            var query = _query.InserirMapaQuery(Mapa);
        Mapa.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IMapaEntity Mapa)
        {
            var query = _query.UpdateMapaQuery(Mapa);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IMapaEntity Mapa)
        {
            var query = _query.DeleteMapaQuery(Mapa);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAP_ID(int id, int value)
        {
            var query = _query.UpdateMAP_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_ID(int id, string value)
        {
            var query = _query.UpdatePON_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePON_ID_VIZINHO(int id, string value)
        {
            var query = _query.UpdatePON_ID_VIZINHO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAP_DISTANCIA(int id, Decimal value)
        {
            var query = _query.UpdateMAP_DISTANCIA(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAP_CUSTO_PEDAGIO_POR_EIXO(int id, Decimal value)
        {
            var query = _query.UpdateMAP_CUSTO_PEDAGIO_POR_EIXO(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateROD_ID(int id, int value)
        {
            var query = _query.UpdateROD_ID(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMAP_ALTURA_ROD(int id, Decimal value)
        {
            var query = _query.UpdateMAP_ALTURA_ROD(id, value);
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