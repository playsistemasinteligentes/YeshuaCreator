// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IPublicacaoAlbumReadRepository
    {
        public DataPagination<PublicacaoAlbumDTO> getPublicacaoAlbum(ICommandRead command );
        public IEnumerable<PublicacaoAlbumAlbumIdDTO> getPublicacaoAlbumReadFKAlbumId(object command );
        public IEnumerable<PublicacaoAlbumTenantIDDTO> getPublicacaoAlbumReadFKTenantID(object command );
        public IEnumerable<PublicacaoAlbumUserIdDTO> getPublicacaoAlbumReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByAlbumId(int value );
        public bool ExistsByCorrelationId(string value );
        public bool ExistsByManifestStorageKey(string value );
        public bool ExistsByVideoStorageKey(string value );
        public bool ExistsByYouTubeVideoId(string value );
        public bool ExistsByYouTubeUrl(string value );
        public bool ExistsByMensagem(string value );
        public bool ExistsBySolicitadaEmUtc(DateTime value );
        public bool ExistsByPublicadaEmUtc(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByOperationalEntityId(string value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public PublicacaoAlbumDTO FirstById(int value );
        public PublicacaoAlbumDTO FirstByAlbumId(int value );
        public PublicacaoAlbumDTO FirstByCorrelationId(string value );
        public PublicacaoAlbumDTO FirstByManifestStorageKey(string value );
        public PublicacaoAlbumDTO FirstByVideoStorageKey(string value );
        public PublicacaoAlbumDTO FirstByYouTubeVideoId(string value );
        public PublicacaoAlbumDTO FirstByYouTubeUrl(string value );
        public PublicacaoAlbumDTO FirstByMensagem(string value );
        public PublicacaoAlbumDTO FirstBySolicitadaEmUtc(DateTime value );
        public PublicacaoAlbumDTO FirstByPublicadaEmUtc(DateTime value );
        public PublicacaoAlbumDTO FirstByStatus(int value );
        public PublicacaoAlbumDTO FirstByOperationalEntityId(string value );
        public PublicacaoAlbumDTO FirstByTenantID(int value );
        public PublicacaoAlbumDTO FirstByDeleted(bool value );
        public PublicacaoAlbumDTO FirstByChanged(DateTime value );
        public PublicacaoAlbumDTO FirstByUserId(int value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllById(int value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByAlbumId(int value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByCorrelationId(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByManifestStorageKey(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByVideoStorageKey(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByYouTubeVideoId(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByYouTubeUrl(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByMensagem(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllBySolicitadaEmUtc(DateTime value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByPublicadaEmUtc(DateTime value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByStatus(int value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByOperationalEntityId(string value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByTenantID(int value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByDeleted(bool value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByChanged(DateTime value );
        public IEnumerable<PublicacaoAlbumDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration