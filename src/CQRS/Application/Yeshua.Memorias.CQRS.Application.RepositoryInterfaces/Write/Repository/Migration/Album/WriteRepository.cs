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
    public partial interface IAlbumWriteRepository
    {
        void Insert(IAlbumEntity album);
        void Update(IAlbumEntity album);
        void Delete(IAlbumEntity album);
        void UpdateTitulo(int id, string value);
        void UpdateDescricao(int id, string value);
        void UpdatePrivacidade(int id, int value);
        void UpdateSegundosPorFoto(int id, int value);
        void UpdateStatus(int id, int value);
        void UpdateOperationalEntityId(int id, string value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration