// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration
// </yeshua>

using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IPublicacaoAlbumWriteRepository
    {
        void Insert(IPublicacaoAlbumEntity publicacaoalbum);
        void Update(IPublicacaoAlbumEntity publicacaoalbum);
        void Delete(IPublicacaoAlbumEntity publicacaoalbum);
        void UpdateAlbumId(int id, int value);
        void UpdateCorrelationId(int id, string value);
        void UpdateManifestStorageKey(int id, string value);
        void UpdateVideoStorageKey(int id, string value);
        void UpdateYouTubeVideoId(int id, string value);
        void UpdateYouTubeUrl(int id, string value);
        void UpdateMensagem(int id, string value);
        void UpdateSolicitadaEmUtc(int id, DateTime value);
        void UpdatePublicadaEmUtc(int id, DateTime value);
        void UpdateStatus(int id, int value);
        void UpdateOperationalEntityId(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration