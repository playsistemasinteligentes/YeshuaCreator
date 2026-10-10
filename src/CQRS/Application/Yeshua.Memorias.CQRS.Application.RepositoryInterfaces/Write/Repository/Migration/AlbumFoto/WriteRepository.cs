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
    public partial interface IAlbumFotoWriteRepository
    {
        void Insert(IAlbumFotoEntity albumfoto);
        void Update(IAlbumFotoEntity albumfoto);
        void Delete(IAlbumFotoEntity albumfoto);
        void UpdateAlbumId(int id, int value);
        void UpdateFotoId(int id, int value);
        void UpdateOrdem(int id, int value);
        void UpdateLegenda(int id, string value);
        void UpdateOperationalEntityId(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration