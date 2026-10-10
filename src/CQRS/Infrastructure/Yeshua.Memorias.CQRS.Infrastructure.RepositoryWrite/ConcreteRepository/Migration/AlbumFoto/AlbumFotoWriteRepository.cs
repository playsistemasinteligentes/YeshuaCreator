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

namespace Input.Repository.AlbumFoto
{
    public partial class AlbumFotoWriteRepository : IAlbumFotoWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IAlbumFotoQueryWrite _query; 

        public AlbumFotoWriteRepository(IUnitOfWork unitOfWork,IAlbumFotoQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IAlbumFotoEntity AlbumFoto)
        {
            var query = _query.InserirAlbumFotoQuery(AlbumFoto);
        AlbumFoto.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IAlbumFotoEntity AlbumFoto)
        {
            var query = _query.UpdateAlbumFotoQuery(AlbumFoto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IAlbumFotoEntity AlbumFoto)
        {
            var query = _query.DeleteAlbumFotoQuery(AlbumFoto);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAlbumId(int id, int value)
        {
            var query = _query.UpdateAlbumId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateFotoId(int id, int value)
        {
            var query = _query.UpdateFotoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOrdem(int id, int value)
        {
            var query = _query.UpdateOrdem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateLegenda(int id, string value)
        {
            var query = _query.UpdateLegenda(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateOperationalEntityId(int id, string value)
        {
            var query = _query.UpdateOperationalEntityId(id, value);
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