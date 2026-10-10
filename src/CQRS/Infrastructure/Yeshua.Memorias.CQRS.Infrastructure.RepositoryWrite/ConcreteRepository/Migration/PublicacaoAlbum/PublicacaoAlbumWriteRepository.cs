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

namespace Input.Repository.PublicacaoAlbum
{
    public partial class PublicacaoAlbumWriteRepository : IPublicacaoAlbumWriteRepository
    {
        private readonly IUnitOfWork _UnitOfWork;
       private readonly IPublicacaoAlbumQueryWrite _query; 

        public PublicacaoAlbumWriteRepository(IUnitOfWork unitOfWork,IPublicacaoAlbumQueryWrite query)
        {
             _UnitOfWork= unitOfWork;
             _query = query;
        }

        public void Insert(IPublicacaoAlbumEntity PublicacaoAlbum)
        {
            var query = _query.InserirPublicacaoAlbumQuery(PublicacaoAlbum);
        PublicacaoAlbum.Id =  _UnitOfWork.ExecuteScalar<int>(query.Query, query.Parameters);
        }

        public void Update(IPublicacaoAlbumEntity PublicacaoAlbum)
        {
            var query = _query.UpdatePublicacaoAlbumQuery(PublicacaoAlbum);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void Delete(IPublicacaoAlbumEntity PublicacaoAlbum)
        {
            var query = _query.DeletePublicacaoAlbumQuery(PublicacaoAlbum);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateAlbumId(int id, int value)
        {
            var query = _query.UpdateAlbumId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateCorrelationId(int id, string value)
        {
            var query = _query.UpdateCorrelationId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateManifestStorageKey(int id, string value)
        {
            var query = _query.UpdateManifestStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateVideoStorageKey(int id, string value)
        {
            var query = _query.UpdateVideoStorageKey(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateYouTubeVideoId(int id, string value)
        {
            var query = _query.UpdateYouTubeVideoId(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateYouTubeUrl(int id, string value)
        {
            var query = _query.UpdateYouTubeUrl(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateMensagem(int id, string value)
        {
            var query = _query.UpdateMensagem(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateSolicitadaEmUtc(int id, DateTime value)
        {
            var query = _query.UpdateSolicitadaEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdatePublicadaEmUtc(int id, DateTime value)
        {
            var query = _query.UpdatePublicadaEmUtc(id, value);
             _UnitOfWork.Execute(query.Query, query.Parameters);
        }
        public void UpdateStatus(int id, int value)
        {
            var query = _query.UpdateStatus(id, value);
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